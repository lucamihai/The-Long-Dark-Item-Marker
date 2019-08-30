using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker
{
    public class ItemFilteringComboBoxItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ItemCategory ItemCategory { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
