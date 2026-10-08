using bdoProject.Domain.Entities.Employees;

namespace bdoProject.Application.Interfaces.Security;

public interface IJwtService
{
    string GenerateAccessToken(Employee user);
}