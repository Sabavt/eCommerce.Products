using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class ProductDTOValidator : AbstractValidator<ProductDTO>
{
    public ProductDTOValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("Name cant be blank");

        RuleFor(p => p.Category)
            .NotEmpty().WithMessage("Name cant be blank")
            .IsInEnum();

        RuleFor(p => p.Price)
           .InclusiveBetween(0, 1000000).WithMessage("Incorrect price, please try again");

        RuleFor(p => p.Quantity)
          .InclusiveBetween(0, 1000000).WithMessage("Incorrect quantity, please try again");
    }
}
