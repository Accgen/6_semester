using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SPP.Lab2.DB;
using SPP.Lab2.models;

namespace SPP.Lab2
{
    public partial class Orders : Window
    {
        private IRepository<Client> _clientRepository { get; set; }
        private IRepository<Order> _orderRepository { get; set; }
        public static DataGrid dataGrid;
        private int Id { get; set; }
        
        public Orders(IRepository<Client> clientRepository, int id,
                IRepository<Order> orderRepository)
        {
            InitializeComponent();
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
            Id = id;
            Load();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addOrder = new AddOrder(_orderRepository, Id);
            addOrder.ShowDialog();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Hide();
            mainWindow.Show();
        }
        private void Load()
        {
            var info = _orderRepository
                .Include(owner => owner.Client,
                    owner => owner.OrderSummary)
                .ToList().Where(owner => owner.ClientId == Id);

            var list = new List<Order>();
            if (info != null)
            {
                list = info.Select(owner => new Order
                {
                    Id = owner.Id,
                    TotalSum = owner.TotalSum,
                    DateOfOrder = owner.DateOfOrder
                }).ToList();
            }
            
            FullInfoDataGrid.ItemsSource = list;
            dataGrid = FullInfoDataGrid;
        }
        
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Order)dataGrid.SelectedItem).Id;
            var updatePage = new UpdatePage(id, _orderRepository);
            updatePage.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Order)dataGrid.SelectedItem).Id;
            var deleted = _orderRepository.GetById(id);
            
            _orderRepository.Delete(deleted.Id);
            Load();
        }
    }
}