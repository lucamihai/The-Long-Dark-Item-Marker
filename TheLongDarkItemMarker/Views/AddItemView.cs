using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Enums;
using TheLongDarkItemMarker.FileSaving;
using TheLongDarkItemMarker.Utility;

namespace TheLongDarkItemMarker.Views
{
    [ExcludeFromCodeCoverage]
    public partial class AddItemView : UserControl
    {
        private List<Item> items;
        private readonly ItemListView itemListView;
        private readonly string configDirectory = $"{Environment.CurrentDirectory}\\Config\\Items";

        public delegate void ItemAdd(Item copyOfItemToAdd);
        public ItemAdd OnItemAdd { get; set; } = (copyOfItemToAdd) => { };

        public static int GetWidth => new AddItemView(1).Width;

        public AddItemView()
        {
            InitializeComponent();
            InitializeItems();

            itemListView = new ItemListView(items, ItemListViewSelection.SingleElement);
            itemListView.OnItemsDeselected += OnItemsDeselected;
            itemListView.OnItemsSelected += OnItemsSelected;
            panelItems.Controls.Add(itemListView);

            buttonAddSelectedItem.Enabled = false;
        }

        
        private AddItemView(int parameterForDifferentConstructorSignature)
        {
            InitializeComponent();
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
            OnItemAdd(selectedItemClone);
        }
    }
}
