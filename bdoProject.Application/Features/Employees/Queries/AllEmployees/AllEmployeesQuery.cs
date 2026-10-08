using bdoProject.Domain.Entities.Employees;
using MediatR;

namespace bdoProject.Application.Features.Employees.Queries.AllEmployees;

public sealed record AllEmployeesQuery() : IRequest<IQueryable<Employee>>;