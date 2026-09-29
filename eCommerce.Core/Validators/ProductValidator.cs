using eCommerce.Core.Domain.Entities;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class ProductValidator : AbstractValidator<Product> 
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName)
            .NotNull().WithMessage("Product name cant be null")
            .MaximumLength(20).WithMessage("Please write correct name");
    }
} 