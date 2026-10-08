using bdoProject.Domain.Common.Entities;
using bdoProject.Domain.Enums;

namespace bdoProject.Domain.Entities.LeaveAndAbsence;

public class LeaveRequest : Entity
{
    public string EmployeeId { get; private set; }
    public LEAVE_TYPE LeaveType { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public int Days { get; private set; }
    public LEAVE_REQUEST_STATUS Status { get; private set; }
    public CREATED_VIA CreatedVia { get; private set; }
    public string? Comment { get; private set; }

    public LeaveRequest() { }

    public LeaveRequest(string employeeId, LEAVE_TYPE leaveType, DateOnly startDate, DateOnly endDate, int days, LEAVE_REQUEST_STATUS status, CREATED_VIA createdVia, string? comment)
    {
        EmployeeId = employeeId;
        LeaveType = leaveType;
        StartDate = startDate;
        EndDate = endDate;
        Days = days;
        Status = status;
        CreatedVia = createdVia;
        Comment = comment;
    }

    public static LeaveRequest CreateRequest(string employeeId, LEAVE_TYPE leaveType, DateOnly startDate,
        DateOnly endDate, int days, LEAVE_REQUEST_STATUS status, CREATED_VIA createdVia, string? comment)
    {
        return new LeaveRequest(employeeId, leaveType, startDate, endDate, days, status, createdVia, comment);
    }

    public void ChangeStatus(LEAVE_REQUEST_STATUS status, string? comment)
    {
        Status = status;
        Comment = comment;
    }
    
}