using bdoProject.Domain.Common.Entities;
using bdoProject.Domain.Enums;

namespace bdoProject.Domain.Entities.LeaveAndAbsence;

public class LeaveEntitlement : Entity
{
    public string EmployeeId { get; private set; }
    public int Year { get; private set; }
    public LEAVE_TYPE LeaveType { get; private set; }
    public int EntitledDays { get; private set; }
    public int CarriedOverDays { get; private set; }

    public LeaveEntitlement() { }

    public LeaveEntitlement(string employeeId, int year, LEAVE_TYPE leaveType, int entitledDays, int carriedOverDays)
    {
        EmployeeId = employeeId;
        Year = year;
        LeaveType = leaveType;
        EntitledDays = entitledDays;
        CarriedOverDays = carriedOverDays;
    }

    public void UpdateEntitledDays(int days) => EntitledDays = days;
        
}