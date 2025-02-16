using FluentValidation;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryModel>
    {
        public CategoryValidator() {
            RuleFor(c => c.CategoryName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(c => c.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
