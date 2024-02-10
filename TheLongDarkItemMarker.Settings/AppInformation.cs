using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.Settings;

[ExcludeFromCodeCoverage]
public static class AppInformation
{

    public const string About = 
@"The Long Dark Item Marker is an application made purely for fun purposes.
I did not earn any money making this, and I'm not making any money if this application is used.

The Long Dark is a survival game developed by Hinterland Games (https://hinterlandgames.com).
The creators of the maps I've used can be seen in each map.

More details can be found on the Github page of the project: https://github.com/lucamihai/The-Long-Dark-Item-Marker
";

    // TODO: Currently not working, investigate why
    public const string HelpWebPageUrl = "https://lucamihai.github.io/The-Long-Dark-Item-Marker-Wep-Page/";
}