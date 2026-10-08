using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.Employees.Queries.AllEmployees;

public sealed class AllEmployeesHandler : IRequestHandler<AllEmployeesQuery, IQueryable<Employee>>
{
    private readonly IDataContext _context;

    public AllEmployeesHandler(IDataContext context) => _context = context;

    public Task<IQueryable<Employee>> Handle(AllEmployeesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Employee> query = _context.Employees
            .OrderByDescending(x => x.CreatedAt).AsNoTracking();
        
        return Task.FromResult(query);
    }
}