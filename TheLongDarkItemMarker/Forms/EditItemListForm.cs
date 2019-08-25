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
        }

        private void ValidateItemList(List<Item> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }
        }

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
                Items.Add(addItemForm.Item);
                itemListView.ForceDraw();
            }
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
