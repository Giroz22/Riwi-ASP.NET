using FluentValidation;
using RWFormsApi.API.DTOs.Request;

namespace RWFormsApi.API.Validations;

public class UserValidator : AbstractValidator<UserRequest>
{
    public UserValidator()
    {
        RuleFor(u => u.Names)
            .NotEmpty().WithMessage("The Name is required");

        RuleFor(u=>u.Email)
            .NotEmpty().WithMessage("The email is required")
            .EmailAddress().WithMessage("The email format is invalid");
    }
}