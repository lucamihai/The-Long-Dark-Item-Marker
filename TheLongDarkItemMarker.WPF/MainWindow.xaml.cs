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
        // TODO: Make this a parameter for the component
        // TODO: Investigate behaviour for different X and Y sizes
        private const double BorderSize = 1000;

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

        private double zoomScale = 1;
        private void image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            TransformGroup transformGroup = (TransformGroup)mapImage.RenderTransform;
            ScaleTransform transform = (ScaleTransform)transformGroup.Children[0];

            double zoom = e.Delta > 0 ? .2 : -.2;

            if (zoom + zoomScale < 1)
            {
                return;
            }

            // TODO: Zoom in toward the mouse position

            transform.ScaleX += zoom;
            transform.ScaleY += zoom;

            zoomScale = transform.ScaleX;

            var isZoomOut = zoom < 0;
            if (isZoomOut)
            {
                EnsureImageDoesNotGoOutsideBorders();
            }
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
                Vector v = start - e.GetPosition(border);
                EnsureImageDoesNotGoOutsideBorders(newPositionX: origin.X - v.X, newPositionY: origin.Y - v.Y);
            }
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mapImage.ReleaseMouseCapture();
        }

        private void EnsureImageDoesNotGoOutsideBorders(double? newPositionX = null, double? newPositionY = null)
        {
            var tt = (TranslateTransform)((TransformGroup)mapImage.RenderTransform).Children.First(tr => tr is TranslateTransform);
            var zoomedDifference = zoomScale - 1;
            var clampLimit = BorderSize * zoomedDifference / 2;

            tt.X = Clamp(newPositionX ?? tt.X, min: -clampLimit, max: clampLimit);
            tt.Y = Clamp(newPositionY ?? tt.Y, min: -clampLimit, max: clampLimit);
        }

        private static double Clamp(double value, double min, double max)
        {
            if (value < min)
            {
                return min;
            }

            if (value > max)
            {
                return max;
            }

            return value;
        }
    }
}