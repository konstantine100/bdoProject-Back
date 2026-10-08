using bdoProject.Application.Contracts.DaysCalculator;
using bdoProject.Application.Features.LeaveAndAbsence.Services;
using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Common.Results;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Commands.AssistantLeaveRequestCreate;

public sealed class AssistantLeaveRequestCreateHandler : IRequestHandler<AssistantLeaveRequestCreateCommand, Result<string>>
{
    private readonly IDataContext _context;
    private readonly IDaysCalculator _calculator;

    public AssistantLeaveRequestCreateHandler(IDataContext context, IDaysCalculator calculator)
    {
        _context = context;
        _calculator = calculator;
    }

    public async Task<Result<string>> Handle(AssistantLeaveRequestCreateCommand request, CancellationToken cancellationToken)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);
        
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId, cancellationToken);
        
        if (employee == null)
            return Result<string>.Failure(ErrorResults.NotFoundMessage("თანამშრომლის მონაცემები ვერ მოიძებნა!"));
        
        if (employee.ProbationEndDate > request.StartDate && request.LeaveType == LEAVE_TYPE.ANNUAL)
            return Result<string>.Failure(ErrorResults.Conflict($"გამოსაცდელ პერიოდის ფარგლებში შესაძლებელია არაა ანაზღაურებადი შვებულების მოთხოვნა, შეგიძლიათ აირჩიოთ {employee.ProbationEndDate} თარიღის შემდგომ. სხვა ტიპის შვებულების მისათითებლად შეგიძლიათ მიმართოთ HRს"));
        
        if (employee.ProbationEndDate > request.StartDate && request.LeaveType != LEAVE_TYPE.ANNUAL)
            return Result<string>.Failure(ErrorResults.Conflict("გამოსაცდელ პერიოდის ფარგლებში HR ასისტენტს და პორტალს მოთხოვნის დამტკიცება არ შეუძლია, გთხოვთ მიმართოთ ადამიანური რესურსების სამსახურს"));
        
        if (request.StartDate.Year != request.EndDate.Year)
            return Result<string>.Failure(ErrorResults.Conflict("შვებულების მითითებული საწყისი და ბოლო თარიღი უნდა იყოს ერთ სამუშაო წელს, გთხოვთ შექმენით ორი ცალკეული მოთხოვნა შესაბამისი წლების მიხედვით!"));
        
        var employeeLeaveEntitlement = await _context.LeaveEntitlements
            .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId && x.LeaveType == request.LeaveType, cancellationToken);
        
        if (employeeLeaveEntitlement == null)
            return Result<string>.Failure(ErrorResults.NotFoundMessage("თანამშრომლის შვებულების მონაცემები ვერ მოიძებნა!"));

        var employeeLeaveRequests = await _context.LeaveRequests
            .Where(x => x.EmployeeId == request.EmployeeId &&
                                    (x.Status == LEAVE_REQUEST_STATUS.Approved ||
                                    x.Status == LEAVE_REQUEST_STATUS.Pending))
            .ToListAsync(cancellationToken);

        DaysCalculatorResponse days = request.LeaveType switch
        {
            LEAVE_TYPE.UNPAID =>
                await _calculator.CalculateDaysCalendar(request.StartDate, request.EndDate),
            _ =>
                await _calculator.CalculateDaysWorking(request.StartDate, request.EndDate)
        };
        
        OverlappingRequestResponse? overlappingRequestResponse = null;
        int? overallDays = days.DaysCount;
        
        if (employeeLeaveRequests.Any())
        {
            overlappingRequestResponse = await _calculator.OverLappingDaysCalculator(
                employeeLeaveRequests,
                request.StartDate,
                request.EndDate,
                days.DaysCount,
                request.LeaveType);
        }

        if (overlappingRequestResponse != null && overlappingRequestResponse.IsOverlapping)
            return Result<string>.Failure(ErrorResults.Conflict("შვებულების მითითებული საწყისი და ბოლო თარიღები ემთხვევა თქვენს განხილვაში მყოფ ან დამტკიცებულ დღეებს!"));
        
        if (overlappingRequestResponse != null && overlappingRequestResponse.IsCombined && !overlappingRequestResponse.IsSameType)
            return Result<string>.Failure(ErrorResults.Conflict("შვებულების მითითებული საწყისი და ბოლო თარიღები დასვენების დღეებით ებმის თქვენს განხილვაში მყოფ ან დამტკიცებულ დღეებს, რომლებსაც სხვა შვებულების ტიპი აქვთ, ამ საკითხთან დაკავშირებით დაუკავშირდით HR-ს"));

        if (overlappingRequestResponse != null && overlappingRequestResponse.IsCombined &&
            overlappingRequestResponse.IsSameType)
            overallDays = overlappingRequestResponse.CombinedDays;
        
        if(overallDays > 15 && request.LeaveType == LEAVE_TYPE.ANNUAL)
            return Result<string>.Failure(ErrorResults.Conflict("მიღწეულია ლიმიტი ყოველწლიურ ანაზღაურებად შვებულებაზე, გთხოვთ ამ საკითხთან დაკავშირებით მიმართოთ პარტნიორს ან დირექტორს"));

        int availableDays = employeeLeaveEntitlement.EntitledDays + employeeLeaveEntitlement.CarriedOverDays -
                            employeeLeaveRequests.Where(x => x.LeaveType == request.LeaveType)
                                .Sum(x => x.Days);

        if (availableDays < days.DaysCount)
        {
            switch (request.LeaveType)
            {
                case LEAVE_TYPE.SICK:
                    return Result<string>.Failure(ErrorResults.Conflict($"შვებულების დღეების დაჯავშნა შეუძლებელია {request.LeaveType} ტიპზე არასაკმარისი დღეების ბალანსის გამო! ავადმყოფობის გამო შვებულების ასაღებად დაუკავშირდით HR-ს, მითითებულია დღეები {days.DaysCount}, "));
                    break;
                default:
                    return Result<string>.Failure(ErrorResults.Conflict(
                        $"შვებულების დღეების დაჯავშნა შეუძლებელია {request.LeaveType} ტიპზე არასაკმარისი დღეების ბალანსის გამო!"));
                    break;
            }
        }

        bool isBlackOuted = false;
        if (employee.DepartmentCode == DEPARTMENT_CODE.AUD && request.LeaveType == LEAVE_TYPE.ANNUAL)
            isBlackOuted = _calculator.BlackOutPeriodMatcher(request.StartDate, request.EndDate);
        
        if (isBlackOuted)
            return Result<string>.Failure(ErrorResults.Conflict("შვებულების თარიღები ემთხვევა აუდიტის თანამშრომლის შეზღუდვის პერიოდს, HR-ასისტენტი ვერ დაგეხმარებათ მოთხოვნის შექმნაში, დახმარებისთვის მიმართეთ HR-ს"));

        var daysBefore = request.StartDate.DayNumber - today.DayNumber;

        if (request.LeaveType == LEAVE_TYPE.ANNUAL && days.DaysCount <= 5 && daysBefore < 5)
            return Result<string>.Failure(ErrorResults.Conflict($"შვებულების მოთხოვნის შექმნა ვერ შესრულდა, რადგან არ იყო გათვალისწინებული წინასწარი გაფრთხილების წესები ANNUAL შვებულებაზე: მონიშნული დღეები:{days.DaysCount}, სულ მცირე 5 დღით ადრე შესაძლებელია ANNUAL 1-დან 5 დღემდე შვებულების მოთხოვნა"));

        if (request.LeaveType == LEAVE_TYPE.ANNUAL && days.DaysCount is > 5 and <= 15 && daysBefore < 15)
            return Result<string>.Failure(ErrorResults.Conflict($"შვებულების მოთხოვნის შექმნა ვერ შესრულდა, რადგან არ იყო გათვალისწინებული წინასწარი გაფრთხილების წესები ANNUAL შვებულებაზე: მონიშნული დღეები:{days.DaysCount}, სულ მცირე 15 დღით ადრე შესაძლებელია ANNUAL 6-დან 15 დღემდე შვებულების მოთხოვნა"));

        if (request.LeaveType == LEAVE_TYPE.UNPAID && daysBefore < 10)
            return Result<string>.Failure(ErrorResults.Conflict($"შვებულების მოთხოვნის შექმნა ვერ შესრულდა, რადგან არ იყო გათვალისწინებული წინასწარი გაფრთხილების წესები UNPAID შვებულებაზე: მონიშნული დღეები:{days.DaysCount}, სულ მცირე 10 დღით ადრე შესაძლებელია UNPAID შვებულების მოთხოვნა"));

        var leaveRequestToAdd = LeaveRequest.CreateRequest(
            request.EmployeeId,
            request.LeaveType,
            request.StartDate,
            request.EndDate,
            days.DaysCount,
            LEAVE_REQUEST_STATUS.Pending,
            CREATED_VIA.HR_Assistant,
            request.Comment);

        _context.LeaveRequests.Add(leaveRequestToAdd);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success("შვებულების მოთხოვნა წარმატებით შეიქმნა!");
    }
}