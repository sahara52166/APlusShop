using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ShopDbContext:DbContext
    {
       public ShopDbContext() : base("ShopDbContext") { }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Detail> details { get; set; }
        public DbSet<Registration> registrations { get; set; }
    }
}