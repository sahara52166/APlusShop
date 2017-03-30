using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Detail
    {
        [Key]
        public int DetailID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string model { get; set; }
        public string Feature { get; set; }
        public string detail { get; set; }
  

    }
}