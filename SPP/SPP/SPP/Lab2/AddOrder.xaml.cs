using System;
using System.Linq;
using System.Windows;
using SPP.Lab2.DB;
using SPP.Lab2.models;

namespace SPP.Lab2
{
    public partial class AddOrder : Window
    {
        private readonly IRepository<Order> _repository;
        private int Id;
        public AddOrder(IRepository<Order> repository, int id)
        {
            _repository = repository;
            Id = id;
            InitializeComponent();
        }

        private void CreateOrderClick(object sender, RoutedEventArgs e)
        {
            var client = new Order
            {
                TotalSum = decimal.Parse(TotalSum.Text),
                DateOfOrder = DateTime.Now,
                ClientId = Id
            };

            _repository.Create(client);
            var order = _repository.GetById(Id);
            Orders.dataGrid.ItemsSource = _repository.GetAll().Where(order1 => order1.ClientId == order.ClientId).ToList();
            Hide();
        }
    }
}