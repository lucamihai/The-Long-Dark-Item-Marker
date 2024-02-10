using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Domain.Interfaces;

namespace TheLongDarkItemMarker.Views;

public partial class ItemView : UserControl
{
    private TextBox textBoxItemCategory;
    private TextBox textBoxItemName;

    private TextBox textBoxCondition;
    private TextBox textBoxQuantity;

    public Item Item { get; }

    public delegate void ViewClicked(ItemView itemView);
    [ExcludeFromCodeCoverage]
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

        AssignClickEvents();
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
        var itemImageName = GetItemImageName(Item.Name);
        pictureBoxItem.BackgroundImage = Settings.ImageProvider.GetItemImageOrDefault(itemImageName);
    }

    [ExcludeFromCodeCoverage]
    private string GetItemImageName(string itemName)
    {
        return $"item{Regex.Replace(itemName, @"\s+", "")}";
    }

    [ExcludeFromCodeCoverage]
    private void DisplayHowManyItems()
    {
        if (Item.HowMany > 1)
        {
            var rectangleF = new RectangleF(0, 0, 130, 50);
            var graphics = Graphics.FromImage(pictureBoxItem.BackgroundImage);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.DrawString($"x{Item.HowMany}", new Font("Consolas", 11), Brushes.Black, rectangleF);

            graphics.Flush();

            pictureBoxItem.Refresh();
        }
    }

    [ExcludeFromCodeCoverage]
    private void AssignClickEvents()
    {
        this.Click += delegate (object sender, EventArgs args) { OnViewClicked(this); };
        pictureBoxItem.Click += delegate (object sender, EventArgs args) { OnViewClicked(this); };
        this.panelFields.Click += delegate (object sender, EventArgs args) { OnViewClicked(this); };
    }

    [ExcludeFromCodeCoverage]
    private void PrepareViewFields()
    {
        var activeFields = new List<TextBox>();

        textBoxItemCategory = new TextBox();
        textBoxItemCategory.Font = new Font(new FontFamily("Times New Roman"), 10);
        textBoxItemCategory.Text = $"{Item.ItemCategory.ToString()} Category";
        textBoxItemCategory.ReadOnly = true;
        textBoxItemCategory.Width = 190;
        activeFields.Add(textBoxItemCategory);

        textBoxItemName = new TextBox();
        textBoxItemName.Font = new Font(new FontFamily("Times New Roman"), 10);
        textBoxItemName.Text = Item.Name;
        textBoxItemName.ReadOnly = true;
        textBoxItemName.Width = 190;
        activeFields.Add(textBoxItemName);

        if (Item is IItemWithCondition itemWithCondition)
        {
            textBoxCondition = new TextBox();
            textBoxCondition.Font = new Font(new FontFamily("Times New Roman"), 10);
            textBoxCondition.Text = $"{itemWithCondition.Condition.ToString()}% Condition";
            textBoxCondition.ReadOnly = true;
            textBoxCondition.Width = 190;
            activeFields.Add(textBoxCondition);
        }

        if (Item is IItemWithQuantity itemWithQuantity)
        {
            var quantityString = itemWithQuantity.QuantityName.ToLower().Contains("liter")  || itemWithQuantity.QuantityName == "Kg"
                ? itemWithQuantity.Quantity.ToString("0.00")
                : itemWithQuantity.Quantity.ToString();

            var quantityMaxValueString = itemWithQuantity.QuantityName.ToLower().Contains("liter") || itemWithQuantity.QuantityName == "Kg"
                ? itemWithQuantity.QuantityMaxValue.ToString("0.00")
                : itemWithQuantity.QuantityMaxValue.ToString();

            textBoxQuantity = new TextBox();
            textBoxQuantity.Font = new Font(new FontFamily("Times New Roman"), 10);
            textBoxQuantity.Text = $"{quantityString} / {quantityMaxValueString} {itemWithQuantity.QuantityName}{itemWithQuantity.QuantityPostfix}";
            textBoxQuantity.ReadOnly = true;
            textBoxQuantity.Width = 190;
            activeFields.Add(textBoxQuantity);
        }

        AddViewFieldsToControls(activeFields);
    }

    [ExcludeFromCodeCoverage]
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