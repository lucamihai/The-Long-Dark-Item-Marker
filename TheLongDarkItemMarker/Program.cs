using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace TheLongDarkItemMarker
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
