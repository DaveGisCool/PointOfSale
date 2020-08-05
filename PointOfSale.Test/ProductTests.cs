using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PointOfSale;

namespace PointOfSale.Test
{
    public class ProductTests
    {
        [Fact]
        public void NameTest()
        {
            Product testProduct = new Product("iPod", "Portable Audio Player", "Black 256 GB ", 199m);

            Assert.Equal("iPod", testProduct.Name);
        }
        [Fact]
        public void CategoryTest()
        {
            Product testProduct = new Product("iPod", "Portable Audio Player", "Black 256 GB ", 199m);

            Assert.Equal("Portable Audio Player", testProduct.Category);
        }
        [Fact]
        public void DescriptionTest()
        {
            Product testProduct = new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m);

            Assert.Equal("Black 256 GB", testProduct.Description);
        }
        [Fact]
        public void PriceTest()
        {
            Product testProduct = new Product("iPod", "Portable Audio Player", "Black 256 GB ", 199m);

            Assert.Equal(199m, testProduct.Price);
        }
    }
}
