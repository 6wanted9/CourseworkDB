using CourseworkDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseworkDB.Models
{
    public class CourseworkDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<ProductOrderLine> ProductOrderLines { get; set; }

        public DbSet<Entities.ProductionPlan> ProductionPlans { get; set; }
        
        public CourseworkDbContext(DbContextOptions<CourseworkDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}