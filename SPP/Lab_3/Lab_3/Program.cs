using System.Linq;
using Lab_3.DataModels;
using Microsoft.EntityFrameworkCore;

using RentContext context = new RentContext();


Console.WriteLine("\"SELECT\" Rents:");
var rent = context.Rents
                .Include(r => r.Clients)
                .ToList();
foreach (var rent1 in rent)
{
    Console.WriteLine($"Name: {rent1.Name}\n" +
                      $"Location: {rent1.Clients.Sourname}\n" +
                      $"Country: {rent1.Clients.Passport}");
}