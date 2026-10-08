using bdoProject.Domain.Enums;
using FluentValidation;

namespace bdoProject.Application.Features.LeaveAndAbsence.Commands.AssistantLeaveRequestCreate;

public sealed class AssistantLeaveRequestCreateValidator : AbstractValidator<AssistantLeaveRequestCreateCommand>
{
    public AssistantLeaveRequestCreateValidator()
    {
        RuleFor(x => x.LeaveType)
            .Must(y => y != LEAVE_TYPE.BEREAVEMENT && y != LEAVE_TYPE.STUDY && y != LEAVE_TYPE.PARENTAL)
            .WithMessage("მოცემულ შვებულების ტიპზე ასისტენს არ შეუძლია მოთხოვნის შექმნა, გთხოვთ ეწვიოთ პორტალს");
        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("გთხოვთ მიუთითოთ შვებულების დაწყების თარიღი მომავალში")
            .LessThanOrEqualTo(new DateOnly(2027, 12, 31))
            .WithMessage("მაქსიმალური მისათითებელი შვებულების დაწყების თარიღია 31/12/2027")
            .When(x => x.LeaveType != LEAVE_TYPE.SICK);
        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(new DateOnly(2026, 1, 1))
            .WithMessage("გთხოვთ მიუთითოთ შვებულების დაწყების თარიღი მიმდინარე წლის განმავლობაში")
            .LessThanOrEqualTo(new DateOnly(2027, 12, 31))
            .WithMessage("მაქსიმალური მისათითებელი შვებულების დაწყების თარიღია 31/12/2027")
            .When(x => x.LeaveType == LEAVE_TYPE.SICK);
        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("შვებულების დასრულების დღე უნდა აღემატებოდეს დაწყების თარიღს");
        RuleFor(x => x.Comment)
            .Length(1, 100).WithMessage("შესაძლო კომენტარის სიგრძე არ უნდა აღემატებოდეს 100 სიმბოლოს")
            .When(x => x.Comment != null);

    }
}