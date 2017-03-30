using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProdctName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public virtual Category  category{ get; set; }
        

    }
}