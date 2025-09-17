using Microsoft.EntityFrameworkCore;
using System;

namespace CodeFirstWebAPI.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemOrder> OrderItems { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración adicional: relaciones, constraints, etc.
        }
    }
 
}
