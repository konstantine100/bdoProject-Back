using bdoProject.Domain.Common.Entities;
using bdoProject.Domain.Enums;

namespace bdoProject.Domain.Entities.LeaveAndAbsence;

public class LeaveType : Entity
{
    public LEAVE_TYPE LeaveTypes { get; private set; }
    public string Name { get; private set; }
    public DAY_UNIT DayUnit { get; private set; }
    public int? AnnualLimitDays { get; private set; }
    public int SelfService { get; private set; }
    public int AssistantSupported { get; private set; }
    public string PolicyReference { get; private set; }

    public LeaveType() { }

    public LeaveType(LEAVE_TYPE leaveTypes, string name, DAY_UNIT dayUnit, int? annualLimitDays, int selfService, int assistantSupported, string policyReference)
    {
        LeaveTypes = leaveTypes;
        Name = name;
        DayUnit = dayUnit;
        AnnualLimitDays = annualLimitDays;
        SelfService = selfService;
        AssistantSupported = assistantSupported;
        PolicyReference = policyReference;
    }
}