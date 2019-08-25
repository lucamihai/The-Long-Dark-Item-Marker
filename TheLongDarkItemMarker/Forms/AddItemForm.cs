using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
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

        private void InitializeItems()
        {
            items = new List<Item>();

            var jsonManager = new JsonManager();
            var configPath = $"{Environment.CurrentDirectory}\\Config\\Items.json";
            var configItems = jsonManager.GetItemsFromJsonFile(configPath);

            items.AddRange(configItems);
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

        private void OnViewClicked(ItemView clickedItemView)
        {
            foreach (var itemView in itemViews)
            {
                itemView.BackColor = this.BackColor;
            }

            Item = UtilityMethods.GetItemClone(clickedItemView.Item);
            buttonAddSelectedItem.Enabled = true;
            clickedItemView.BackColor = Color.LightGreen;
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
