using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.Employees.Queries.GetEmployee;

public sealed class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, IQueryable<Employee>>
{
    private readonly IDataContext _context;

    public GetEmployeeQueryHandler(IDataContext context) => _context = context;

    public Task<IQueryable<Employee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Employee> query = _context.Employees
            .Where(x => x.EmployeeId == request.EmployeeId).AsNoTracking();

        return Task.FromResult(query);
    }
}