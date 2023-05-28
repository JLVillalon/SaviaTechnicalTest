using FluentValidation;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name} can not be null")
                .NotEmpty().WithMessage("{Name} can not be empty");

            RuleFor(p => p.PartNumber)
                .NotNull().WithMessage("{PartNumber} can not be null")
                .NotEmpty().WithMessage("{PartNumber} can not be empty");
        }
    }
}
