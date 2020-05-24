using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPoleSystemLibrary;

namespace iPoleSystemUI
{
    public partial class InactivityTimer : Form
    {
        private IIPoleSystem PoleSystem { get; set; }

        // Internal = only accessible within this assembly - Static = used in MessageFilter to reset timer.
        internal static Timer timerIdle;
        public InactivityTimer(IIPoleSystem poleSystem)
        {
            InitializeComponent();

            timerIdle = new System.Windows.Forms.Timer();
            timerIdle.Enabled = true;
            timerIdle.Interval = 5000; // Idle time period. Here after 30 seconds perform task in  timerIdle_Tick.
            timerIdle.Tick += new EventHandler(TimerIdle_Tick);
            PoleSystem = poleSystem;
        }

        private void InactivityTimer_Load(object sender, EventArgs e)
        {

        }

        // Every predefined timer duration above a custom messagebox will appear
        // btnClicked == 1 is "Yes" while nothing happens when Cancel is clicked.
        private void TimerIdle_Tick(object sender, EventArgs e)
        {
            timerIdle.Stop();
            string btnClicked = InactivityMessageBox.ShowBox("Do you want to log out?", "Inactivity noticed");
            if (btnClicked == "1")
            {
                LoginForm log = new LoginForm(PoleSystem);
                Form currentForm = Form.ActiveForm;
                currentForm.Hide();
                log.ShowDialog();
                currentForm.Close();
            }
        }

        private void InactivityTimer_Load_1(object sender, EventArgs e)
        {

        }
    }
}

