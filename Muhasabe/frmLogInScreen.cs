using BusinessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasabe
{
    public partial class frmLogInScreen : Form
    {
        public frmLogInScreen()
        {
            InitializeComponent();
        }
        public string ID { get; set; }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tx = (TextBox)item;

                    ht.Add(tx.Tag, tx.Text);
                }
            }
            clsNewUser cls = new clsNewUser();
            string result = cls.LogInApp(ht);
            if (result == "True")
            {
                MessageBox.Show("Login Succes");
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Userneme or password is invalid");
            }
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {
            frmSignInScreen frm = new frmSignInScreen();
            this.Hide();
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgetPasword frm = new frmForgetPasword();
            this.Hide();
            frm.Show();
        }

        private void frmLogInScreen_Load(object sender, EventArgs e)
        {

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
