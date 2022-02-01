using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsReceiptDetails:fBase
    {
        public clsReceiptDetails()
        {
            procedureName = "up_TblReceiptDetails";
        }
        clsDBHelper cls = new clsDBHelper();
        public DataSet getFisTip()
        {
            string esql = procedureName + " @ptrantype = 6";
            return cls.getDataset(esql);
        }
        public DataSet getKDV()
        {
            string esql = procedureName + " @ptrantype = 7";
            return cls.getDataset(esql);
        }
    }
}
