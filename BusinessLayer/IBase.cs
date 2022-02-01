using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBase
    {
        DataSet Select();
        int Add(Hashtable ht);
        DataSet Update(Hashtable ht);
        void Delete(string ID);
    }
}
