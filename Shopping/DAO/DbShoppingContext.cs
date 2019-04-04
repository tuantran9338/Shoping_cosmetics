using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shopping.DAO
{
    public class DbShoppingContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbShoppingContext() : base ("name=ShoppingConnectionString")
        {

        }
        public DbSet<Products> Products { get; set; }
    }
}