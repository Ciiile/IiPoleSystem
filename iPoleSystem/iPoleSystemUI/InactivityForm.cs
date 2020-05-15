using iPoleSystemLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Threading;


namespace iPoleSystemUI
{
    public class InactivityForm : Form
    {
        public event EventHandler Inactivity;
        private IIPoleSystem PoleSystem { get; set; }

        public InactivityForm (IIPoleSystem poleSystem)
        {
            KeyPreview = true;

            MouseMove += InactivityForm_MouseMove;
            FormClosed += InactivityForm_FormClosed;
            KeyDown += InactivityForm_KeyDown;

            PoleSystem = poleSystem;
        }

        protected virtual void UserInactivity(EventArgs e)
        {
            var userActivity = Inactivity;
            if(userActivity != null)
            {
                userActivity(this, e);
            }
        }

        private void InactivityForm_MouseMove(object sender, MouseEventArgs e)
        {
            UserInactivity(e);
        }

        private void InactivityForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MouseMove -= InactivityForm_MouseMove;
            FormClosed -= InactivityForm_FormClosed;
            KeyDown -= InactivityForm_KeyDown; 
        }

        private void InactivityForm_KeyDown(object sender, KeyEventArgs e)
        {
            UserInactivity(e);
        }

        private System.Threading.Timer timer = new System.Threading.Timer(InactivityTimer, null, 1000 * 1 * 60, Timeout.Infinite);
        private void _UserInactivity(object sender, EventArgs e)
        {
            if(timer != null)
            {
                timer.Change(1000 * 1 * 60, Timeout.Infinite);
            }
        }

        private static void InactivityTimer(object state)
        {
       
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InactivityForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "InactivityForm";
            this.Load += new System.EventHandler(this.InactivityForm_Load);
            this.ResumeLayout(false);

        }

        private void InactivityForm_Load(object sender, EventArgs e)
        {

        }
    }

}
