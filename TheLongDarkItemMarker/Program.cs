using TheLongDarkItemMarker.Forms;

namespace TheLongDarkItemMarker;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        StaticViews.Initialize();
        Application.Run(new MainWindow());
    }
}