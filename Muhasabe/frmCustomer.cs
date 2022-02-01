using BusinessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasabe
{
    public partial class frmCustomer : bEditorForm
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            if (ID != null)
            {
                clsCustomer cls = new clsCustomer();
                DataSet dt = new DataSet();
                dt = cls.SelectWithID(ID);
                txtname.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                txtsurname.Text = dt.Tables[0].Rows[0]["Surname"].ToString();
                mtxtIBAN.Text = dt.Tables[0].Rows[0]["IBAN"].ToString();
                mtxtTCKN.Text = dt.Tables[0].Rows[0]["TCKN"].ToString();
                richAdres.Text = dt.Tables[0].Rows[0]["Adres"].ToString();
            }
        }
    }
}
