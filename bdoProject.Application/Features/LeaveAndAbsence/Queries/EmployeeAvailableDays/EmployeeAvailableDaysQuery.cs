using bdoProject.Application.Contracts.LeaveAndAbsence;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeAvailableDays;

public sealed record EmployeeAvailableDaysQuery
(
    string EmployeeId
) : IRequest<IReadOnlyList<EmployeeAvailableDaysRequest>>;