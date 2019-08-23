using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;

namespace TheLongDarkItemMarker
{
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            AssignEventToRadioButtonsForMapSelection();
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
                labelSelectedMap.Text = $"You've selected '{radioButton.Text}'";
            }
        }
    }
}
