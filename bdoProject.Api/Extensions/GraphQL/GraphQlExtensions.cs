using bdoProject.Api.Filters;
using bdoProject.Api.Projection.GraphQL.AvailableDays;
using bdoProject.Api.Projection.GraphQL.Employees;
using bdoProject.Api.Projection.GraphQL.Holidays;
using bdoProject.Api.Projection.GraphQL.LeaveEntitlements;
using bdoProject.Api.Projection.GraphQL.LeaveRequests;
using bdoProject.Api.Projection.GraphQL.LeaveTypes;

namespace bdoProject.Api.Extensions.GraphQL;

public static class GraphQlExtensions
{
    public static IServiceCollection AddGraphQlConfiguration(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .ModifyRequestOptions(opt =>
            {
                opt.IncludeExceptionDetails = true;
                opt.ExecutionTimeout = TimeSpan.FromMinutes(5);
            })
            .ModifyPagingOptions(opt => opt.IncludeTotalCount = true)
            .AddErrorFilter<GraphQlErrorFilter>()
            .AddPagingArguments()
            .AddAuthorization()
            .AddProjections()
            .AddFiltering()
            .AddQueryType()
            .AddSorting()
            .AddMaxExecutionDepthRule(maxAllowedExecutionDepth: 15)
            .AddTypeExtension<HolidaysQueries>()
            .AddType<HolidayType>()
            .AddTypeExtension<EmployeeQueries>()
            .AddType<EmployeeType>()
            .AddTypeExtension<LeaveEntitlementQueries>()
            .AddType<LeaveEntitlementType>()
            .AddTypeExtension<AvailableDaysQueries>()
            .AddType<AvailableDaysType>()
            .AddTypeExtension<LeaveTypeQueries>()
            .AddType<LeaveTypesType>()
            .AddTypeExtension<LeaveRequestsQueries>()
            .AddType<LeaveRequestsType>();
            
        
        return services;
    }
}