using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsReceiptMaster:fBase
    {
        public clsReceiptMaster()
        {
            procedureName = " up_TblReceiptMaster ";
        }
        clsDBHelper cls = new clsDBHelper();
        public DataSet getCustomerList()
        {
            string esql = procedureName + " @ptrantype = 7";            
            return cls.getDataset(esql);
        }
        public DataSet getReceiptDetailsList(string ID)
        {
            string esql = procedureName + " @pTranType = 6 , @pID = '" + ID + "'";
            return cls.getDataset(esql);
        }
    }
}
