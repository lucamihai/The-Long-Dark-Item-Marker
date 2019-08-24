using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Forms
{
    public partial class CreateMarkerForm : Form
    {
        public Marker Marker { get; set; }
        public float XPercentage { get; }
        public float YPercentage { get; }

        public CreateMarkerForm(float xPercentage, float yPercentage)
        {
            InitializeComponent();

            XPercentage = xPercentage;
            YPercentage = yPercentage;
        }

        [ExcludeFromCodeCoverage]
        private void AddMarkerClick(object sender, EventArgs e)
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

            Marker = new Marker
            {
                Name = markerName,
                XPositionPercentage = XPercentage,
                YPositionPercentage = YPercentage
            };

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
