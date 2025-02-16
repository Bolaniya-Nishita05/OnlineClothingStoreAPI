using FluentValidation;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Validators
{
    public class BrandValidator : AbstractValidator<BrandModel>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(b => b.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
