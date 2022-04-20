using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using SPP.Lab2.DB;
using SPP.Lab2.models;

namespace SPP.Lab2
{
    public partial class Lab2 : Window
    {
        private IRepository<Client> _clientRepository { get; set; }
        public static DataGrid dataGrid;
        public Lab2(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
            InitializeComponent();
            Load();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var insertPage = new InsertPage(_clientRepository);
            insertPage.ShowDialog();
        }

        public void Load()
        {
            ClientDataGrid.ItemsSource = _clientRepository.GetAll().ToList();
            dataGrid = ClientDataGrid;
        }

        private void ClientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = ((Client)ClientDataGrid.SelectedItem).Id;
            var rep = new Repository<Order>(new AppDbContext(new DbContextOptions<AppDbContext>()));
            var full = new Orders(_clientRepository, id, rep);
            full.Show();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Hide();
            mainWindow.Show();
        }
    }
}