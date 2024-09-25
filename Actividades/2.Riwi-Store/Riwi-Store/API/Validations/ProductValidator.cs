using FluentValidation;
using RiwiStore.DTO;

public class ProductValidator : AbstractValidator<ProductRequest>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The name is required");

        RuleFor(p=>p.Price)
            .NotNull().WithMessage("Price is required")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0");
    }
}