using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PointOfSale;

namespace PointOfSale.Test
{
    public class CartTests
    {
        private static Product iPod = new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m);
        private static Product iPhone = new Product("iPhone", "Smartphone", "White 64 GB unlocked 4.7\" iPhone SE", 399m);

        [Fact]
        public void AddNewProduct()
        {
            Cart cart = new Cart();
            int result = cart.Add(iPod, 2);
            Assert.Equal(2, result);
        }

        [Fact]
        public void AddexistingProduct()
        {
            Cart cart = new Cart();
            cart.Add(iPod, 2);
            int result = cart.Add(iPod, 2);
            Assert.Equal(4, result);
        }

        [Fact]
        public void LineTotal()
        {
            Cart cart = new Cart();
            decimal result = cart.LineTotal(2, iPod.Price);
            Assert.Equal(398m, result);
        }

        [Fact]
        public void SubTotalTest()
        {
            Cart cart = new Cart();
            cart.Add(iPod, 2);
            decimal result = cart.SubTotal();
            Assert.Equal(398m, result);
        }

        [Fact]
        public void SalesTaxTest()
        {
            Cart cart = new Cart();
            cart.Add(iPod, 2);
            decimal result = cart.SalesTax();
            Assert.Equal(23.88m, result);
        }

        [Fact]
        public void GrandTotalTest()
        {
            Cart cart = new Cart();
            cart.Add(iPod, 2);
            decimal result = cart.GrandTotal();
            Assert.Equal(421.88m, result);
        }

        [Fact]
        public void GetReceiptTest()
        {
            Cart final = new Cart();
            final.Add(iPod, 1);
            final.Add(iPhone, 1);
            string[] receipt = final.GetReceipt();
            string[] expected = { "1 iPod Black 256 GB $199.00", "1 iPhone White 64 GB unlocked 4.7\" iPhone SE $399.00", "Sub Total: $598.00", "Grand Total: $633.88" };
            Assert.Equal(expected,receipt);

            // # Name Description $LineTotal
            // # Name Description $LineTotal
            //          SubTotal
            //          GrandTotal
            //
            //          Tendered
            //          Change

        }
    }
}
