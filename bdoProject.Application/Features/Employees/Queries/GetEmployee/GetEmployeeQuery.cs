using bdoProject.Domain.Common.Results;
using bdoProject.Domain.Entities.Employees;
using MediatR;

namespace bdoProject.Application.Features.Employees.Queries.GetEmployee;

public sealed record GetEmployeeQuery(string  EmployeeId) : IRequest<IQueryable<Employee>>;