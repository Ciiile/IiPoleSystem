using iPoleSystemLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPoleSystemUI
{
    public partial class MyBookingsToday : Form
    {
        private IIPoleSystem PoleSystem { get; set; }
        //public IIPoleSystem poleSystem { get; set; }
        public MyBookingsToday(IIPoleSystem poleSystem)
        {
            InitializeComponent();

            //Isystem.CreateCheckboxes();

            PoleSystem = poleSystem;

        }

        //This method closes the form, assigns the current user' login status to false
        //and calls the login form.
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm login = new LoginForm(PoleSystem);
            login.Show();
        }

        private void MyBookingsToday_Load(object sender, EventArgs e)
        {
            foreach (CheckBox ck in IPoleSystem.CheckBoxes)
            {
                Controls.Add(ck);
            }
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void AttendOpenGymButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have attended Open Gym");
            WriteInOpenGymFile();
        }

        //This method writes in OpenGym.csv the current user's member Id and the time
        //of which the user attened Open Gym.
        private void WriteInOpenGymFile()
        {
            User currentUser = PoleSystem.FindUserFromLoginStatus();
            DateTime now = DateTime.Now;
            using (StreamWriter SW = File.AppendText("OpenGym.csv"))
            {
                SW.WriteLine(currentUser.MemberId + "," + now);
            }
        }

        private void MyFutureBookingsButton_Click(object sender, EventArgs e)
        {
            MyFutureBookings();
        }

        private void ChooseAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Do_Checked();
        }

        //This method checks or unchecks all the checkboxes, based on the state of ChooseAllCheckbox
        private void Do_Checked()
        {

            if (ChooseAllCheckbox.CheckState == CheckState.Checked)
            {
                foreach (CheckBox cb in IPoleSystem.CheckBoxes)
                {
                    cb.CheckState = CheckState.Checked;
                }
            }
            else if (ChooseAllCheckbox.CheckState == CheckState.Unchecked)
            {
                foreach (CheckBox cb in IPoleSystem.CheckBoxes)
                {
                    cb.CheckState = CheckState.Unchecked;
                }
            }
        }

        //This method hides the current form and calls the MyFutureBookings form.
        private void MyFutureBookings()
        {
            this.Hide();

            MyFutureBookings nextPage = new MyFutureBookings(PoleSystem);
            nextPage.Show();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //This method checks if the checkbox for attending is checked and shows a message box.
        private void AttendButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CheckBox cb in IPoleSystem.CheckBoxes)
            {
                if (cb.CheckState == CheckState.Checked)
                {
                    sb.AppendLine(cb.Text);
                }
            }
            Do_Checked();
            MessageBox.Show("You are now attending the classes:\n" + sb);
        }
    }
}
