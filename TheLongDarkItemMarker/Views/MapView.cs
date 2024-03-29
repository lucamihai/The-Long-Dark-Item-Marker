﻿using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Forms;
using TheLongDarkItemMarker.Utility;

namespace TheLongDarkItemMarker.Views;

public partial class MapView : UserControl
{
    [ExcludeFromCodeCoverage]
    public Color MarkerInactiveColor { get; set; } = Color.Orange;

    [ExcludeFromCodeCoverage]
    public Color MarkerActiveColor { get; set; } = Color.DarkGreen;

    [ExcludeFromCodeCoverage]
    public Size MarkerSize { get; set; } = new Size(10, 10);

    private Marker activeMarker;

    private ContextMenuStrip contextMenuStrip;
    private Point rightClickLocation;

    private PictureBox pictureBox;
    public Map Map { get; }

    private readonly float zoomFactorMinimumValue;
    private float zoomFactor;
    public float ZoomFactor
    {
        get => zoomFactor;
        set
        {
            zoomFactor = value < zoomFactorMinimumValue 
                ? zoomFactorMinimumValue 
                : value;

            DisplayMap();
        }
    }

    private int displaysMade = 0;

    public delegate void MarkerClicked(Marker clickedMarker);
    [ExcludeFromCodeCoverage]
    public MarkerClicked OnMarkerClicked { get; set; } = clickedMarker => { };

    private Panel panelMap;

    public MapView(Map map)
    {
        ValidateMap(map);

        InitializeComponent();
        InitializeContextMenuStrip();
        InitializePanelMap();

        this.Controls.Add(panelMap);

        Map = map;

        var zoomFactorForImageToFitInPanel = UtilityMethods.GetZoomFactorForImageToFitInSpecifiedSize(Map.Image, panelMap.Size);
        ZoomFactor = zoomFactorForImageToFitInPanel;
        zoomFactorMinimumValue = zoomFactorForImageToFitInPanel;
    }

    [ExcludeFromCodeCoverage]
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

    [ExcludeFromCodeCoverage]
    private void InitializeContextMenuStrip()
    {
        var toolStripMenuItemCreateMarker = new ToolStripMenuItem();
        toolStripMenuItemCreateMarker.Text = "Create marker here";
        toolStripMenuItemCreateMarker.Click += ToolStripMenuItemCreateMarkerOnClick;

        contextMenuStrip = new ContextMenuStrip();
        contextMenuStrip.Items.Add(toolStripMenuItemCreateMarker);
    }

