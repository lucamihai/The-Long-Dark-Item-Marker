using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Enums;

namespace TheLongDarkItemMarker.Views
{
    public partial class MarkerView : UserControl
    {
        public Marker Marker { get; }

        private ItemListView itemListView;

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

            itemListView = new ItemListView(Marker.Items, ItemListViewSelection.None);
            panelItems.Controls.Clear();
            panelItems.Controls.Add(itemListView);
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
