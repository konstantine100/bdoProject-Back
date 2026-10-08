using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Common.Results;
using bdoProject.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Commands.CancelRequest;

public sealed class CancelRequestHandler : IRequestHandler<CancelRequestCommand, Result<string>>
{
    private readonly IDataContext _context;

    public CancelRequestHandler(IDataContext context) => _context = context;

    public async Task<Result<string>> Handle(CancelRequestCommand request, CancellationToken cancellationToken)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);
        
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId, cancellationToken);

        if (employee == null)
            return Result<string>.Failure(ErrorResults.NotFoundMessage("თანამშრომელი ვერ მოიძებნა!"));

        var leaveRequest = await _context.LeaveRequests
            .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId &&
                                      x.Id == request.RequestId, cancellationToken);
        
        if (leaveRequest == null)
            return Result<string>.Failure(ErrorResults.NotFoundMessage("თანამშრომელის მოთხოვნა ვერ მოიძებნა!"));

        if (leaveRequest.Status == LEAVE_REQUEST_STATUS.Cancelled ||
            leaveRequest.Status == LEAVE_REQUEST_STATUS.Rejected)
            return Result<string>.Failure(
                ErrorResults.Conflict("უკვე გაუქმებული ან უარყოფილი მოთხოვნის გაუქმენა შეუძლებელია"));
        
        if (leaveRequest.Status == LEAVE_REQUEST_STATUS.Approved && leaveRequest.StartDate < today)
            return Result<string>.Failure(
                ErrorResults.Conflict("უკვე დაწყებული შვებულების გაუქმება შესაძლებელია მხოლოდ HR დეპარტამენტთან დაკავშირების შემდეგ"));

        leaveRequest.ChangeStatus(LEAVE_REQUEST_STATUS.Cancelled, "გაუქმებულია თანამშრომლის მიერ");
        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success("მოთხოვნა გაუქმებულია!");
    }
}