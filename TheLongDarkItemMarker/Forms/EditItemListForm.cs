using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Enums;
using TheLongDarkItemMarker.Utility;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Forms
{
    public partial class EditItemListForm : Form
    {
        public List<Item> Items { get; private set; }

        private readonly ItemListView itemListView;

        public EditItemListForm(List<Item> items)
        {
            ValidateItemList(items);

            InitializeComponent();

            InitializeItemListFromProvidedItems(items);

            itemListView = new ItemListView(Items, ItemListViewSelection.MultipleElements);
            panelItems.Controls.Add(itemListView);

            itemListView.OnItemsSelected += OnItemsSelected;
            itemListView.OnItemsDeselected += OnItemsDeselected;

            buttonEditSelectedItem.Enabled = false;
            buttonRemoveSelectedItems.Enabled = false;
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
            var addItemForm = new AddItemForm();
            var result = addItemForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                AddItemOrStackExistingOne(addItemForm.Item);
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
    }
}
