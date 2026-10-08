using bdoProject.Domain.Entities.LeaveAndAbsence;

namespace bdoProject.Api.Projection.GraphQL.LeaveTypes;

public class LeaveTypesType: ObjectType<LeaveType>
{
    protected override void Configure(IObjectTypeDescriptor<LeaveType> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.LeaveTypes);
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.DayUnit);
        descriptor.Field(x => x.AnnualLimitDays);
        descriptor.Field(x => x.SelfService);
        descriptor.Field(x => x.AssistantSupported);
        descriptor.Field(x => x.PolicyReference);
    }
}