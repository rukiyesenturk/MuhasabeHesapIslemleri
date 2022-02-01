using BusinessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasabe
{
   
    public partial class bEditorForm : Form
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
        public bEditorForm()
        {
            InitializeComponent();
        }

        private void bEditor_Load(object sender, EventArgs e)
        {

        }

        public delegate void AfterTransactionEventHandler(object sender, AfterTransactionEventArgs e);
        public event AfterTransactionEventHandler AfterTransactionTriggered;
        public class AfterTransactionEventArgs : EventArgs
        {
            private string mtableid;
            public string retTableId
            {
                get { return mtableid; }
            }
            public string ActionName { get; set; }
            public AfterTransactionEventArgs(string tableid, string action)
            {
                mtableid = tableid;
                ActionName = action;
            }
        }
        private Hashtable generateHashTable()
        {
            Hashtable ht = new Hashtable();
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    ht.Add(item.Tag, item.Text);
                }
                else if (item is MaskedTextBox)
                {
                    ht.Add(item.Tag, item.Text);
                }
                else if (item is RichTextBox)
                {
                    ht.Add(item.Tag, item.Text);
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)item;
                    var tg = dt.Tag;
                    var te = dt.Value.ToString("yyyy-MM-dd");
                    ht.Add(tg, te);
                }
                else if (item is ComboBox)
                {
                    var te = ((ComboBox)(item)).SelectedValue.ToString();
                    var tg = item.Tag;
                    ht.Add(tg, te);
                }
            }
            return ht;
        }
        public virtual string Add(Hashtable ht)
        {
            ObjectHandle obj = Activator.CreateInstance(AssemblyName, ClassName);
            fBase facade = (fBase)obj.Unwrap();
            if (ClassName == "BusinessLayer.clsReceiptDetails")
            {
                ht.Add("@pParentID", ParentID);
            }
            return facade.Add(ht).ToString();
        }
        public virtual void Update(Hashtable ht)
        {
            ObjectHandle obj = Activator.CreateInstance(AssemblyName, ClassName);
            fBase facade = (fBase)obj.Unwrap();
            facade.Update(ht).ToString();
        }
        public virtual void UpSert()
        {
            Hashtable ht = generateHashTable();
            if (ID == null)
            {
                Add(ht);

            }
            else
            {
                ht.Add("@pID", ID);
                Update(ht);

            }

            if (AfterTransactionTriggered != null)
            {
                AfterTransactionTriggered(this, new AfterTransactionEventArgs(ID, "insert"));
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            UpSert();       
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            UpSert();
        }

        private void toolBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
