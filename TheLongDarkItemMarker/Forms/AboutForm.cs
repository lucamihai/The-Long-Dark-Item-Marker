using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.Forms;

[ExcludeFromCodeCoverage]
public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();

        richTextBox.Font = new Font(new FontFamily("Times New Roman"), 12);
        richTextBox.ReadOnly = true;
        richTextBox.Text = Settings.Settings.About;
    }
}