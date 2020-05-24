using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPoleSystemUI
{
    public partial class InactivityMessageBox : Form
    {
        Timer msgTimer = new Timer();
        static InactivityMessageBox newMessageBox;
        static string Button_id;
        int disposeFormTimer;
        public InactivityMessageBox()
        {
            InitializeComponent();
        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            disposeFormTimer = 10;
            msgTimer.Interval = 1000;
            msgTimer.Enabled = true;
            msgTimer.Start();
            msgTimer.Tick += new System.EventHandler(timer_tick);
        }
        public static string ShowBox(string txtMessage, string txtTitle)
        {
            newMessageBox = new InactivityMessageBox();
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.Text = txtTitle;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            Button_id = "1";
            msgTimer.Stop();
            newMessageBox.Dispose();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Button_id = "2";
            msgTimer.Stop();
            newMessageBox.Dispose();
        }
        private void timer_tick(object sender, EventArgs e)
        {
            disposeFormTimer--;

            if (disposeFormTimer >= 0)
            {
                newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            }
            else
            {
                Button_id = "1";
                msgTimer.Stop();
                newMessageBox.Dispose();

            }
        }

        private void MyMessageBox_Load_1(object sender, EventArgs e)
        {

        }
    }
}
