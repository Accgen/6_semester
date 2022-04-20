using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    public partial class MainWindow : Window
    {
        private readonly HubConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            PersonBtn.IsEnabled = false;

            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5155/chat")
                .WithAutomaticReconnect()
                .Build();

            Connect();
            
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        private async void Connect()
        {
            connection.On<string, string>("Send", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    MessagesList.Items.Add(newMessage);
                });
            });
            
            connection.On<string, string>("SendToPerson", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    MessagesList.Items.Add(newMessage);
                });
            });

            try
            {
                await connection.StartAsync();
                MessagesList.Items.Add("Connection started");
            }
            catch (Exception) { }
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.InvokeAsync("Send", connection.ConnectionId, MessageBox.Text);
                MessageBox.Clear();
            }
            catch (Exception ex) { }
        }
        
        private async void Send_ClickPrivate(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendToPerson", UserBox.Text ,connection.ConnectionId, MessageBox.Text);
                MessageBox.Clear();
            }
            catch (Exception ex) { }
        }

        private void MessagesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UserBox.Clear();
            var id = e.AddedItems[0].ToString().Split(":").First();
            UserBox.Text = id;
            PersonBtn.IsEnabled = true;
        }
    }
}
