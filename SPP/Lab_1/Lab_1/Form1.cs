using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        public void StartBtn_Click(object sender, EventArgs e)
        {
            thread = new Thread(Calc);
            thread.Start();           
        }
        void Calc()
        {
            double X, N;
            double a;
            double sum = 0;
            long i = 1;
            X = Convert.ToDouble(FieldX.Text);
            N = Convert.ToDouble(FieldN.Text);

            long Fact(long n)
            {
                if (n == 0)
                    return 1;
                else
                    return n * Fact(n - 1);
            }

            while (i <= N)
            {
                long fact = Fact(i);
                a = (Math.Pow(X, i)) / (fact);
                sum += a;
                i++;
            }
            ResultBox.Invoke(new Action(() => ResultBox.Text = Convert.ToString(sum + 1)));
            //ResultBox.Text = Convert.ToString(sum + 1);
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            //Очистить поля , а так же прекратить работу потока
            FieldN.Text = " ";
            FieldX.Text = " ";
            ResultBox.Text = " ";
            try
            {
                thread.Interrupt();

            }
            catch (ThreadInterruptedException)
            { }
        }
    }
}
