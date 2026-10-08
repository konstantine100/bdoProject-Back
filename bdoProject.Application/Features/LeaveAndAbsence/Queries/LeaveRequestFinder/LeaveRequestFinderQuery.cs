using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.LeaveRequestFinder;

public sealed record LeaveRequestFinderQuery
(
    List<LEAVE_TYPE>? LeaveTypes,
    DateOnly? StartDate,
    DateOnly? EndDate,
    int? MinDays,
    int? MaxDays,
    List<LEAVE_REQUEST_STATUS>? LeaveRequestStatuses,
    List<CREATED_VIA>? CreatedVia,
    SORTING? Sorting,
    string? EmployeeId
) : IRequest<IQueryable<LeaveRequest>>;