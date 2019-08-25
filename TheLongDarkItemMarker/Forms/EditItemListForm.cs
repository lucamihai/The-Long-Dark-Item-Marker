using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Utility;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Forms
{
    public partial class EditItemListForm : Form
    {
        public List<Item> Items { get; private set; }

        public EditItemListForm(List<Item> items)
        {
            ValidateItemList(items);

            InitializeComponent();

            InitializeItemListFromProvidedItems(items);
            UpdateItemPanel();
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

        private void UpdateItemPanel()
        {
            panelItems.Controls.Clear();

            for (int index = 0; index < Items.Count; index++)
            {
                var itemView = new ItemView(Items[index]);
                itemView.Location = new Point(0, (index * itemView.Height) + 10);
                itemView.BorderStyle = BorderStyle.FixedSingle;

                panelItems.Controls.Add(itemView);
            }
        }

        private void AddItemClick(object sender, EventArgs e)
        {
            var addItemForm = new AddItemForm();
            var result = addItemForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Items.Add(addItemForm.Item);
                UpdateItemPanel();
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
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
