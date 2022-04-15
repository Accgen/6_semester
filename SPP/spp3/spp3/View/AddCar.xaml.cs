using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using spp3.Model1;

namespace spp3.View
{
    /// <summary>
    /// Логика взаимодействия для AddLocation.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        public AddCar()
        {
            InitializeComponent();

            using RentContext context = new RentContext();
            Provider.ItemsSource = context.Providers
                .Select(r => r.Name)
                .ToList();
            var a = (Provider.ItemsSource as List<string>)?.Count;
            if (a is 0)
            {
                Label.Visibility = Visibility.Visible;
                insertBtn.IsEnabled = false;
            }
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
