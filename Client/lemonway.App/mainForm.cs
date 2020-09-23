using lemonway.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lemonway.App
{
    public partial class mainForm : Form
    {
        private IWebService _webService;

        public mainForm()
        {
            InitializeComponent();
            _webService = new WebService();
        }

        private async void btnCompute_ClickAsync(object sender, EventArgs e)
        {
            this.Enabled = false;
            var form = new busyForm();
            form.Show();
            // Declare, assign, and start the antecedent task.
            var taskA = Task.Run(() =>
            {
                Thread.Sleep(2000); //2s
                return _webService.Fibonacci(10);
            });

            await taskA.ContinueWith(t =>
            {
                form.Close();
                this.Enabled = true;
                if (t.IsFaulted)
                {
                    // faulted with exception
                    Exception ex = t.Exception;
                    while (ex is AggregateException && ex.InnerException != null)
                        ex = ex.InnerException;
                    MessageBox.Show("Error: " + ex.Message);
                }
                else
                {

                    MessageBox.Show($"Result is {t.Result}");
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
