using FluentValidation;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(p => p.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.ContactNo)
                .NotNull()
                .NotEmpty()
                .Matches(@"^(\+91[\s-]?)?[0]?[6789]\d{9}$|^\d{5}[-\s]?\d{6}$");
        }
    }
}
