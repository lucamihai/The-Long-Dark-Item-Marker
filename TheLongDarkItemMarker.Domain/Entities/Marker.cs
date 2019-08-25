using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using TheLongDarkItemMarker.Domain.Validators;

namespace TheLongDarkItemMarker.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Marker
    {
        private static readonly MarkerValidator MarkerValidator = new MarkerValidator();

        public string Name { get; set; }
        public float XPositionPercentage { get; set; }
        public float YPositionPercentage { get; set; }

        public List<Item> Items { get; }

        public Marker()
        {
            Items = new List<Item>();
        }

        public void ValidateAndThrow()
        {
            MarkerValidator.ValidateAndThrow(this);
        }
    }
}
