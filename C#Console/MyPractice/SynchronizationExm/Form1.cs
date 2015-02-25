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

namespace SynchronizationExm
{
    public partial class Form1 : Form
    {
        SynchronizationContext context;
        public Form1()
        {
            context = SynchronizationContext.Current;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {

                int result = await LongRunningTask().ConfigureAwait(false);
                label1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private async Task<int> LongRunningTask()
        {
            int result = 0;
            for(int i = 0; i < int.MaxValue; i++)
            {
                result = i;
                if (i > 5000)
                {
                    throw new OperationCanceledException("Cancelled");
                }
            }
            return result;
        }

        
    }
}
