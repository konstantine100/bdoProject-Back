using FluentValidation;

namespace bdoProject.Application.Features.LeaveAndAbsence.Commands.AnswerRequest;

public sealed class AnswerRequestValidator : AbstractValidator<AnswerRequestCommand>
{
    public AnswerRequestValidator()
    {
        RuleFor(x => x.Message)
            .Length(10, 200).WithMessage("შეტყობინება უნდა შეიცავდეს 10დან 200 სიმბოლომდე!");
    }
}