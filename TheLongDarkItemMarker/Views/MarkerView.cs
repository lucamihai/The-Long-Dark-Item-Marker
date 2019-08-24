using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Views
{
    public partial class MarkerView : UserControl
    {
        public Marker Marker { get; }

        public MarkerView(Marker marker)
        {
            ValidateMarker(marker);

            InitializeComponent();

            Marker = marker;
            UpdateViewData();
        }

        [ExcludeFromCodeCoverage]
        public void UpdateViewData()
        {
            label1.Text = $"Marker name: {Marker.Name}";
        }

        private void ValidateMarker(Marker marker)
        {
            if (marker == null)
            {
                throw new ArgumentNullException();
            }

            marker.ValidateAndThrow();
        }
    }
}
