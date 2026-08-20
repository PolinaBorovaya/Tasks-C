using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15.Async_Await
{
    public partial class Form1 : Form
    {
        Timer timer;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            dbInfoTextBox.ReadOnly = true;
            disconnectToDbButton.Enabled = false;
            setupTimer();
        }

        private async void connectToDbButton_Click(object sender, EventArgs e)
        {
            try
            {
                dbInfoTextBox.AppendText("Подключение...\r\n");

                int delay = random.Next(3000, 5000);
                await Task.Delay(delay);

                dbInfoTextBox.AppendText("Подключен к базе данных\r\n");
                timer.Start();

                disconnectToDbButton.Enabled = true;
                connectToDbButton.Enabled = false;
            } 
            catch(Exception ex)
            {
                dbInfoTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] Ошибка: {ex.Message}\r\n");
                connectToDbButton.Enabled = true;
            }
        }

        private async void disconnectToDbButton_Click(object sender, EventArgs e)
        {
            try
            {
                dbInfoTextBox.AppendText("Отключение...\r\n");

                int delay = random.Next(3000, 5000);
                await Task.Delay(delay);

                dbInfoTextBox.AppendText("Отключен от базы данных\r\n");

                timer.Stop();
                disconnectToDbButton.Enabled = false;
                connectToDbButton.Enabled = true;
            }
            catch (Exception ex)
            {
                dbInfoTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] Ошибка: {ex.Message}\r\n");
                disconnectToDbButton.Enabled = true;
            }

        }

        private void setupTimer()
        {
            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            dbInfoTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] Данные получены\r\n");
        }
    }
}
