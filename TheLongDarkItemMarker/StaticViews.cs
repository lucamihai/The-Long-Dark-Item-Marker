using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker;

public static class StaticViews
{
    public static void Initialize()
    {
        AddItemView = new AddItemView();
    }

    public static AddItemView AddItemView { get; private set; }
}