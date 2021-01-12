using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myshop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
