using System;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Views
{
    public partial class MapView : UserControl
    {
        public Map Map { get; }

        public MapView(Map map)
        {
            ValidateMap(map);

            InitializeComponent();

            Map = map;
            this.BackgroundImage = Map.Image;
        }

        private void ValidateMap(Map map)
        {
            if (map == null)
            {
                throw new ArgumentNullException();
            }

            map.ValidateAndThrow();
        }
    }
}
