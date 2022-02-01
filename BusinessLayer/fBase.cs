using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class fBase:IBase
    {
        public string procedureName { get; set; }
        public int TranType { get; set; }
        public string ID { get; set; }
        public string HastoParam(Hashtable ht, int trantype)
        {
            ht.Add("@pTranType", trantype);
           // ht.Add("@pID", ID);
            IDictionaryEnumerator myEnumrator = ht.GetEnumerator();
            string rval = "";
            while (myEnumrator.MoveNext())
            {
                var te = myEnumrator.Value;
                var tg = myEnumrator.Key;
                rval += tg + " = '" + te + "',";
            }
            rval = rval.Substring(0, rval.Length - 1);
            rval = procedureName + " " + rval;
            return rval;
        }
        
        public DataSet Select()
        {
            clsDBHelper cls = new clsDBHelper();
            Hashtable ht = new Hashtable();
            DataSet returnval = cls.getDataset(HastoParam(ht, 5).ToString());
            return returnval;
        }
        public virtual int Add(Hashtable ht)
        {
            clsDBHelper cls = new clsDBHelper();
            string returnval = cls.getDataset(HastoParam(ht,1)).Tables[0].Rows[0]["ID"].ToString();
            return Convert.ToInt32(returnval);
        }
        public virtual DataSet Update(Hashtable ht)
        {
            this.ID = ID;
            clsDBHelper cls = new clsDBHelper();
            DataSet returnval = cls.getDataset(HastoParam(ht, 2).ToString());
            return returnval;
        }
        public virtual void Delete(string ID)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@pID", ID);
            this.ID = ID;
            clsDBHelper cls = new clsDBHelper();
            cls.getDataset(HastoParam(ht, 3).ToString());

        }

        public virtual DataSet SelectWithID(string ID)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@pID", ID);
            this.ID = ID;
            clsDBHelper cls = new clsDBHelper();
            DataSet returnval = cls.getDataset(HastoParam(ht, 4).ToString());
            return returnval;
        }
        public void ClearAll(Control.ControlCollection collection)
        {
            foreach (var item in collection)
            {
                if (item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    t.Clear();
                }

                else if (item is RichTextBox)
                {
                    RichTextBox rt = (RichTextBox)item;
                    rt.Clear();
                }

                else if (item is GroupBox)
                {
                    GroupBox g = (GroupBox)item;
                    ClearAll(g.Controls); //bu noktada tekrar fonsiyonun içerisinde girince yukarıda ki koşullar
                                          //sayesinde bu sefer groupbox için sorguları yapıp temizliyor.
                }
                else if (item is ComboBox)
                {
                    ComboBox cmb = (ComboBox)item;
                    cmb.Text = "";
                }
            }
        }
    }
}
