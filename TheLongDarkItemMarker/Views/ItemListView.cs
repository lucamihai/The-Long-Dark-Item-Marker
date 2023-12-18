using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Enums;
using TheLongDarkItemMarker.Utility;

namespace TheLongDarkItemMarker.Views;

public partial class ItemListView : UserControl
{
    private List<ItemView> itemViews;

    public List<Item> Items { get; }
    private List<Item> filteredItems;

    [ExcludeFromCodeCoverage]
    public List<Item> SelectedItems { get; }
    public ItemListViewSelection ItemListViewSelection { get; }

    public delegate void ItemsSelected();
    [ExcludeFromCodeCoverage]
    public ItemsSelected OnItemsSelected { get; set; } = () => { };

    public delegate void ItemsDeselected();
    [ExcludeFromCodeCoverage]
    public ItemsDeselected OnItemsDeselected { get; set; } = () => { };

    public ItemListView(List<Item> items, ItemListViewSelection itemListViewSelection)
    {
        ValidateItemList(items);

        InitializeComponent();

        Items = items;
        filteredItems = new List<Item>();
        filteredItems.AddRange(items);

        SelectedItems = new List<Item>();

        InitializeComboBoxItemFiltering();
        InitializeItemViews();
        ItemListViewSelection = itemListViewSelection;
    }

    [ExcludeFromCodeCoverage]
    public void ForceDraw()
    {
        FilterItems();
        InitializeItemViews();
        UpdateColorsForItemViews();
    }

    private void ValidateItemList(List<Item> items)
    {
        if (items == null)
        {
            throw new ArgumentNullException();
        }
    }

    [ExcludeFromCodeCoverage]
    private void InitializeComboBoxItemFiltering()
    {
        var itemFilteringComboBoxItemForAllCategories = new ItemFilteringComboBoxItem
        {
            Id = 0,
            Text = "All"
        };

        var itemFilteringComboBoxItemForFireStarting = new ItemFilteringComboBoxItem
        {
            Id = 1,
            ItemCategory = ItemCategory.FireStarting,
            Text = "Fire starting"
        };

        var itemFilteringComboBoxItemForFirstAid = new ItemFilteringComboBoxItem
        {
            Id = 2,
            ItemCategory = ItemCategory.FirstAid,
            Text = "First aid"
        };

        var itemFilteringComboBoxItemForClothing = new ItemFilteringComboBoxItem
        {
            Id = 3,
            ItemCategory = ItemCategory.Clothing,
            Text = "Clothing"
        };

        var itemFilteringComboBoxItemForFoodAndDrink = new ItemFilteringComboBoxItem
        {
            Id = 4,
            ItemCategory = ItemCategory.FoodAndDrink,
            Text = "Food and drink"
        };

        var itemFilteringComboBoxItemForTool = new ItemFilteringComboBoxItem
        {
            Id = 5,
            ItemCategory = ItemCategory.Tool,
            Text = "Tool"
        };

        var itemFilteringComboBoxItemForMaterial = new ItemFilteringComboBoxItem
        {
            Id = 6,
            ItemCategory = ItemCategory.Material,
            Text = "Material"
        };

        comboBoxCategoryFilter.Items.Add(itemFilteringComboBoxItemForAllCategories);
        comboBoxCategoryFilter.Items.Add(itemFilteringComboBoxItemForFireStarting);
        comboBoxCategoryFilter.Items.Add(itemFilteringComboBoxItemForFirstAid);
        comboBoxCategoryFilter.Items.Add(itemFilteringComboBoxItemForClothing);
        comboBoxCategoryFilter.Items.Add(itemFilteringComboBoxItemForFoodAndDrink);
        comboBoxCategoryFilter.Items.Add(itemFilteringComboBoxItemForTool);
        comboBoxCategoryFilter.Items.Add(itemFilteringComboBoxItemForMaterial);

        comboBoxCategoryFilter.SelectedIndex = itemFilteringComboBoxItemForAllCategories.Id;
    }

    [ExcludeFromCodeCoverage]
    private void InitializeItemViews()
    {
        itemViews = new List<ItemView>();
        panelItems.Controls.Clear();

        for (int index = 0; index < filteredItems.Count; index++)
        {
            var itemView = new ItemView(filteredItems[index]);
            itemView.Location = new Point(0, (index * itemView.Height) + 10);
            itemView.BorderStyle = BorderStyle.FixedSingle;
            itemView.OnViewClicked += OnViewClicked;
            itemViews.Add(itemView);

            panelItems.Controls.Add(itemView);
        }
    }

    [ExcludeFromCodeCoverage]
    private void OnViewClicked(ItemView clickedItemView)
    {
        if (ItemListViewSelection == ItemListViewSelection.None)
        {
            return;
        }

        var item = clickedItemView.Item;

        if (SelectedItems.Contains(item))
        {
            SelectedItems.Remove(item);
            OnItemsDeselected();
        }
        else
        {
            if (ItemListViewSelection == ItemListViewSelection.SingleElement)
            {
                SelectedItems.Clear();
            }

            SelectedItems.Add(item);
            OnItemsSelected();
        }

        UpdateColorsForItemViews();
    }

    [ExcludeFromCodeCoverage]
    private void UpdateColorsForItemViews()
    {
        foreach (var itemView in itemViews)
        {
            itemView.BackColor = panelItems.BackColor;
        }

        foreach (var selectedItem in SelectedItems)
        {
            var itemViewForSelectedItem = itemViews.SingleOrDefault(x => x.Item == selectedItem);

            if (itemViewForSelectedItem != null)
                itemViewForSelectedItem.BackColor = Color.LightGreen;
        }
    }

    [ExcludeFromCodeCoverage]
    private void ComboBoxCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilterItems();
        InitializeItemViews();
        UpdateColorsForItemViews();
    }

    [ExcludeFromCodeCoverage]
    private void TextBoxFilterByNameTextChanged(object sender, EventArgs e)
    {
        FilterItems();
        InitializeItemViews();
        UpdateColorsForItemViews();
    }

    [ExcludeFromCodeCoverage]
    private void FilterItems()
    {
        filteredItems.Clear();
        filteredItems.AddRange(Items);

        FilterItemsBasedOnSelectedItemCategory();
        FilterItemsBasedOnEnteredName();
    }

    [ExcludeFromCodeCoverage]
    private void FilterItemsBasedOnSelectedItemCategory()
    {
        var selectedComboBoxItem = comboBoxCategoryFilter.SelectedItem as ItemFilteringComboBoxItem;

        if (selectedComboBoxItem.Text == "All")
            return;

        var selectedCategory = selectedComboBoxItem.ItemCategory;
        filteredItems = ItemListFilteringMethods.GetItemListFilteredByItemCategory(filteredItems, selectedCategory);
    }

    [ExcludeFromCodeCoverage]
    private void FilterItemsBasedOnEnteredName()
    {
        if (string.IsNullOrEmpty(textBoxFilterByName.Text))
            return;

        filteredItems = ItemListFilteringMethods.GetItemListFilteredByName(filteredItems, textBoxFilterByName.Text);
    }

}