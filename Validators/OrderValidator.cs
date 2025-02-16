using FluentValidation;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Validators
{
    public class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator()
        {
            RuleFor(o => o.ProductID)
                .NotNull()
                .NotEmpty();

            RuleFor(o => o.UserID)
                .NotNull()
                .NotEmpty();

            RuleFor(o => o.Quantity)
                .NotNull()
                .NotEmpty();

            RuleFor(o => o.TotalAmount)
                .NotNull()
                .NotEmpty();
        }
    }
}
