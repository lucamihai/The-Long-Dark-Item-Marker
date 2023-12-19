using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Enums;
using TheLongDarkItemMarker.Utility;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Forms;

public partial class EditItemListForm : Form
{
    public List<Item> Items { get; private set; }

    private readonly ItemListView itemListView;
    private static readonly AddItemView AddItemView = StaticViews.AddItemView;
    private bool isExtended;

    public EditItemListForm(List<Item> items)
    {
        ValidateItemList(items);

        InitializeComponent();
        AddItemView.OnItemAdd += OnItemAdd;
        InitializeItemListFromProvidedItems(items);

        itemListView = new ItemListView(Items, ItemListViewSelection.MultipleElements);
        itemListView.OnItemsSelected += OnItemsSelected;
        itemListView.OnItemsDeselected += OnItemsDeselected;
        panelItems.Controls.Add(itemListView);

        buttonEditSelectedItem.Enabled = false;
        buttonRemoveSelectedItems.Enabled = false;

        isExtended = false;
    }

    private void ValidateItemList(List<Item> items)
    {
        if (items == null)
        {
            throw new ArgumentNullException();
        }
    }

    [ExcludeFromCodeCoverage]
    private void OnItemsSelected()
    {
        buttonEditSelectedItem.Enabled = itemListView.SelectedItems.Count == 1;
        buttonRemoveSelectedItems.Enabled = itemListView.SelectedItems.Count > 0;
    }

    [ExcludeFromCodeCoverage]
    private void OnItemsDeselected()
    {
        buttonEditSelectedItem.Enabled = itemListView.SelectedItems.Count == 1;
        buttonRemoveSelectedItems.Enabled = itemListView.SelectedItems.Count > 0;
    }

    [ExcludeFromCodeCoverage]
    private void InitializeItemListFromProvidedItems(List<Item> providedItems)
    {
        Items = new List<Item>();

        foreach (var providedItem in providedItems)
        {
            var item = UtilityMethods.GetItemClone(providedItem);
            Items.Add(item);
        }
    }

    [ExcludeFromCodeCoverage]
    private void AddItemClick(object sender, EventArgs e)
    {
        if (!isExtended)
        {
            this.Width = this.Size.Width + AddItemViewWidth + 60;
            isExtended = true;

            AddItemView.Location = new Point(this.Size.Width - AddItemView.Width - 10, labelItems.Height);
            Controls.Add(AddItemView);
            
        }
        else
        {
            Controls.Remove(AddItemView);
            this.Width = this.Size.Width - AddItemViewWidth - 60;
            isExtended = false;
        }
    }

    [ExcludeFromCodeCoverage]
    private int AddItemViewWidth => AddItemView.GetWidth;

    [ExcludeFromCodeCoverage]
    private void OnItemAdd(Item copyOfItemToAdd)
    {
        var editItemForm = new EditItemForm(copyOfItemToAdd);
        editItemForm.StartPosition = FormStartPosition.CenterParent;
        var result = editItemForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            AddItemOrStackExistingOne(copyOfItemToAdd);
            itemListView.ForceDraw();
        }
    }

    [ExcludeFromCodeCoverage]
    private void AddItemOrStackExistingOne(Item item)
    {
        var alreadyExistingItem = UtilityMethods.GetItemFromListSimilarToProvidedItem(Items, item);

        if (alreadyExistingItem == null)
            Items.Add(item);

        else
        {
            if (item is ItemWithCondition itemFromFormWithCondition)
            {
                var alreadyExistingItemWithCondition = alreadyExistingItem as ItemWithCondition;
                alreadyExistingItemWithCondition.HowMany += itemFromFormWithCondition.HowMany;

                return;
            }

            if (item is ItemWithQuantity itemFromFormWithQuantity)
            {
                var alreadyExistingItemWithQuantity = alreadyExistingItem as ItemWithQuantity;
                alreadyExistingItemWithQuantity.HowMany += itemFromFormWithQuantity.HowMany;

                return;
            }

            if (item is ItemWithConditionAndQuantity itemFromFormWithConditionAndQuantity)
            {
                var alreadyExistingItemWithConditionAndQuantity = alreadyExistingItem as ItemWithConditionAndQuantity;
                alreadyExistingItemWithConditionAndQuantity.HowMany += itemFromFormWithConditionAndQuantity.HowMany;

                return;
            }

            alreadyExistingItem.HowMany += item.HowMany;
        }
    }

    [ExcludeFromCodeCoverage]
    private void EditSelectedItemClick(object sender, EventArgs e)
    {
        var selectedItem = itemListView.SelectedItems[0];
        var editItemForm = new EditItemForm(selectedItem);
        editItemForm.StartPosition = FormStartPosition.CenterParent;
        var result = editItemForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            itemListView.ForceDraw();
        }
    }

    [ExcludeFromCodeCoverage]
    private void RemoveSelectedItemsClick(object sender, EventArgs e)
    {
        foreach (var selectedItem in itemListView.SelectedItems)
        {
            Items.Remove(selectedItem);
        }

        itemListView.SelectedItems.Clear();
        itemListView.ForceDraw();

        OnItemsDeselected();
    }

    [ExcludeFromCodeCoverage]
    private void SaveClick(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    [ExcludeFromCodeCoverage]
    private void CancelClick(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    [ExcludeFromCodeCoverage]
    private void SelectDeselectAllClick(object sender, EventArgs e)
    {
        if (itemListView.SelectedItems.Count == itemListView.Items.Count)
        {
            itemListView.SelectedItems.Clear();
            itemListView.ForceDraw();

            OnItemsDeselected();
        }
        else
        {
            itemListView.SelectedItems.Clear();
            itemListView.SelectedItems.AddRange(itemListView.Items);
            itemListView.ForceDraw();

            OnItemsSelected();
        }
    }
}