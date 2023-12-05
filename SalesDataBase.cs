// SalesContext.cs
using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsUnicode(true)
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsUnicode(true)
                .HasMaxLength(10);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80);

            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .IsUnicode(true)
                .HasMaxLength(80);
        }
    }
}

// Customer.cs
namespace P03_SalesDatabase
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}

// Product.cs
namespace P03_SalesDatabase
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "No description";
        public double Quantity { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}

// Store.cs
namespace P03_SalesDatabase
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}

// Sale.cs
namespace P03_SalesDatabase
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; // Default value set in the database
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }
    }
}
