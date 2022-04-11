using System;
using System.Linq;
using Lab_3._1;
using Microsoft.EntityFrameworkCore;

namespace Lab_3._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using RentContext context = new RentContext();

            Console.WriteLine("\"SELECT\" Cars:");
            var cars = context.Cars.ToList();
            foreach (var car in cars)
            {
                Console.WriteLine($"Name: {car.Name}\n" +
                                  $"Release year: {car.Name}\n");
            }
            Console.WriteLine("\"SELECT ORDER BY\" Cars:");
            var cars1 = context.Cars
                .OrderBy(r => r.Year_release)
                .ToList();
            foreach (var car in cars1)
            {
                Console.WriteLine($"Name: {car.Name}\n" +
                                  $"Sourname: {car.Name}\n");
            }

            Console.WriteLine("\n\"INSERT\" Client:");
            Console.WriteLine("\"INSERT\" Before:");
            foreach (var client in context.Clients.ToList())
            {
                Console.WriteLine($"Name: {client.Name}\n" +
                                  $"Passport: {client.Passport}\n" +
                                  $"Sourname: {client.Sourname}\n");
            }
            context.Clients.AddRange(
                new Client { Name = "Andrey", Sourname = "Guzarevich", Passport = "AB239843" },
                new Client { Name = "Stas", Sourname = "Kotashevich", Passport = "AB1111112" });
            context.SaveChanges();
            Console.WriteLine("\"INSERT\" After:");
            foreach (var client in context.Clients.ToList())
            {
                Console.WriteLine($"Name: {client.Name}\n" +
                                  $"Passport: {client.Passport}\n" +
                                  $"Sourname: {client.Sourname}\n");
            }

            Console.WriteLine("\n\"DELETE\" Client:");
            Console.WriteLine("\"DELETE\" Before:");
            foreach (var client in context.Clients.ToList())
            {
                Console.WriteLine($"Name: {client.Name}\n" +
                                  $"Passport: {client.Passport}\n" +
                                  $"Sourname: {client.Sourname}\n");
            }

            var delete = context.Clients.Where(c => c.Id == 5 || c.Id == 6);
            context.Clients.RemoveRange(delete);
            context.SaveChanges();
            Console.WriteLine("\"DELETE\" After:");
            foreach (var client in context.Clients.ToList())
            {
                Console.WriteLine($"Name: {client.Name}\n" +
                                  $"Passport: {client.Passport}\n" +
                                  $"Sourname: {client.Sourname}\n");
            }

            Console.WriteLine("\n\"UPADATE\" Before:");
            var update1 = context.Clients.First(t => t.Id == 3);
            Console.WriteLine($"Passport: {update1.Passport}");
            Console.WriteLine("\"UPADATE\" After:");
            update1.Passport = "AB0000000";
            context.Clients.Update(update1);
            context.SaveChanges();
            update1 = context.Clients.First(t => t.Id == 3);
            Console.WriteLine($"Passport: {update1.Passport}");
        }
    }
}
