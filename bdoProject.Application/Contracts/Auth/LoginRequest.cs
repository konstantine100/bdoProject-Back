namespace bdoProject.Application.Contracts.Auth;

public sealed class LoginRequest
{
    public string Email { get; set; } = null!;
    public string EmployeeId { get; set; } = null!;
}