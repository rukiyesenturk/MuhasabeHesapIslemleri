
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsNewUser:fBase
    {
        public clsNewUser()
        {
            procedureName = "up_TblNewUser";
        }
        clsDBHelper db = new clsDBHelper();
        public string LogInApp(Hashtable ht)
        {
            string result = db.getDataset(HastoParam(ht,4)).Tables[0].Rows[0]["RESULT"].ToString();
            return result;
        }
        public string QeuryToUsername(string email)
        {
            
            Hashtable ht = new Hashtable();
            ht.Add("@pEmail", email);
            string result = db.getDataset(HastoParam(ht,5)).Tables[0].Rows[0]["RESULT1"].ToString();
            return result;

        }
        public string GetVerificationQuestion(string email)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@pEmail", email);
            string result = db.getDataset(HastoParam(ht,6)).Tables[0].Rows[0]["RESULT2"].ToString();
            return result;

        }
        public string ChangePassword(string email, string answer, string password)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@pEmail", email);
            ht.Add("@pAnswer", answer);
            ht.Add("@pPasword", password);
            string result = db.getDataset(HastoParam(ht, 7)).Tables[0].Rows[0]["RESULT3"].ToString();

            return result;

        }
    }
}
