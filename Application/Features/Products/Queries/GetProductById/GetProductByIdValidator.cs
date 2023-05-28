using FluentValidation;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{Id} can not be null");
        }
    }
}
