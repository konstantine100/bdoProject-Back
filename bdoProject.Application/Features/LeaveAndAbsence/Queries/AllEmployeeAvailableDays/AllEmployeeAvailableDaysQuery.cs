using bdoProject.Application.Contracts.LeaveAndAbsence;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.AllEmployeeAvailableDays;

public sealed record AllEmployeeAvailableDaysQuery() : IRequest<IReadOnlyList<EmployeeAvailableDaysRequest>>;