using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13.Асинхронность2
{
    public partial class Form1 : Form
    {
        private delegate int ComputeDelegate(int a, int b);

        private IAsyncResult asyncResultIsComplete;
        private IAsyncResult asyncResultEnd;
        private IAsyncResult asyncResultCallback;
        public Form1()
        {
            InitializeComponent();
        }

        private void isCompleteButton_Click(object sender, EventArgs e)
        {
            ComputeDelegate computeDelegate = Compute;
            asyncResultIsComplete = computeDelegate.BeginInvoke(50, 80, null, null);

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (s,args)=>{
                if (asyncResultIsComplete.IsCompleted)
                {
                    timer.Stop();

                    int result = computeDelegate.EndInvoke(asyncResultIsComplete);
                    MessageBox.Show($"IsComplete: Результат = {result}");
                }
            };

            timer.Start();
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            ComputeDelegate computeDelegate = Compute;
            asyncResultEnd = computeDelegate.BeginInvoke(50, 80, null, null);

            int result = computeDelegate.EndInvoke(asyncResultEnd);
            MessageBox.Show($"EndInvoke: Результат = {result}");
        }

        private void callbackButton_Click(object sender, EventArgs e)
        {
            ComputeDelegate computeDelegate = Compute;
            asyncResultCallback = computeDelegate.BeginInvoke(50, 80, new AsyncCallback(Callback), "Сложение 50+80");
        }

        private int Compute(int a, int b)
        {
            Thread.Sleep(3000);
            return a + b;
        }

        private void Callback(IAsyncResult async)
        {
            try
            {
                string state = (string)async.AsyncState;
                AsyncResult res = (AsyncResult)async;

                ComputeDelegate computeDelegate = (ComputeDelegate) res.AsyncDelegate;

                int output = computeDelegate.EndInvoke(async);

                this.Invoke((Action)(() =>
                {
                    MessageBox.Show($"Callback: Результат = {output}\nState: {state}");
                }));


            } catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show($"Callback ошибка: {ex.Message}");
                }));
            }
        }
    }
}
