using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Domain.Interfaces;

namespace TheLongDarkItemMarker.Forms
{
    public partial class EditItemForm : Form
    {
        private TextBox textBoxItemCategory;
        private TextBox textBoxItemName;

        private NumericUpDown numericUpDownHowMany;
        private NumericUpDown numericUpDownCondition;
        private NumericUpDown numericUpDownQuantity;

        private readonly Item item;

        public EditItemForm(Item item)
        {
            ValidateItem(item);

            InitializeComponent();

            this.item = item;
            PrepareItemImage();
            PrepareFields();
        }

        private void ValidateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
        }

        [ExcludeFromCodeCoverage]
        private void PrepareItemImage()
        {
            var itemImageName = GetItemImageName(item.Name);
            var itemImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(itemImageName);

            pictureBoxItem.BackgroundImage = itemImage != null
                ? itemImage
                : new Bitmap(pictureBoxItem.Size.Width, pictureBoxItem.Size.Height);
        }

        [ExcludeFromCodeCoverage]
        private string GetItemImageName(string itemName)
        {
            return $"item{Regex.Replace(itemName, @"\s+", "")}";
        }

        [ExcludeFromCodeCoverage]
        private void PrepareFields()
        {
            var activeFields = new List<Control>();

            textBoxItemCategory = new TextBox();
            textBoxItemCategory.Text = $"{item.ItemCategory.ToString()} Category";
            textBoxItemCategory.ReadOnly = true;
            textBoxItemCategory.Width = 150;
            activeFields.Add(textBoxItemCategory);

            textBoxItemName = new TextBox();
            textBoxItemName.Text = item.Name;
            textBoxItemName.ReadOnly = true;
            textBoxItemName.Width = 150;
            activeFields.Add(textBoxItemName);

            numericUpDownHowMany = new NumericUpDown();
            numericUpDownHowMany.Name = "items";
            numericUpDownHowMany.Width = 50;
            numericUpDownHowMany.DecimalPlaces = 0;
            numericUpDownHowMany.Value = item.HowMany;
            numericUpDownHowMany.Minimum = 0;
            numericUpDownHowMany.Maximum = 1000;
            numericUpDownHowMany.Increment = 1;
            activeFields.Add(numericUpDownHowMany);

            if (item is IItemWithCondition itemWithCondition)
            {
                numericUpDownCondition = new NumericUpDown();
                numericUpDownCondition.Name = "% Condition";
                numericUpDownCondition.Width = 50;
                numericUpDownCondition.DecimalPlaces = 0;
                numericUpDownCondition.Value = itemWithCondition.Condition;
                numericUpDownCondition.Minimum = 0;
                numericUpDownCondition.Maximum = 100;
                numericUpDownCondition.Increment = 1;
                activeFields.Add(numericUpDownCondition);
            }

            if (item is IItemWithQuantity itemWithQuantity)
            {
                numericUpDownQuantity = new NumericUpDown();
                numericUpDownQuantity.Name = $"{itemWithQuantity.QuantityName}s";
                numericUpDownQuantity.Width = 50;
                numericUpDownQuantity.DecimalPlaces = itemWithQuantity.QuantityName == "Liter" ? 2 : 0;
                numericUpDownQuantity.Value = (decimal)itemWithQuantity.Quantity;
                numericUpDownQuantity.Minimum = 0;
                numericUpDownQuantity.Maximum = (decimal)itemWithQuantity.QuantityMaxValue;
                numericUpDownQuantity.Increment = 1;
                activeFields.Add(numericUpDownQuantity);
            }

            AddViewFieldsToControls(activeFields);
        }

        [ExcludeFromCodeCoverage]
        private void AddViewFieldsToControls(List<Control> fields)
        {
            for (int index = 0; index < fields.Count; index++)
            {
                var field = fields[index];
                field.Location = new Point(0, index * 25);

                panelFields.Controls.Add(field);

                if (field is NumericUpDown numericUpDown)
                {
                    var label = new Label();
                    label.Text = numericUpDown.Name;
                    label.Font = new Font("Times New Roman", 12);
                    label.Location = new Point(numericUpDown.Location.X + numericUpDown.Width + 2, index * 25);
                    label.AutoSize = true;

                    panelFields.Controls.Add(label);
                }
            }
        }

        [ExcludeFromCodeCoverage]
        private void SaveClick(object sender, EventArgs e)
        {
            item.HowMany = (int)numericUpDownHowMany.Value;

            if (item is IItemWithCondition itemWithCondition)
            {
                itemWithCondition.Condition = (byte)numericUpDownCondition.Value;
            }

            if (item is IItemWithQuantity itemWithQuantity)
            {
                itemWithQuantity.Quantity = (float)numericUpDownQuantity.Value;
            }

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
