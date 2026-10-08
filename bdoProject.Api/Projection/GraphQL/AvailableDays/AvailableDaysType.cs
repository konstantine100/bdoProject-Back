using bdoProject.Application.Contracts.LeaveAndAbsence;

namespace bdoProject.Api.Projection.GraphQL.AvailableDays;

public class AvailableDaysType : ObjectType<EmployeeAvailableDaysRequest>
{
    protected override void Configure(IObjectTypeDescriptor<EmployeeAvailableDaysRequest> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.EmployeeId);
        descriptor.Field(x => x.LeaveType);
        descriptor.Field(x => x.AvailableDays);
    }
}