using BusinessLayer;
using System;
using System.Collections;
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
    public partial class frmSignInScreen : Form
    {
        public frmSignInScreen()
        {
            InitializeComponent();
        }
        public string ID { get; set; }
        public bool IsEmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(email);
        }
        public bool IsPasswordValid(string password)
        {
            Regex regex = new Regex(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,})");
            return regex.IsMatch(password);
        }
        private void btnsignin_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            clsNewUser cls = new clsNewUser();
            bool Email = IsEmailValid(txtemail.Text);
            bool Pasword = IsPasswordValid(txtpassword.Text);
            errorProvider1.Clear();
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    ht.Add(item.Tag, item.Text);
                }

                if (item is ComboBox)
                {
                    ht.Add(item.Tag, item.Text);
                }
            }
            if (txtemail.Text != string.Empty && txtemail.BackColor == Color.Green)
            {
                if (Email == true && Pasword == true)
                {
                    ID = cls.Add(ht).ToString();
                    cls.ClearAll(this.Controls);
                    MessageBox.Show("New Record Created");
                }
                else if (Email != true && Pasword == true)
                {
                    errorProvider1.SetError(txtemail, "_____@___.com");
                }
                else if (Email == true && Pasword != true)
                {
                    errorProvider1.SetError(txtpassword, "Password must contain at least 8 characters, uppercase and lowercase letters and numbers.");
                }
                else
                {
                    errorProvider1.SetError(txtemail, "_____@___.com");
                    errorProvider1.SetError(txtpassword, "Password must contain at least 8 characters, uppercase and lowercase letters and numbers.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid username !");
            }                                 
        }
        private void btnbacktologin_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogInScreen frm = new frmLogInScreen();
            frm.Show();
        }

        private void frmSignInScreen_Load(object sender, EventArgs e)
        {
            lbl_warning.Visible = false;
        }
        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            string result = string.Empty;
            clsNewUser cls = new clsNewUser();
            if (txtemail.Text != string.Empty)
            {
                result = cls.QeuryToUsername(txtemail.Text);
            }

            if (txtemail.Text == string.Empty)
            {
                txtemail.BackColor = Color.White;
            }
            if (result == "False")
            {
                txtemail.BackColor = Color.Green;
                lbl_warning.Visible = false;

            }
            else if (result == "True")
            {
                txtemail.BackColor = Color.Red;
                lbl_warning.Visible = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                txtpassword.UseSystemPasswordChar = true;

            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
        }
    }
}
