using bdoProject.Domain.Entities.LeaveAndAbsence;

namespace bdoProject.Application.Contracts.DaysCalculator;

public sealed record OverlappingRequestResponse
(
    bool IsOverlapping,
    bool IsCombined,
    bool IsSameType,
    int? CombinedDays
);