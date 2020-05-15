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
    public partial class BookANewClass : Form
    {
        private IIPoleSystem PoleSystem { get; set; }
        public BookANewClass(IIPoleSystem poleSystem)
        {
            InitializeComponent();

            PoleSystem = poleSystem;
        }

        private void Title_TextChanged(object sender, EventArgs e)
        {

        }

        //Method that hides the current form, assigns the value false to the current user's 
        //login status and finally shows the login form for the next user to use.
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
    }
}
