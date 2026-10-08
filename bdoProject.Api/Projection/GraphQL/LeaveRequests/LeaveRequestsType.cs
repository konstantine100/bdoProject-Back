using bdoProject.Domain.Entities.LeaveAndAbsence;

namespace bdoProject.Api.Projection.GraphQL.LeaveRequests;

public class LeaveRequestsType : ObjectType<LeaveRequest>
{
    protected override void Configure(IObjectTypeDescriptor<LeaveRequest> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.EmployeeId);
        descriptor.Field(x => x.LeaveType);
        descriptor.Field(x => x.StartDate);
        descriptor.Field(x => x.EndDate);
        descriptor.Field(x => x.Days);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Comment);
        descriptor.Field(x => x.CreatedVia);
        descriptor.Field(x => x.CreatedAt);
    }
}