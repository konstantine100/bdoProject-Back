using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeLeaveRequest;

public sealed record EmployeeLeaveRequestQuery(string EmployeeId) : IRequest<IQueryable<LeaveRequest>>;
