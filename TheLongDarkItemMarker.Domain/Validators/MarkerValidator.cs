using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Domain.Validators
{
    [ExcludeFromCodeCoverage]
    public class MarkerValidator : AbstractValidator<Marker>
    {
        public MarkerValidator()
        {
            ValidateName();
            ValidateXPositionPercentage();
            ValidateYPositionPercentage();
        }

        private void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }

        private void ValidateXPositionPercentage()
        {
            RuleFor(x => x.XPositionPercentage)
                .GreaterThanOrEqualTo(0);
        }

        private void ValidateYPositionPercentage()
        {
            RuleFor(x => x.YPositionPercentage)
                .GreaterThanOrEqualTo(0);
        }
    }
}
