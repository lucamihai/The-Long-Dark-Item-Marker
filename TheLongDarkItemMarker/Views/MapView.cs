using System;
using System.Drawing;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Utility;

namespace TheLongDarkItemMarker.Views
{
    public partial class MapView : UserControl
    {
        public Map Map { get; }

        private float zoomFactor;
        public float ZoomFactor
        {
            get => zoomFactor;
            set
            {
                zoomFactor = value;
                DisplayMap();
            }
        }

        private readonly Panel panelMap;

        public MapView(Map map)
        {
            ValidateMap(map);

            InitializeComponent();
            panelMap = new Panel();
            panelMap.Size = this.Size;
            panelMap.AutoScroll = true;
            this.Controls.Add(panelMap);

            Map = map;

            ZoomFactor = UtilityMethods.GetZoomFactorForImageToFitInSpecifiedSize(Map.Image, panelMap.Size);

            DisplayMap();
        }

        private void ValidateMap(Map map)
        {
            if (map == null)
            {
                throw new ArgumentNullException();
            }

            map.ValidateAndThrow();
        }

        private void DisplayMap()
        {
            var image = UtilityMethods.GetZoomedImage(Map.Image, ZoomFactor);
            var pictureBox = new PictureBox {Size = image.Size, Image = image};
            panelMap.Controls.Clear();
            panelMap.Controls.Add(pictureBox);
        }

        
    }
}
