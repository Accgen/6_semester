using System.Linq;
using System.Windows;
using spp3.Model1;

namespace spp3.View
{
    /// <summary>
    /// Логика взаимодействия для AddRacer.xaml
    /// </summary>
    public partial class AddRent : Window
    {
        public AddRent()
        {
            InitializeComponent();
            using RentContext context = new RentContext();

            Client.ItemsSource = context.Clients
                .Select(r => r.Name)
                .ToList();
            Car.ItemsSource = context.Cars
                .Select(c => c.Name)
                .ToList();
            Rate.ItemsSource = context.Rates
                .Select(t => t.Name)
                .ToList();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
