using iPoleSystemLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPoleSystemUI
{
    public partial class MyFutureBookings : Form
    {
        private IIPoleSystem PoleSystem { get; set; }
        public MyFutureBookings(IIPoleSystem poleSystem)
        {
            InitializeComponent();

            PoleSystem = poleSystem;
            bool MyBookingsToday = false;
            PoleSystem.CreateCheckboxes(MyBookingsToday);
        }

        private void MyFutureBookings_Load(object sender, EventArgs e)
        {
            foreach (CheckBox ck in IPoleSystem.CheckBoxes)
            {
                Controls.Add(ck);
            }
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void ChooseAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Do_Checked();
        }

        private void BookAClassButton_Click(object sender, EventArgs e)
        {

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

        //This method closes the form, assigns the current user' login status to false
        //and calls the login form.
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm login = new LoginForm(PoleSystem);
            login.Show();
        }

        //Method that hides the current form and then shows the form MyBookingsToday which 
        //is the previous page
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyBookingsToday previousPage = new MyBookingsToday(PoleSystem);
            previousPage.Show();
        }

        //This method checks if the checkbox for attending is checked and shows a message box.
        private void AttendButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<string> classesAttended = new List<string>();
            List<FitnessClass> fitnessClassList = new List<FitnessClass>();
            foreach (CheckBox cb in IPoleSystem.CheckBoxes)
            {
                if (cb.CheckState == CheckState.Checked)
                {
                    sb.AppendLine(cb.Text);
                    classesAttended.Add(cb.Text);
                }
            }
            fitnessClassList = PoleSystem.FindClassFromStringList(classesAttended);
            PoleSystem.WriteInAttendLog(fitnessClassList);
            foreach (FitnessClass fitnessClass in fitnessClassList)
            {
                PoleSystem.RemoveUserIDFromClassFile(fitnessClass);
                PoleSystem.RemoveClassIDFromUserFile(fitnessClass);
            }

            Do_Checked();
            MessageBox.Show("You are now attending the classes:\n" + sb);
            
        }
    }
}
