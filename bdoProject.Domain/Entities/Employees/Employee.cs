using bdoProject.Domain.Common.Entities;
using bdoProject.Domain.Enums;

namespace bdoProject.Domain.Entities.Employees;

public class Employee : Entity
{
    public string EmployeeId { get; private set; } 
    public string FullName { get; private set; } 
    public string Email { get; private set; } 
    public DEPARTMENT_CODE DepartmentCode { get; private set; } 
    public string DepartmentName { get; private set; } 
    public string JobTitle { get; private set; } 
    public EMPLOYMENT_TYPE EmploymentType { get; private set; } 
    public DateOnly StartDate { get; private set; } 
    public DateOnly ProbationEndDate { get; private set; } 
    public string? ManagerId  { get; private set; }
    public EMPLOYMENT_STATUS Status { get; private set; }
    public EMPLOYEE_ROLE Role { get; private set; }

    public Employee() { }

    public Employee(string employeeId, string fullName, string email, DEPARTMENT_CODE departmentCode, string departmentName, string jobTitle, EMPLOYMENT_TYPE employmentType, DateOnly startDate, DateOnly probationEndDate, string? managerId, EMPLOYMENT_STATUS status, EMPLOYEE_ROLE role)
    {
        EmployeeId = employeeId;
        FullName = fullName;
        Email = email;
        DepartmentCode = departmentCode;
        DepartmentName = departmentName;
        JobTitle = jobTitle;
        EmploymentType = employmentType;
        StartDate = startDate;
        ProbationEndDate = probationEndDate;
        ManagerId = managerId;
        Status = status;
        Role = role;
    }
}