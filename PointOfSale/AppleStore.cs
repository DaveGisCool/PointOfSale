using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale
{
    public class AppleStore
    {
        Dictionary<string, Product> selections;

        public AppleStore()
        {
            selections = new Dictionary<string, Product>(StringComparer.OrdinalIgnoreCase);
        }

        public bool Add(string key, Product productItem)
        {
            return selections.TryAdd(key, productItem);
        }

        public bool IsValidItem(string key)
        {
            return selections.ContainsKey(key);
        }


        public string GetMenuItemDetail(string key)
        {
            if (!IsValidItem(key))
            {
                return "";
            }
            string item = $"{selections[key].Name} {selections[key].Category} {selections[key].Description} {selections[key].Price:C}";
            return item;
        }

        public string[] GetMenu()
        {
            string[] menu = new string[selections.Count];
            int index = 0;
            foreach(KeyValuePair<string, Product> item in selections)
            {
                menu[index] = $"{item.Key}. {item.Value.Name} {item.Value.Category} {item.Value.Price:C}";
                index++;
            }
            return menu;
        }

        public Product GetProduct(string key)
        {
            if (IsValidItem(key))
            {
                return selections[key];
            }
            return null;
        }

    }
}
