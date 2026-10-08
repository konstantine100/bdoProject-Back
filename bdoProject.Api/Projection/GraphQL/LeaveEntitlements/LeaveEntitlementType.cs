using bdoProject.Domain.Entities.LeaveAndAbsence;

namespace bdoProject.Api.Projection.GraphQL.LeaveEntitlements;

public class LeaveEntitlementType : ObjectType<LeaveEntitlement>
{
    protected override void Configure(IObjectTypeDescriptor<LeaveEntitlement> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.EmployeeId);
        descriptor.Field(x => x.Year);
        descriptor.Field(x => x.LeaveType);
        descriptor.Field(x => x.EntitledDays);
        descriptor.Field(x => x.CarriedOverDays);
    }
}