namespace bdoProject.Application.Contracts.DaysCalculator;

public sealed record DaysCalculatorResponse
(
    int DaysCount,
    string? Message
);