using iPoleSystemLibrary;
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
    public partial class LoginForm : Form
    {
        private IIPoleSystem PoleSystem { get; set; }

        public LoginForm(IIPoleSystem poleSystem)
        {
            InitializeComponent();

            PoleSystem = poleSystem;

            //foreach (User u in IPoleSystem.AllUsers)
            //{
            //    u.LoginStatus = false;
            //}

            PoleSystem.DeleteUnnecessaryStringsFromOpenGym();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        //This method checks if the inputs are correct and logs the user in,
        //if that is the case. It also assigns the current users login status
        // to true.
        private void Login()
        {
            string idString = textBoxMemberID.Text;
            string password = textBoxPassword.Text;
            bool LoginStatus = false;
            bool result = Int32.TryParse(idString, out int id);

            if (result == false)
            {
                MessageBox.Show("Member ID must be a number");
                textBoxMemberID.Text = "";
                textBoxPassword.Text = "";
            }
            else
            {
                foreach (User u in IPoleSystem.AllUsers)
                {
                    if (id == u.MemberId && password == u.Password)
                    {
                        
                        this.Hide();

                        
                        u.LoginStatus = true;
                        LoginStatus = true;

                        MyBookingsToday nextPage = new MyBookingsToday(PoleSystem);
                        nextPage.Show();
                    }
                    else
                    {
                        u.LoginStatus = false;
                    }
                }
                if (LoginStatus == false)
                {
                    MessageBox.Show("Wrong username or password");
                    textBoxPassword.Text = "";
                }
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextMemberID_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Login();
            }
        }

        private void TextPassword_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MemberIDTextBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
