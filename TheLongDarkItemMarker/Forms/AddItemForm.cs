using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Forms
{
    [ExcludeFromCodeCoverage]
    public partial class AddItemForm : Form
    {
        private AddItemView addItemView;

        public Item Item { get; set; }

        public AddItemForm()
        {
            InitializeComponent();
            InitializeAddItemView();
            this.Controls.Add(addItemView);
        }

        private void InitializeAddItemView()
        {
            addItemView = new AddItemView();
            addItemView.OnItemAdd += OnItemAdd;
        }

        private void OnItemAdd(Item copyOfItemToAdd)
        {
            var editItemForm = new EditItemForm(copyOfItemToAdd);
            var result = editItemForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Item = copyOfItemToAdd;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
