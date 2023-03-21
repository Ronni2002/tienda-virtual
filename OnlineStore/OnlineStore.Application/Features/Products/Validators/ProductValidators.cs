using FluentValidation;
using OnlineStore.Application.Features.ProductPrices.Validators;
using OnlineStore.Application.Features.Products.Dto;

namespace OnlineStore.Application.Features.Products.Validators;

public class ProductValidators: AbstractValidator<ProductDto>
{
    public ProductValidators()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .WithMessage("El campo {PropertyName} es requerido.")
            .Length(2, 50)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
        
        RuleFor(c => c.Marca)
            .NotNull()
            .WithMessage("El campo {PropertyName} es requerido.")
            .Length(2, 50)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
        
        RuleForEach(x => x.ProductByPrices)
            .SetValidator(new ProductPriceValidators());
    }
}