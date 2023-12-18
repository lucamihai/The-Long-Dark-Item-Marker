using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Domain.Validators;

[ExcludeFromCodeCoverage]
public class MapValidator : AbstractValidator<Map>
{
    public MapValidator()
    {
        ValidateName();
        ValidateImage();
    }

    private void ValidateName()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }

    private void ValidateImage()
    {
        RuleFor(x => x.Image)
            .NotNull();
    }
}