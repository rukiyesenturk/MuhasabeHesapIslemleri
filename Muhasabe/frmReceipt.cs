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
    public partial class frmReceipt : bEditorForm
    {
        clsReceiptMaster cls = new clsReceiptMaster();
        clsReceiptDetails clsd = new clsReceiptDetails();
        public frmReceipt()
        {
            InitializeComponent();
        }
        void editorForm_AfterTransactionTriggered(object sender, bEditorForm.AfterTransactionEventArgs e)
        {
            prepareCustomerList();
        }
        private void prepareCustomerList()
        {
            loadSystemDefaults();
            if (ID != null)
            {

                DataTable otbl = cls.SelectWithID(ID).Tables[0];
                combocustomer.SelectedItem = otbl.Rows[0]["CustomerID"].ToString();
                txtreceiptnumber.Text = otbl.Rows[0]["Receipt Number"].ToString();
                dateTimePicker1.Text = otbl.Rows[0]["Receipt Date"].ToString();
            }
        }
        private void frmReceipt_Load(object sender, EventArgs e)
        {
            prepareCustomerList();  
        }
        private void loadSystemDefaults()
        {
            combocustomer.DataSource = cls.getCustomerList().Tables[0];
            combocustomer.ValueMember = "ID";
            combocustomer.DisplayMember = "Name";
            txtreceiptnumber.Text = RandomString(10);
            dataReceipt.DataSource = cls.getReceiptDetailsList(ID).Tables[0];
        }
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ID != null)
            {
                frmReceiptLoginDetail fd = new frmReceiptLoginDetail();
                fd.AfterTransactionTriggered += new bEditorForm.AfterTransactionEventHandler(editorForm_AfterTransactionTriggered);
                fd.ParentID = ID;
                fd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Oncelıkle Fıas KYDI yAPMALISINIZ");
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow orow = dataReceipt.CurrentRow;
            string SelectedID = orow.Cells[0].Value.ToString();
            frmReceiptLoginDetail fd = new frmReceiptLoginDetail();
            fd.AfterTransactionTriggered += new bEditorForm.AfterTransactionEventHandler(editorForm_AfterTransactionTriggered);
            fd.ParentID = ID;
            fd.ID = SelectedID;
            fd.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow orow = dataReceipt.CurrentRow;
            string SelectedID = orow.Cells[0].Value.ToString();
            clsd.Delete(SelectedID);
            dataReceipt.DataSource = cls.getReceiptDetailsList(ID).Tables[0];
        }
    }
}
