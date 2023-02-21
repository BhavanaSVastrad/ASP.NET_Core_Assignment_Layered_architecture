using DataaccessLayer.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;


namespace DataaccessLayer
{
    public class ProductDbContext : DbContext

    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }

        public DbSet<User> Users { get; set; }

    }
}
