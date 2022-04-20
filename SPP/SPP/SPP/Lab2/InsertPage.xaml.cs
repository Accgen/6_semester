using System.Collections.Generic;
using System.Linq;
using System.Windows;
using SPP.Lab2.DB;
using SPP.Lab2.models;

namespace SPP.Lab2
{
    public partial class InsertPage : Window
    {
        private IRepository<Client> _clientRepository { get; set; }
        public InsertPage(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client
            {
                FirstName = nameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Email = emailTextBox.Text,
                Orders = new List<Order>(),
                NickName = NicknameTextBox.Text,
                PhoneName = "1111111",
                Gender = Gender.Male
            };
            
            _clientRepository.Create(client);
            Lab2.dataGrid.ItemsSource = _clientRepository.GetAll().ToList(); 
            Hide();
        }
    }
}