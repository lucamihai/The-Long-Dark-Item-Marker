using System;
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
            var currentHorizontalScrollPercentage = GetCurrentHorizontalScrollPercentage();
            var currentVerticalScrollPercentage = GetCurrentVerticalScrollPercentage();

            var image = UtilityMethods.GetZoomedImage(Map.Image, ZoomFactor);
            var pictureBox = new PictureBox {Size = image.Size, Image = image};
            panelMap.Controls.Clear();
            panelMap.Controls.Add(pictureBox);

            ScrollHorizontally(currentHorizontalScrollPercentage);
            ScrollVertically(currentVerticalScrollPercentage);

            panelMap.PerformLayout();
        }

        private float GetCurrentHorizontalScrollPercentage()
        {
            var currentScrollValue = panelMap.HorizontalScroll.Value;
            var maximumScrollValue = panelMap.HorizontalScroll.Maximum;
            var percentageScrolled = (currentScrollValue * 100) / (float)maximumScrollValue;

            return percentageScrolled;
        }

        private float GetCurrentVerticalScrollPercentage()
        {
            var currentScrollValue = panelMap.VerticalScroll.Value;
            var maximumScrollValue = panelMap.VerticalScroll.Maximum;
            var percentageScrolled = (currentScrollValue * 100) / (float)maximumScrollValue;

            return percentageScrolled;
        }

        private void ScrollHorizontally(float scrollPercentage)
        {
            if (float.IsInfinity(scrollPercentage))
            {
                return;
            }

            var maximumScrollValue = panelMap.HorizontalScroll.Maximum;
            var valueToScroll = (int)(Math.Round(scrollPercentage * maximumScrollValue))/100;

            panelMap.HorizontalScroll.Value = valueToScroll;
        }

        private void ScrollVertically(float scrollPercentage)
        {
            if (float.IsInfinity(scrollPercentage))
            {
                return;
            }

            var maximumScrollValue = panelMap.VerticalScroll.Maximum;
            var valueToScroll = (int)(Math.Round(scrollPercentage * maximumScrollValue))/100;

            panelMap.VerticalScroll.Value = valueToScroll;
        }
    }
}
