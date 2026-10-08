using bdoProject.Domain.Enums;

namespace bdoProject.Application.Contracts.LeaveAndAbsence;

public sealed class EmployeeAvailableDaysRequest
{
    public string EmployeeId { get; set; } = string.Empty;
    public LEAVE_TYPE LeaveType { get; set; } 
    public int AvailableDays { get; set; } 
}