using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab_3._1
{
    sealed class RentContext : DbContext
    {
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }


        public RentContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = RentalCars; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().HasData(
                new Provider() { Id = 1, Name = "Audi", Country = "Germany" },
                new Provider() { Id = 2, Name = "Lada", Country = "Russia" });
            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 1, Name = "Audi-100", Year_release = "1987", ProviderId = 1 },
                new Car() { Id = 2, Name = "Audi-80", Year_release = "1995", ProviderId = 1 },
                new Car() { Id = 3, Name = "Lada Granta", Year_release = "2000", ProviderId = 2 });
            modelBuilder.Entity<Rate>().HasData(
                new Rate { Id = 1, Name = "Usual", Price = "150" },
                new Rate { Id = 2, Name = "Vip", Price = "300" });
            modelBuilder.Entity<Rent>().HasData(
                new Rent() { Id = 1, Name = "Month", CarId = 1, ClientId = 1, RateId = 2 },
                new Rent() { Id = 2, Name = "Half year", CarId = 2, ClientId = 2, RateId = 2 },
                new Rent() { Id = 3, Name = "Day", CarId = 1, ClientId = 3, RateId = 2 },
                new Rent() { Id = 4, Name = "Week", CarId = 3, ClientId = 1, RateId = 1 });
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Andrey", Sourname = "Guzarevich", Passport = "AB239842" },
                new Client { Id = 2, Name = "Stas", Sourname = "Kotashevich", Passport = "AB1111111" },
                new Client { Id = 3, Name = "Alexey", Sourname = "Lud", Passport = "A2222222" },
                new Client { Id = 4, Name = "Vlad", Sourname = "Shuk", Passport = "A3333333" });
        }
    }
}
