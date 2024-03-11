using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
       
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
            public DbSet<Item> Items { get; set; }
            public DbSet<User> users { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Cart> Carts { get; set; }
        
    }
}
