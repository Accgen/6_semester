using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SPP
{
    public partial class Lab1 : Window
    {
        private CancellationTokenSource cancelTokenSource;
        private CancellationToken token;
        private string result { get; set; }
        private bool isPause;

        public Lab1()
        {
            InitializeComponent();
        }
        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            await RunTask();
            Sum.Text = result;
        }
        private async Task RunTask()
        {
            var k = GetKValue();
            if (k <= 0) return;
            
            await Task.Run(async () =>
            {
                var value = await Calculate(k);
                result = Math.Round(value, 4).ToString(CultureInfo.InvariantCulture);
            });
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            isPause = true;
            MessageBox.Show("Thread pause");
        }
        private void Resume_Click(object sender, RoutedEventArgs e)
        {
            isPause = false;
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            cancelTokenSource.Cancel();
        }
        private void KValue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private int GetKValue()
        {
            if (int.TryParse(KValue.Text, out var k))
            {
                if (k > 0)
                    return k;
                
                MessageBox.Show("K must be greater than 0!");
            }
            else
            {
                MessageBox.Show("K must be number");
            }

            return 0;
        }
        private async Task<double> Calculate(int k)
        {
            double sum = 0;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            
            for (int i = 1; i <= k; i++)
            {
                while (isPause) {}

                if (token.IsCancellationRequested)
                {
                    MessageBox.Show("Thread was stopped");
                    return 0;
                }

                sum += 1.0d / ((2 * i - 1) * (2 * i + 1));
                Thread.Sleep(500);
            }
            return sum;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Hide();
            mainWindow.Show();
        }
    }
}
