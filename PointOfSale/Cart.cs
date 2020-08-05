using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale
{
    public class Cart
    {
        List<Product> items;
        List<int> quantities;
        public int Count { get { return items.Count; } }

        public Cart()
        {
            items = new List<Product>();
            quantities = new List<int>();

        }

        public int Add(Product gimme, int many)
        {
            if (items.Contains(gimme))
            {
                quantities[items.IndexOf(gimme)] += many;
                
                return quantities[items.IndexOf(gimme)];
            }
            else
            {
                items.Add(gimme);
                quantities.Add(many);
                return many;
            }
        }

        public decimal LineTotal(int many, decimal Price)
        {
            return many * Price;
        }

        public decimal SubTotal()
        {
            decimal sum = 0;
            for (int index = 0; index < items.Count; index++)
            {
                sum += items[index].Price * quantities[index];
            }
            return sum;
        }

        public decimal SalesTax()
        {
            return SubTotal() * .06m;
        }

        public decimal GrandTotal()
        {
            return SubTotal() + SalesTax();
        }

        public string[] GetReceipt()
        {
            string[] receipt = new string[items.Count + 2];
            for (int index = 0; index < items.Count; index++)
            {
                receipt[index] = $"{quantities[index]} {items[index].Name} {items[index].Description} {LineTotal(quantities[index], items[index].Price):C}";
            }
            receipt[^2] = $"Sub Total: {SubTotal():C}";
            receipt[^1] = $"Grand Total: {GrandTotal():C}";
            return receipt;
        }
    }
}
