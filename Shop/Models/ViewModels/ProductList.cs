using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.ViewModels
{
    public class ProductList
    {
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public string ProdctName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string model { get; set; }
        public string Feature { get; set; }
        public string detail { get; set; }
        public string Image { get; set; }
        public List<Product> products { get; set; }
        public List<Detail> details { get; set; }
        public List<Category> categories { get; set; }
    }
}