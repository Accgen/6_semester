using Microsoft.EntityFrameworkCore;
using SPP.Lab2.models;

namespace SPP.Lab2.DB
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions _options;
    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            _options = options;
        }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderSummary> OrderSummaries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasMany(r => r.Orders)
                    .WithOne(r => r.Client)
                    .HasForeignKey(r => r.ClientId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(r => r.OrderSummary)
                    .WithOne(r => r.Order)
                    .HasForeignKey<OrderSummary>(r => r.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<OrderSummary>(entity =>
            {
                entity.HasMany(r => r.Product)
                    .WithOne(r => r.OrderSummary)
                    .HasForeignKey(r => r.OrderSummaryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(r => r.Manufacturer)
                    .WithOne(r => r.Product)
                    .HasForeignKey<Manufacturer>(r => r.ProductId);
            });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MAKSIM;" +
                                        "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                                        "ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); 
        }
    }
}