using FluentValidation;
using OnlineStore.Application.Features.ProductPrices.Dto;

namespace OnlineStore.Application.Features.ProductPrices.Validators;

public class ProductPriceValidators : AbstractValidator<ProductPriceDto>
{
    public ProductPriceValidators()
    {
        RuleFor(c => c.Color)
            .NotNull()
            .WithMessage("El campo {PropertyName} es requerido.")
            .Length(2, 50)
            .WithMessage(
                "{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

        RuleFor(c => c.Cost)
            .NotNull()
            .NotEmpty()
            .WithMessage("El campo {PropertyName} es requerido.");
    }
}