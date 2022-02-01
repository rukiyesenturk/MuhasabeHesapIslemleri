using BusinessLayer;
using System;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public string CurrentForm { get; set; }
        public string SelectedID { get; set; }
        private void prepareCustomerList()
        {
            clsCustomer cls = new clsCustomer();
            dataGridView1.DataSource = cls.Select().Tables[0];
            dataGridView1.Refresh();
        }
        private void prepareReceiptList()
        {
            clsReceiptMaster cls = new clsReceiptMaster();
            dataGridView1.DataSource = cls.Select().Tables[0];
            dataGridView1.Refresh();
        }
        void editorForm_AfterTransactionTriggered(object sender, bEditorForm.AfterTransactionEventArgs e)
        {
            if (CurrentForm == "ReceitLogin")
            {
                prepareReceiptList();
            }
            else if (CurrentForm == "CustomerLogin")
            {
                prepareCustomerList();
            }

        }
        private void customerLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = "CustomerLogin";
            prepareCustomerList();
        }               
        private void receiptLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = "ReceitLogin";
            prepareReceiptList();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentForm == "ReceitLogin")
            {
                frmReceipt frm = new frmReceipt();
                frm.AfterTransactionTriggered += new bEditorForm.AfterTransactionEventHandler(editorForm_AfterTransactionTriggered);
                //frm.ID = SelectedID;
                frm.ShowDialog();
            }
            else if (CurrentForm == "CustomerLogin")
            {
                frmCustomer frm = new frmCustomer();
                frm.AfterTransactionTriggered += new bEditorForm.AfterTransactionEventHandler(editorForm_AfterTransactionTriggered);
                //frm.ID = SelectedID;
                frm.ShowDialog();
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow orow = dataGridView1.CurrentRow;
            SelectedID = orow.Cells[0].Value.ToString();
            if (CurrentForm == "ReceitLogin")
            {
                clsReceiptMaster cls = new clsReceiptMaster();
                cls.Delete(SelectedID);
                prepareReceiptList();
            }
            else if (CurrentForm == "CustomerLogin")
            {
                clsCustomer cls = new clsCustomer();
                cls.Delete(SelectedID);
                prepareCustomerList();
            }
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow orow = dataGridView1.CurrentRow;
            SelectedID = orow.Cells[0].Value.ToString();
            if (CurrentForm == "ReceitLogin")
            {
                frmReceipt frm = new frmReceipt();
                frm.AfterTransactionTriggered += new bEditorForm.AfterTransactionEventHandler(editorForm_AfterTransactionTriggered);
                frm.ID = SelectedID;
                frm.ShowDialog();
            }
            else if (CurrentForm == "CustomerLogin")
            {
                frmCustomer frm = new frmCustomer();
                frm.AfterTransactionTriggered += new bEditorForm.AfterTransactionEventHandler(editorForm_AfterTransactionTriggered);
                frm.ID = SelectedID;
                frm.ShowDialog();
            }
        }
    }
}
