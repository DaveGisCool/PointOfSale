using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale
{
    public class Product
    {
        private string _Name;
        private string _Category;
        private string _Description;
        private decimal _Price;

        public string Name { get { return _Name; } }
        public string Category { get { return _Category; } }
        public string Description { get { return _Description; } }
        public decimal Price { get { return _Price; } }

        public Product(string name, string category, string description, decimal price)
        {
            _Name = name;
            _Category = category;
            _Description = description;
            _Price = price;
        }
    }
}
