using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Enums;

namespace TheLongDarkItemMarker.Views
{
    public partial class ItemListView : UserControl
    {
        private List<ItemView> itemViews;

        public List<Item> Items { get; }

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
            InitializeItemViews();
            SelectedItems = new List<Item>();
            ItemListViewSelection = itemListViewSelection;
        }

        [ExcludeFromCodeCoverage]
        public void ForceDraw()
        {
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
        private void InitializeItemViews()
        {
            itemViews = new List<ItemView>();
            panelItems.Controls.Clear();

            for (int index = 0; index < Items.Count; index++)
            {
                var itemView = new ItemView(Items[index]);
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
                var itemViewForSelectedItem = itemViews.Single(x => x.Item == selectedItem);
                itemViewForSelectedItem.BackColor = Color.LightGreen;
            }
        }
    }
}
