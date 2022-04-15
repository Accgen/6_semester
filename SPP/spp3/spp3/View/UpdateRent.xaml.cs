using System.Linq;
using System.Windows;
using spp3.Model1;

namespace spp3.View
{
    /// <summary>
    /// Логика взаимодействия для UpdateRacer.xaml
    /// </summary>
    public partial class UpdateRent : Window
    {
        private static Rent _rent;
        public UpdateRent(Rent rent)
        {
            InitializeComponent();
            using RentContext context = new RentContext();
            _rent = rent;
            Client.ItemsSource = context.Clients
                .Select(r => r.Name)
                .ToList();
            Car.ItemsSource = context.Cars
                .Select(c => c.Name)
                .ToList();
            Rate.ItemsSource = context.Rates
                .Select(t => t.Name)
                .ToList();
            Client.SelectedItem = rent.Client.Name;
            Car.SelectedItem = rent.Car.Name;
            Rate.SelectedItem = rent.Rate.Name;
            Name.Text = rent.Name;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using RentContext context = new RentContext();
            context.Rents.Remove(context.Rents.First(r => r == _rent));
            context.SaveChanges();
            this.Close();
        }
    }
}
