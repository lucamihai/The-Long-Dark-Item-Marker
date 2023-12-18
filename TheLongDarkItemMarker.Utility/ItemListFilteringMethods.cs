using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Utility
{
    public static class ItemListFilteringMethods
    {
        public static List<Item> GetItemListFilteredByItemCategory(List<Item> items, ItemCategory itemCategory)
        {
            var itemsWithSpecifiedCategory = items
                .Where(x => x.ItemCategory == itemCategory)
                .ToList();

            return itemsWithSpecifiedCategory;
        }

        public static List<Item> GetItemListFilteredByName(List<Item> items, string name)
        {
            var itemsContainingProvidedName = items
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            return itemsContainingProvidedName;
        }
    }
}
