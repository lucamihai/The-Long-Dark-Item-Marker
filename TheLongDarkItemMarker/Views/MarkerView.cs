using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
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
            textBoxMarkerName.Text = $"{Marker.Name}";

            DisplayItems();
        }

        private void ValidateMarker(Marker marker)
        {
            if (marker == null)
            {
                throw new ArgumentNullException();
            }

            marker.ValidateAndThrow();
        }

        [ExcludeFromCodeCoverage]
        private void DisplayItems()
        {
            for (int index = 0; index < Marker.Items.Count; index++)
            {
                var itemView = new ItemView(Marker.Items[index]);
                itemView.Location = new Point(0, (index * itemView.Height) + 10);
                itemView.BorderStyle = BorderStyle.FixedSingle;

                panelItems.Controls.Add(itemView);
            }
        }
    }
}
