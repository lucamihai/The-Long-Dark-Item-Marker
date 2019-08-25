﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Domain.Interfaces;

namespace TheLongDarkItemMarker.Views
{
    public partial class ItemView : UserControl
    {
        private TextBox textBoxItemCategory;
        private TextBox textBoxItemName;

        private TextBox textBoxCondition;
        private TextBox textBoxQuantity;

        public Item Item { get; }

        public delegate void ViewClicked(ItemView itemView);
        public ViewClicked OnViewClicked { get; set; } = (itemView) => { };

        public ItemView(Item item)
        {
            ValidateItem(item);

            InitializeComponent();

            Item = item;
            PrepareItemImage();
            DisplayHowManyItems();
            PrepareViewFields();

            pictureBoxItem.Refresh();

            this.Click += delegate(object sender, EventArgs args) { OnViewClicked(this); };
            pictureBoxItem.Click += delegate(object sender, EventArgs args) { OnViewClicked(this); };
            
        }

        private void ValidateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void PrepareItemImage()
        {
            var itemImageName = GetItemImageName(Item.Name);
            var itemImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(itemImageName);

            pictureBoxItem.BackgroundImage = itemImage != null 
                ? itemImage
                : new Bitmap(pictureBoxItem.Size.Width, pictureBoxItem.Size.Height);
        }

        private string GetItemImageName(string itemName)
        {
            return $"item{Regex.Replace(itemName, @"\s+", "")}";
        }

        private void DisplayHowManyItems()
        {
            if (Item.HowMany > 1)
            {
                var rectangleF = new RectangleF(0, 0, 90, 50);
                var graphics = Graphics.FromImage(pictureBoxItem.Image);

                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawString($"x{Item.HowMany}", new Font("Tahoma", 10), Brushes.Black, rectangleF);

                graphics.Flush();

                pictureBoxItem.Refresh();
            }
        }

        private void PrepareViewFields()
        {
            var activeFields = new List<TextBox>();

            textBoxItemCategory = new TextBox();
            textBoxItemCategory.Text = $"{Item.ItemCategory.ToString()} Category";
            textBoxItemCategory.ReadOnly = true;
            textBoxItemCategory.Width = 150;
            activeFields.Add(textBoxItemCategory);

            textBoxItemName = new TextBox();
            textBoxItemName.Text = Item.Name;
            textBoxItemName.ReadOnly = true;
            textBoxItemName.Width = 150;
            activeFields.Add(textBoxItemName);

            if (Item is IItemWithCondition itemWithCondition)
            {
                textBoxCondition = new TextBox();
                textBoxCondition.Text = $"{itemWithCondition.Condition.ToString()}% Condition";
                textBoxCondition.ReadOnly = true;
                textBoxCondition.Width = 150;
                activeFields.Add(textBoxCondition);
            }

            if (Item is IItemWithQuantity itemWithQuantity)
            {
                textBoxQuantity = new TextBox();
                textBoxQuantity.Text = $"{itemWithQuantity.Quantity} / {itemWithQuantity.QuantityMaxValue} {itemWithQuantity.QuantityName}";
                textBoxQuantity.ReadOnly = true;
                textBoxQuantity.Width = 150;
                activeFields.Add(textBoxQuantity);
            }

            AddViewFieldsToControls(activeFields);
        }

        private void AddViewFieldsToControls(List<TextBox> fields)
        {
            for (int index = 0; index < fields.Count; index++)
            {
                var field = fields[index];
                field.Location = new Point(0, index * 25);
                
                panelFields.Controls.Add(field);
                field.Click += delegate (object sender, EventArgs args) { OnViewClicked(this); };
            }
        }
    }
}
