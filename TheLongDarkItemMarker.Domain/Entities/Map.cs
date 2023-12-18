using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using FluentValidation;
using TheLongDarkItemMarker.Domain.Validators;

namespace TheLongDarkItemMarker.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Map
{
    private static readonly MapValidator MapValidator = new MapValidator();

    public string Name { get; set; }
    public Image Image { get; set; }
    public List<Marker> Markers { get; }

    public Map()
    {
        Markers = new List<Marker>();
    }

    public void ValidateAndThrow()
    {
        MapValidator.ValidateAndThrow(this);
    }
}