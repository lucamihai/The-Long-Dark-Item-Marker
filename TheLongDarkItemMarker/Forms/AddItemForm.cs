using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Utility;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Forms
{
    public partial class AddItemForm : Form
    {
        private List<Item> items;
        private List<ItemView> itemViews;

        public Item Item { get; set; }

        public AddItemForm()
        {
            InitializeComponent();
            InitializeItemSelection();

            buttonAddSelectedItem.Enabled = false;
        }

        private void InitializeItemSelection()
        {
            InitializeItems();
            InitializeItemViews();
        }

        // TODO: Get these from a config file
        private void InitializeItems()
        {
            items = new List<Item>();

            var huntingRifle = new ItemWithConditionAndQuantity
            {
                ItemCategory = ItemCategory.Tool,
                Name = "Hunting Rifle",
                HowMany = 1,
                Condition = 100,
                Quantity = 0,
                QuantityMaxValue = 10,
                QuantityName = "Rifle Cartridges"
            };
            items.Add(huntingRifle);

            var stick = new Item
            {
                ItemCategory = ItemCategory.FireStarting,
                HowMany = 1,
                Name = "Stick"
            };
            items.Add(stick);
        }

        private void InitializeItemViews()
        {
            itemViews = new List<ItemView>();

            for (int index = 0; index < items.Count; index++)
            {
                var itemView = new ItemView(items[index]);
                itemView.Location = new Point(0, (index * itemView.Height) + 10);
                itemView.BorderStyle = BorderStyle.FixedSingle;
                itemView.OnViewClicked += OnViewClicked;
                itemViews.Add(itemView);

                panelItems.Controls.Add(itemView);
            }
        }

        private void OnViewClicked(ItemView itemview)
        {
            foreach (var itemView in itemViews)
            {
                itemView.BackColor = this.BackColor;
            }

            Item = UtilityMethods.GetItemClone(itemview.Item);
            buttonAddSelectedItem.Enabled = true;
            itemview.BackColor = Color.LightGreen;
        }

        private void AddSelectedItemClick(object sender, EventArgs e)
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
