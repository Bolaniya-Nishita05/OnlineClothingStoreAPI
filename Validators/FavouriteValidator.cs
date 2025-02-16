using FluentValidation;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Validators
{
    public class FavouriteValidator : AbstractValidator<FavouriteModel>
    {
        public FavouriteValidator()
        {
            RuleFor(f => f.ProductID)
                .NotNull()
                .NotEmpty();

            RuleFor(f => f.UserID)
                .NotNull()
                .NotEmpty();
        }
    }
}
