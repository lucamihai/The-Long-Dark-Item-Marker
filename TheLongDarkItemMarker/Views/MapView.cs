using System;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Views
{
    public partial class MapView : UserControl
    {
        public Map Map { get; }
        private Panel panelMap;

        public MapView(Map map)
        {
            ValidateMap(map);

            InitializeComponent();
            panelMap = new Panel();
            panelMap.Size = this.Size;
            panelMap.AutoScroll = true;
            this.Controls.Add(panelMap);

            Map = map;
            
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
            var pictureBox = new PictureBox {Size = Map.Image.Size, Image = Map.Image};
            panelMap.Controls.Clear();
            panelMap.Controls.Add(pictureBox);
        }
    }
}
