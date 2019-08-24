using System;
using System.Drawing;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Utility;

namespace TheLongDarkItemMarker.Views
{
    public partial class MapView : UserControl
    {
        public Color MarkerColor { get; set; } = Color.Black;

        private ContextMenuStrip contextMenuStrip;
        private Point rightClickLocation;

        private PictureBox pictureBox;
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

        private Panel panelMap;

        public MapView(Map map)
        {
            ValidateMap(map);

            InitializeComponent();
            InitializeContextMenuStrip();
            InitializePanelMap();

            this.Controls.Add(panelMap);

            Map = map;
            ZoomFactor = UtilityMethods.GetZoomFactorForImageToFitInSpecifiedSize(Map.Image, panelMap.Size);
        }

        public void ForceDraw()
        {
            DisplayMap();
            pictureBox.Refresh();
        }

        private void ValidateMap(Map map)
        {
            if (map == null)
            {
                throw new ArgumentNullException();
            }

            map.ValidateAndThrow();
        }

        private void InitializeContextMenuStrip()
        {
            var toolStripMenuItemCreateMarker = new ToolStripMenuItem();
            toolStripMenuItemCreateMarker.Text = "Create marker here";
            toolStripMenuItemCreateMarker.Click += ToolStripMenuItemCreateMarkerOnClick;

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add(toolStripMenuItemCreateMarker);
        }

        private void ToolStripMenuItemCreateMarkerOnClick(object sender, EventArgs e)
        {
            var xPercentage = (rightClickLocation.X * 100) / pictureBox.Image.Size.Width;
            var yPercentage = (rightClickLocation.Y * 100) / pictureBox.Image.Size.Height;

            var marker = new Marker {Name = "Name", XPositionPercentage = xPercentage, YPositionPercentage = yPercentage};
            Map.Markers.Add(marker);

            pictureBox.Refresh();
        }

        private void InitializePanelMap()
        {
            panelMap = new Panel();
            panelMap.Size = this.Size;
            panelMap.AutoScroll = true;
        }

        private void DisplayMap()
        {
            var currentHorizontalScrollPercentage = GetCurrentHorizontalScrollPercentage();
            var currentVerticalScrollPercentage = GetCurrentVerticalScrollPercentage();

            var image = UtilityMethods.GetZoomedImage(Map.Image, ZoomFactor);
            pictureBox = new PictureBox {Size = image.Size, Image = image};
            pictureBox.MouseDown += PictureBoxOnMouseDown;
            pictureBox.ContextMenuStrip = contextMenuStrip;
            pictureBox.Paint += PictureBoxOnPaint;

            panelMap.Controls.Clear();
            panelMap.Controls.Add(pictureBox);

            ScrollHorizontally(currentHorizontalScrollPercentage);
            ScrollVertically(currentVerticalScrollPercentage);

            panelMap.PerformLayout();
            pictureBox.Refresh();
        }

        private void PictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            DrawMarkers(e);
        }

        private void DrawMarkers(PaintEventArgs e)
        {
            foreach (var marker in Map.Markers)
            {
                var position = new Point
                {
                    X = (int) (pictureBox.Image.Width * marker.XPositionPercentage) / 100,
                    Y = (int) (pictureBox.Image.Height * marker.YPositionPercentage) / 100
                };

                var rectangle = new Rectangle(position, new Size(5, 5));
                using (var pen = new Pen(MarkerColor))
                {
                    e.Graphics.DrawRectangle(pen, rectangle);
                }
            }
        }

        private void PictureBoxOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightClickLocation = e.Location;
            }
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
