﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker
{
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Form
    {
        private MapView mapView;
        private Dictionary<string, string> mapImageNames;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMapImageNameDictionary();

            AssignEventToRadioButtonsForMapSelection();

            this.KeyPreview = true;
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

        private void RadioButtonMapEvent(object sender, System.EventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton == null)
            {
                return;
            }

            if (radioButton.Checked)
            {
                var mapName = radioButton.Text;
                var mapImageName = mapImageNames[mapName];
                var map = new Map
                {
                    Name = mapName,
                    Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(mapImageName)
                };

                map.ValidateAndThrow();
                DisplayMap(map);
            }
        }

        private void DisplayMap(Map map)
        {
            mapView = new MapView(map);

            panelMap.Controls.Clear();
            panelMap.Controls.Add(mapView);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            var position = Control.MousePosition;
            var positionToMapView = mapView.PointToClient(position);

            if (mapView.DisplayRectangle.Contains(positionToMapView))
            {
                if (e.KeyCode == Keys.PageUp)
                {
                    mapView.ZoomFactor += 0.025f;
                    //this.PerformLayout();
                }

                if (e.KeyCode == Keys.PageDown)
                {
                    mapView.ZoomFactor -= 0.025f;
                    //this.PerformLayout();
                }
            }
        }
    }
}
