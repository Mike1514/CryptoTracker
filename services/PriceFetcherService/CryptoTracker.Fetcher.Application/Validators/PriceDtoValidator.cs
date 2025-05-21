using CryptoTracker.Fetcher.Application.DTOs;
using FluentValidation;

namespace CryptoTracker.Fetcher.Application.Validators;

public class PriceDtoValidator : AbstractValidator<PriceDto>
{
    public PriceDtoValidator()
    {
        RuleFor(x => x.Time).NotEmpty();
        RuleFor(x => x.Value).GreaterThan(0)
            .WithMessage("The price should be grater than 0");
    }
}
