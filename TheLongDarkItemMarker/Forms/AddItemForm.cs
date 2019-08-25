using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Enums;
using TheLongDarkItemMarker.FileSaving;
using TheLongDarkItemMarker.Utility;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Forms
{
    [ExcludeFromCodeCoverage]
    public partial class AddItemForm : Form
    {
        private List<Item> items;
        private List<ItemView> itemViews;
        private readonly ItemListView itemListView;

        public Item Item { get; set; }

        public AddItemForm()
        {
            InitializeComponent();
            InitializeItems();

            itemListView = new ItemListView(items, ItemListViewSelection.SingleElement);
            itemListView.OnAllItemsDeselected += delegate { buttonAddSelectedItem.Enabled = false; };
            itemListView.OnItemsSelected += delegate { buttonAddSelectedItem.Enabled = true; };
            panelItems.Controls.Add(itemListView);

            buttonAddSelectedItem.Enabled = false;
        }

        private void InitializeItems()
        {
            items = new List<Item>();

            var jsonManager = new JsonManager();
            var configPath = $"{Environment.CurrentDirectory}\\Config\\Items.json";
            var configItems = jsonManager.GetItemsFromJsonFile(configPath);

            items.AddRange(configItems);
        }

        private void AddSelectedItemClick(object sender, EventArgs e)
        {
            var selectedItemClone = UtilityMethods.GetItemClone(itemListView.SelectedItems[0]);
            Item = selectedItemClone;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
