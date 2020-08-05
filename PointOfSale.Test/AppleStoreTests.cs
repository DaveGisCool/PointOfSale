using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PointOfSale;

namespace PointOfSale.Test
{
    public class AppleStoreTests
    {
        [Fact]
        public void AddtoMenu()
        {
            AppleStore store = new AppleStore();
            //check that item is on the menu
            bool menuItem = store.Add("A", new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m));
            Assert.True(menuItem);
        }

        [Fact]
        public void IsValidItem()
        {
            AppleStore store = new AppleStore();
            store.Add("A", new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m));
            bool menuItem = store.IsValidItem("A");
            Assert.True(menuItem);
        }
        [Fact]
        public void IsInvalidItem()
        {
            AppleStore store = new AppleStore();
            store.Add("A", new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m));
            bool menuItem = store.IsValidItem("B");
            Assert.False(menuItem);
        }
        [Fact]
        public void CannotAddtoMenu()
        {
            AppleStore store = new AppleStore();
            //check that item is on the menu
            Product dupeItem = new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m);
            store.Add("A", dupeItem);
            bool menuItem = store.Add("A", dupeItem);
            Assert.False(menuItem);
        }
        [Fact]
        public void GetMenuItemDetail()
        {
            AppleStore store = new AppleStore();
            store.Add("A", new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m));
            string menuItem = store.GetMenuItemDetail("A");
            Assert.Equal("iPod Portable Audio Player Black 256 GB $199.00", menuItem);
        }

        [Fact]
        public void GetMenu()
        {
            AppleStore store = new AppleStore();
            store.Add("A", new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m));
            store.Add("B", new Product("iPhone", "Smartphone", "White 64 GB unlocked 4.7\" iPhone SE", 399m));
            string[] menuItems = store.GetMenu();
            Assert.Equal(new string[] { "A. iPod Portable Audio Player $199.00", "B. iPhone Smartphone $399.00" }, menuItems);
        }

        [Fact]
        public void GetMenuItem()
        {
            AppleStore store = new AppleStore();
            Product itemA = new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m);
            store.Add("A",itemA);
            Product retrieved = store.GetProduct("A");
            Assert.Equal(itemA, retrieved);
        }
    }
}
