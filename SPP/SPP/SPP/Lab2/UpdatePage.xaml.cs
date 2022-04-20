using System;
using System.Linq;
using System.Windows;
using SPP.Lab2.DB;
using SPP.Lab2.models;

namespace SPP.Lab2
{
    public partial class UpdatePage : Window
    {
        private IRepository<Order> _orderRepository { get; set; }
        private int Id { get; set; }
        public UpdatePage(int id, IRepository<Order> orderRepository)
        {
            InitializeComponent();
            Id = id;
            _orderRepository = orderRepository;
            LoadUpdate(id);
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var order = _orderRepository.GetById(Id);
            order.TotalSum = decimal.Parse(TotalSum.Text);
            order.DateOfOrder = DateTime.Now;

            _orderRepository.Update(order);
            var client = _orderRepository.GetById(Id);
            Orders.dataGrid.ItemsSource = _orderRepository.GetAll().Where(order1 => order1.ClientId == client.ClientId).ToList(); 
            Hide();
        }

        private void LoadUpdate(int id)
        {
            var client = _orderRepository.GetById(id);
            TotalSum.Text = client.TotalSum.ToString();
        }
    }
}