using FluentValidation;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Validators
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(p => p.CategoryID)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.BrandID)
                .NotNull()
                .NotEmpty();

            RuleFor(p=> p.Price)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.StockQuantity)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Size)
                .NotNull()
                .NotEmpty()
                .MaximumLength(3);

            RuleFor(p => p.Color)
                .NotNull()
                .NotEmpty();
        }
    }
}