    [ExcludeFromCodeCoverage]
    private void ToolStripMenuItemCreateMarkerOnClick(object sender, EventArgs e)
    {
        var xPercentage = (rightClickLocation.X * 100) / pictureBox.Image.Size.Width;
        var yPercentage = (rightClickLocation.Y * 100) / pictureBox.Image.Size.Height;

        var markerToBeCreated = new Marker
        {
            Name = "Marker name",
            XPositionPercentage = xPercentage,
            YPositionPercentage = yPercentage
        };

        var editMarkerForm = new EditMarkerForm(markerToBeCreated);
        editMarkerForm.StartPosition = FormStartPosition.CenterParent;
        editMarkerForm.Text = "Create marker";

        var result = editMarkerForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            Map.Markers.Add(markerToBeCreated);
            pictureBox.Refresh();
        }
    }

    [ExcludeFromCodeCoverage]
    private void InitializePanelMap()
    {
        panelMap = new Panel();
        panelMap.Size = this.Size;
        panelMap.AutoScroll = true;
    }

    [ExcludeFromCodeCoverage]
    private void DisplayMap()
    {
        var currentHorizontalScrollPercentage = GetCurrentHorizontalScrollPercentage();
        var currentVerticalScrollPercentage = GetCurrentVerticalScrollPercentage();

        if (pictureBox != null)
            pictureBox.Image = null;

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

        PerformCleanupAndResetDisplaysMadeCounterIfTooManyDisplaysWereMade();
        displaysMade++;
    }

    private void PerformCleanupAndResetDisplaysMadeCounterIfTooManyDisplaysWereMade()
    {
        if (displaysMade > 9)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            displaysMade = 0;
        }
    }

    [ExcludeFromCodeCoverage]
    private void PictureBoxOnPaint(object sender, PaintEventArgs e)
    {
        DrawMarkers(e);
    }

    [ExcludeFromCodeCoverage]
    private void DrawMarkers(PaintEventArgs e)
    {
        foreach (var marker in Map.Markers)
        {
            var position = GetMarkerPosition(marker);
            var rectangle = new Rectangle(position, MarkerSize);

            using (var brush = new SolidBrush(MarkerInactiveColor))
            {
                e.Graphics.FillRectangle(brush, rectangle);
            }
        }

        if (activeMarker != null)
        {
            var position = GetMarkerPosition(activeMarker);
            var rectangle = new Rectangle(position, MarkerSize);

            using (var brush = new SolidBrush(MarkerActiveColor))
            {
                e.Graphics.FillRectangle(brush, rectangle);
            }
        }
    }

    [ExcludeFromCodeCoverage]
    private Point GetMarkerPosition(Marker marker)
    {
        var position = new Point
        {
            X = (int)(pictureBox.Image.Width * marker.XPositionPercentage) / 100,
            Y = (int)(pictureBox.Image.Height * marker.YPositionPercentage) / 100
        };

        return position;
    }

    [ExcludeFromCodeCoverage]
    private void PictureBoxOnMouseDown(object sender, MouseEventArgs mouseEventArgs)
    {
        if (mouseEventArgs.Button == MouseButtons.Left)
        {
            var clickedMarker = GetClickedMarkerOrNullIfNoMarkerWasClicked(mouseEventArgs);

            if (clickedMarker != null)
            {
                activeMarker = clickedMarker == activeMarker 
                    ? null 
                    : clickedMarker;

                OnMarkerClicked(clickedMarker);
            }
        }

        if (mouseEventArgs.Button == MouseButtons.Right)
        {
            rightClickLocation = mouseEventArgs.Location;
        }
    }

    [ExcludeFromCodeCoverage]
    private float GetCurrentHorizontalScrollPercentage()
    {
        var currentScrollValue = panelMap.HorizontalScroll.Value;
        var maximumScrollValue = panelMap.HorizontalScroll.Maximum;
        var percentageScrolled = (currentScrollValue * 100) / (float)maximumScrollValue;

        return percentageScrolled;
    }

    [ExcludeFromCodeCoverage]
    private float GetCurrentVerticalScrollPercentage()
    {
        var currentScrollValue = panelMap.VerticalScroll.Value;
        var maximumScrollValue = panelMap.VerticalScroll.Maximum;
        var percentageScrolled = (currentScrollValue * 100) / (float)maximumScrollValue;

        return percentageScrolled;
    }

    [ExcludeFromCodeCoverage]
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

    [ExcludeFromCodeCoverage]
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

    [ExcludeFromCodeCoverage]
    private Marker GetClickedMarkerOrNullIfNoMarkerWasClicked(MouseEventArgs mouseEventArgs)
    {
        foreach (var marker in Map.Markers)
        {
            var markerPosition = GetMarkerPosition(marker);
            var markerRectangle = new Rectangle(markerPosition, MarkerSize);

            if (RectangleWasClicked(mouseEventArgs, markerRectangle))
            {
                return marker;
            }
        }

        return null;
    }

    [ExcludeFromCodeCoverage]
    private bool RectangleWasClicked(MouseEventArgs mouseEventArgs, Rectangle rectangle)
    {
        return
            mouseEventArgs.X > rectangle.X
            && mouseEventArgs.X < rectangle.X + rectangle.Width
            && mouseEventArgs.Y > rectangle.Y
            && mouseEventArgs.Y < rectangle.Y + rectangle.Height;
    }
}