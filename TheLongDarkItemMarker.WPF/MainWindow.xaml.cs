using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheLongDarkItemMarker.Settings;
using Path = System.IO.Path;

namespace TheLongDarkItemMarker.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var a = new Uri(Path.Combine($"file://{Environment.CurrentDirectory}/Resources/MysteryLake.jpg"));

            //mapImage.Source = new BitmapImage(new Uri("file://Resources/MysteryLake.jpg"));
            //mapImage.Source = new BitmapImage(new Uri(Path.Combine("Resources", "MysteryLake.jpg")));
            mapImage.Source = new BitmapImage(a);

            TransformGroup group = new TransformGroup();

            ScaleTransform xform = new ScaleTransform();
            group.Children.Add(xform);

            TranslateTransform tt = new TranslateTransform();
            group.Children.Add(tt);

            mapImage.RenderTransform = group;
        }

        private void image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            TransformGroup transformGroup = (TransformGroup)mapImage.RenderTransform;
            ScaleTransform transform = (ScaleTransform)transformGroup.Children[0];

            double zoom = e.Delta > 0 ? .2 : -.2;
            transform.ScaleX += zoom;
            transform.ScaleY += zoom;
        }

        Point start;
        Point origin;
        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mapImage.CaptureMouse();

            var tt = (TranslateTransform)((TransformGroup)mapImage.RenderTransform).Children.First(tr => tr is TranslateTransform);

            start = e.GetPosition(border);
            origin = new Point(tt.X, tt.Y);
        }

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (mapImage.IsMouseCaptured)
            {
                var tt = (TranslateTransform)((TransformGroup)mapImage.RenderTransform).Children.First(tr => tr is TranslateTransform);
                Vector v = start - e.GetPosition(border);
                tt.X = origin.X - v.X;
                tt.Y = origin.Y - v.Y;
            }
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mapImage.ReleaseMouseCapture();
        }
    }
}