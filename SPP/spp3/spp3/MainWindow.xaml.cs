using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using spp3.View;
using spp3.Model1;

namespace spp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillTable();
        }

        public void FillTable()
        {
            using RentContext context = new RentContext();
            DtaGrid.ItemsSource = context.Rents
                .Include(r => r.Car)
                .Include(r => r.Rate)
                .Include(r => r.Client)
                .Include(r => r.Car.Provider)
                .ToList();
        }

        private void AddRate(object sender, RoutedEventArgs e)
        {
            var addRate = new AddRate();
            if (addRate.ShowDialog() == true)
            {
                using RentContext context = new RentContext();
                context.Rates.Add(new Rate() { Name = addRate.Name.Text, Price = addRate.Price.Text });
                context.SaveChanges();
            }
        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            var addCar = new AddCar();
            if (addCar.ShowDialog() == true)
            {
                using RentContext context = new RentContext();
                var providerId = context.Providers.FirstOrDefault(r => r.Name == addCar.Provider.Text)?.Id;
                if (providerId != null)
                    context.Cars.Add(new Car()
                        {Name = addCar.Name.Text, Year_release = addCar.Year.Text, ProviderId = providerId.Value});
                context.SaveChanges();
            }
        }

        private void AddProvider(object sender, RoutedEventArgs e)
        {
            var addProvider = new AddProvider();
            if (addProvider.ShowDialog() == true)
            {
                using RentContext context = new RentContext();
                context.Providers.Add(new Provider()
                    { Name = addProvider.Name.Text, Country = addProvider.Country.Text });
                context.SaveChanges();
            }
        }
        private void AddClient(object sender, RoutedEventArgs e)
        {
            var addClient = new AddClient();
            if (addClient.ShowDialog() == true)
            {
                using RentContext context = new RentContext();
                context.Clients.Add(new Client()
                {
                    Name = addClient.Name.Text, Passport = addClient.Passwort.Text, Sourname = addClient.Sourname.Text
                });
                context.SaveChanges();
            }
        }
        private void AddRent(object sender, RoutedEventArgs e)
        {
            var addRent = new AddRent();
            if (addRent.ShowDialog() == true)
            {
                using RentContext context = new RentContext();
                var clientId = context.Clients.FirstOrDefault(r => r.Name == addRent.Client.Text)?.Id;
                var carId = context.Cars.FirstOrDefault(r => r.Name == addRent.Car.Text)?.Id;
                var rateId = context.Rates.FirstOrDefault(r => r.Name == addRent.Rate.Text)?.Id;
                if (carId != null && clientId != null && rateId != null)
                    context.Rents.Add(new Rent()
                    {
                        Name = addRent.Name.Text, CarId = carId.Value, ClientId = clientId.Value,
                        RateId = rateId.Value
                    });
                context.SaveChanges();
                FillTable();
            }
        }

        private void DtaGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = DtaGrid.SelectedItem as Rent;
            var updateRent = new UpdateRent(selectedItem);
            if (updateRent.ShowDialog() == true)
            {
                using RentContext context = new RentContext();
                var item = context.Rents.First(r => r == selectedItem);
                var clientId = context.Clients.FirstOrDefault(r => r.Name == updateRent.Client.Text)?.Id;
                var carId = context.Cars.FirstOrDefault(r => r.Name == updateRent.Car.Text)?.Id;
                var rateId = context.Rates.FirstOrDefault(r => r.Name == updateRent.Rate.Text)?.Id;
                if (carId != null && clientId != null && rateId != null)
                {
                    item.Name = updateRent.Name.Text;
                    item.CarId = (int) carId;
                    item.ClientId = (int) clientId;
                    item.RateId = (int) rateId;
                    context.Rents.Update(item);
                }
                context.SaveChanges();
            }
            FillTable();
        }
    }
}
