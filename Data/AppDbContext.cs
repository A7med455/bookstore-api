using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;

namespace BookStoreAPI.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor — empty body, just passes config up to the base DbContext class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties — separate class members, NOT inside the constructor
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}