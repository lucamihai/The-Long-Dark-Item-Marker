using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Forms
{
    public partial class EditMarkerForm : Form
    {
        private readonly Marker marker;

        public EditMarkerForm(Marker marker)
        {
            ValidateMarker(marker);

            InitializeComponent();

            this.marker = marker;
            textBoxMarkerName.Text = marker.Name;
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
        private void SaveMarkerClick(object sender, EventArgs e)
        {
            var markerName = textBoxMarkerName.Text;

            if (string.IsNullOrEmpty(markerName))
            {
                errorLabel.Text = "Marker name can't be empty";
                return;
            }

            if (markerName.Length > 20)
            {
                errorLabel.Text = "Marker name must have at least 1, and at most 20 characters";
                return;
            }

            marker.Name = markerName;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        [ExcludeFromCodeCoverage]
        private void CancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
