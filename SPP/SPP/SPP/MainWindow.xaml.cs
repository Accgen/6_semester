using System.Windows;
using Microsoft.EntityFrameworkCore;
using SPP.Lab2.DB;
using SPP.Lab2.models;

namespace SPP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Lab_1_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var lab1 = new Lab1();
            lab1.Show();
        }

        private void Lab_2_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var appDbContext = new AppDbContext(new DbContextOptions<AppDbContext>());
            var clientRepository = new Repository<Client>(appDbContext);
            var lab1 = new Lab2.Lab2(clientRepository);
            lab1.Show();
        }
    }
}
