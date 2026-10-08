using bdoProject.Application.Contracts.DaysCalculator;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;

namespace bdoProject.Application.Features.LeaveAndAbsence.Services;

public interface IDaysCalculator
{
    Task<DaysCalculatorResponse> CalculateDaysWorking(DateOnly startDate, DateOnly endDate);
    Task<DaysCalculatorResponse> CalculateDaysCalendar(DateOnly startDate, DateOnly endDate);
    Task<OverlappingRequestResponse> OverLappingDaysCalculator(List<LeaveRequest> requests,  DateOnly startDate, DateOnly endDate, int newDays, LEAVE_TYPE leaveType);
    bool BlackOutPeriodMatcher(DateOnly startDate, DateOnly endDate);
}