using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using TheLongDarkItemMarker.Properties;

namespace TheLongDarkItemMarker.Forms
{
    [ExcludeFromCodeCoverage]
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            richTextBox.Font = new Font(new FontFamily("Times New Roman"), 12);
            richTextBox.ReadOnly = true;
            richTextBox.Text = Resources.About;
        }
    }
}
