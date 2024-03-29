﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.FileSaving;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Forms;

[ExcludeFromCodeCoverage]
public partial class MainWindow : Form
{
    private MapView mapView;
    private Dictionary<string, string> mapImageNames;
    private MarkerView markerView;

    private string ActiveFolderPath
    {
        get => textBoxActiveFolder.Text;
        set => textBoxActiveFolder.Text = value;
    }
    private readonly JsonManager jsonManager;

    public MainWindow()
    {
        InitializeComponent();
        InitializeMapImageNameDictionary();

        AssignEventToRadioButtonsForMapSelection();

        this.KeyPreview = true;

        jsonManager = new JsonManager();
        labelWarning.Text = "There is currently no active folder set!";

        buttonEditMarker.Enabled = false;
        buttonDeleteMarker.Enabled = false;
    }

    private void InitializeMapImageNameDictionary()
    {
        mapImageNames = new Dictionary<string, string>
        {
            [MapNames.MysteryLake] = MapImageNames.MysteryLake,
            [MapNames.CoastalHighway] = MapImageNames.CoastalHighway,
            [MapNames.DesolationPoint] = MapImageNames.DesolationPoint,
            [MapNames.PleasantValley] = MapImageNames.PleasantValley,
            [MapNames.TimberwolfMountain] = MapImageNames.TimberwolfMountain,
            [MapNames.ForlornMuskeg] = MapImageNames.ForlornMuskeg,
            [MapNames.BrokenRailroad] = MapImageNames.BrokenRailroad,
            [MapNames.MountainTown] = MapImageNames.MountainTown,
            [MapNames.HushedRiverValley] = MapImageNames.HushedRiverValley,
        };
    }

    private void AssignEventToRadioButtonsForMapSelection()
    {
        foreach (var control in panelMapSelection.Controls.OfType<RadioButton>())
        {
            control.CheckedChanged += RadioButtonMapEvent;
        }
    }

    private void RadioButtonMapEvent(object sender, EventArgs e)
    {
        var radioButton = sender as RadioButton;

        if (radioButton == null)
        {
            return;
        }

        if (radioButton.Checked)
        {
            if (ActiveFolderPath != string.Empty)
            {
                SaveMarkers();
            }

            var mapName = radioButton.Text;
            var mapImageName = mapImageNames[mapName];
            var map = new Map
            {
                Name = mapName,
                Image = Settings.Settings.GetMapImageOrDefault(mapImageName)
            };

            map.ValidateAndThrow();
            DisplayMap(map);

            if (ActiveFolderPath != string.Empty)
            {
                LoadMarkers();
            }
        }
    }

    private void DisplayMap(Map map)
    {
        mapView = new MapView(map);
        mapView.OnMarkerClicked += OnMarkerClicked;

        panelMap.Controls.Clear();
        panelMap.Controls.Add(mapView);
    }

    private void OnMarkerClicked(Marker clickedMarker)
    {
        mapView.ForceDraw();
        panelClickedMarker.Controls.Clear();

        var currentActiveMarkerIsClicked = CurrentActiveMarkerIsClicked(clickedMarker);
        if (CurrentActiveMarkerIsClicked(clickedMarker))
        {
            markerView = new MarkerView(new Marker {Name = "Some marker name"});
        }
        else
        {
            markerView = new MarkerView(clickedMarker);
            panelClickedMarker.Controls.Add(markerView);
        }

        buttonEditMarker.Enabled = !currentActiveMarkerIsClicked;
        buttonDeleteMarker.Enabled = !currentActiveMarkerIsClicked;
    }

    private bool CurrentActiveMarkerIsClicked(Marker clickedMarker)
    {
        if (markerView == null)
            return false;

        return clickedMarker == markerView.Marker;
    }

    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {
        var position = Control.MousePosition;
        var positionToMapView = mapView.PointToClient(position);

        if (mapView.DisplayRectangle.Contains(positionToMapView))
        {
            if (e.KeyCode == Keys.PageUp)
            {
                mapView.ZoomFactor += 0.02f;
            }

            if (e.KeyCode == Keys.PageDown)
            {
                mapView.ZoomFactor -= 0.02f;
            }
        }
    }

    private void SetActiveFolderClick(object sender, EventArgs e)
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = string.IsNullOrEmpty(ActiveFolderPath) 
                ? $"{Environment.CurrentDirectory}\\" 
                : ActiveFolderPath;

            var dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                ActiveFolderPath = folderBrowserDialog.SelectedPath;
                labelWarning.Text = string.Empty;

                LoadMarkers();
            }
        }
    }

    private string GetMarkersJsonFileNameBasedOnMapName(string mapName)
    {
        return $"{ActiveFolderPath}\\{mapName} markers.json";
    }

    private void SaveMarkers()
    {
        var markers = mapView.Map.Markers;
        var mapName = mapView.Map.Name;
        var fileName = GetMarkersJsonFileNameBasedOnMapName(mapName);

        jsonManager.SaveMarkersToJsonFile(markers, fileName);

    }

    private void LoadMarkers()
    {
        var mapName = mapView.Map.Name;
        var fileName = GetMarkersJsonFileNameBasedOnMapName(mapName);

        List<Marker> markers;

        try
        {
            markers = jsonManager.GetMarkersFromJsonFile(fileName);
            ValidateMarkers(markers);
        }
        catch (ValidationException exception)
        {
            MessageBox.Show($"Data from {fileName} is not correctly formatted.{Environment.NewLine}{exception.Message}");
            return;
        }
        catch (ArgumentException exception)
        {
            markers = new List<Marker>();
        }

        mapView.Map.Markers.Clear();
        mapView.Map.Markers.AddRange(markers);

        mapView.ForceDraw();
    }

    private void ValidateMarkers(List<Marker> markers)
    {
        foreach (var marker in markers)
        {
            marker.ValidateAndThrow();
        }
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
        if (ActiveFolderPath != string.Empty)
        {
            SaveMarkers();
        }
    }

    private void EditMarkerClick(object sender, EventArgs e)
    {
        var markerItemsBeforeEdit = new List<Item>(markerView.Marker.Items);
        var editMarkerForm = new EditMarkerForm(markerView.Marker);
        editMarkerForm.StartPosition = FormStartPosition.CenterParent;
        var result = editMarkerForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            markerView.UpdateViewData();
        }

        if (result == DialogResult.Cancel)
        {
            markerView.Marker.Items.Clear();
            markerView.Marker.Items.AddRange(markerItemsBeforeEdit);
        }
    }

    private void DeleteMarkerClick(object sender, EventArgs e)
    {
        mapView.Map.Markers.Remove(markerView.Marker);
        mapView.ForceDraw();

        panelClickedMarker.Controls.Clear();

        buttonEditMarker.Enabled = false;
        buttonDeleteMarker.Enabled = false;
    }

    private void AboutToolStripMenuItemClick(object sender, EventArgs e)
    {
        var aboutForm = new AboutForm();
        aboutForm.ShowDialog();
    }

    private void OpenWebPageToolStripMenuItemClick(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start(Settings.Settings.HelpWebPageUrl);
    }
}