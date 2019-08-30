using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        private readonly ItemListView itemListView;
        private readonly string configDirectory = $"{Environment.CurrentDirectory}\\Config\\Items";

        public Item Item { get; set; }

        public AddItemForm()
        {
            InitializeComponent();
            InitializeItems();

            itemListView = new ItemListView(items, ItemListViewSelection.SingleElement);
            itemListView.OnItemsDeselected += OnItemsDeselected;
            itemListView.OnItemsSelected += OnItemsSelected;
            panelItems.Controls.Add(itemListView);

            buttonAddSelectedItem.Enabled = false;
        }

        private void OnItemsDeselected()
        {
            buttonAddSelectedItem.Enabled = false;
        }

        private void OnItemsSelected()
        {
            buttonAddSelectedItem.Enabled = true;
        }

        private void InitializeItems()
        {
            items = new List<Item>();

            var jsonManager = new JsonManager();
            var itemsFireStarting = GetItemsFromConfig(jsonManager, ItemCategory.FireStarting);
            var itemsFirstAid = GetItemsFromConfig(jsonManager, ItemCategory.FirstAid);
            var itemsClothing = GetItemsFromConfig(jsonManager, ItemCategory.Clothing);
            var itemsFoodAndDrink = GetItemsFromConfig(jsonManager, ItemCategory.FoodAndDrink);
            var itemsTool = GetItemsFromConfig(jsonManager, ItemCategory.Tool);
            var itemsMaterial = GetItemsFromConfig(jsonManager, ItemCategory.Material);

            items.AddRange(itemsFireStarting);
            items.AddRange(itemsFirstAid);
            items.AddRange(itemsClothing);
            items.AddRange(itemsFoodAndDrink);
            items.AddRange(itemsTool);
            items.AddRange(itemsMaterial);
        }

        private List<Item> GetItemsFromConfig(JsonManager jsonManager, ItemCategory itemCategory)
        {
            var configPath = $"{configDirectory}\\Items{itemCategory.ToString()}.json";
            var configItems = jsonManager.GetItemsFromJsonFile(configPath);

            return configItems;
        }

        private void AddSelectedItemClick(object sender, EventArgs e)
        {
            var selectedItemClone = UtilityMethods.GetItemClone(itemListView.SelectedItems[0]);
            var editItemForm = new EditItemForm(selectedItemClone);
            var result = editItemForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Item = selectedItemClone;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
