using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasabe
{
    public partial class frmForgetPasword : Form
    {
        public frmForgetPasword()
        {
            InitializeComponent();
        }
        clsNewUser cls = new clsNewUser();
        public bool IsPasswordValid(string password)
        {
            Regex regex = new Regex(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,})");
            return regex.IsMatch(password);
        }    
        private void btnsave_Click(object sender, EventArgs e)
        {
            bool Pasword = IsPasswordValid(txtnewpasword.Text);
            if (Pasword == true)
            {
                string result = cls.ChangePassword(txtemail.Text, txtanswer.Text, txtnewpasword.Text);
                if (result == "True")
                {
                    MessageBox.Show("Save Succes ! ");
                    cls.ClearAll(this.Controls);
                }
                else
                {
                    MessageBox.Show("Incorrect Answer ! ");
                }
            }
            else
            {
                errorProvider1.SetError(txtnewpasword, "Password must contain at least 8 characters, uppercase and lowercase letters and numbers.");
            }
        }

        private void btnbacktologin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogInScreen frm = new frmLogInScreen();
            frm.Show();
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            string result = cls.QeuryToUsername(txtemail.Text);
            if (result == "True")
            {
                richTextBox1.Text = cls.GetVerificationQuestion(txtemail.Text);
            }
            else
            {
                MessageBox.Show("Invalid Username !");
            }
        }

        private void frmForgetPasword_Load(object sender, EventArgs e)
        {

        }
    }
}
