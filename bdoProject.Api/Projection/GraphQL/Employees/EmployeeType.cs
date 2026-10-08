using bdoProject.Domain.Entities.Employees;

namespace bdoProject.Api.Projection.GraphQL.Employees;

public class EmployeeType : ObjectType<Employee>
{
    protected override void Configure(IObjectTypeDescriptor<Employee> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.EmployeeId);
        descriptor.Field(x => x.FullName);
        descriptor.Field(x => x.Email);
        descriptor.Field(x => x.DepartmentCode);
        descriptor.Field(x => x.DepartmentName);
        descriptor.Field(x => x.JobTitle);
        descriptor.Field(x => x.EmploymentType);
        descriptor.Field(x => x.StartDate);
        descriptor.Field(x => x.ProbationEndDate);
        descriptor.Field(x => x.ManagerId);
        descriptor.Field(x => x.Status);
    }
}