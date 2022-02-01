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
    public partial class frmReceiptLoginDetail : bEditorForm
    {
        clsReceiptDetails cls = new clsReceiptDetails();
        public frmReceiptLoginDetail()
        {
            InitializeComponent();
        }

        private void frmReceiptLoginDetail_Load(object sender, EventArgs e)
        {
            loadSystemDefaults();
            if (ID != null)
            {
                DataTable otbl = cls.SelectWithID(ID).Tables[0];
                comboreceiptip.Text = otbl.Rows[0]["ReceiptType"].ToString();
                combokdv.Text = otbl.Rows[0]["KDVTipID"].ToString();
                txttutar.Text = otbl.Rows[0]["ReceiptTotal"].ToString();
            }
        }
        private void loadSystemDefaults()
        {
            comboreceiptip.DataSource = cls.getFisTip().Tables[0];
            comboreceiptip.ValueMember = "FisTipID";
            comboreceiptip.DisplayMember = "FisTipAciklama";

            combokdv.DataSource = cls.getKDV().Tables[0];
            combokdv.ValueMember = "KDVTipID";
            combokdv.DisplayMember = "KDVTipAciklama";
        }       
    }
}
