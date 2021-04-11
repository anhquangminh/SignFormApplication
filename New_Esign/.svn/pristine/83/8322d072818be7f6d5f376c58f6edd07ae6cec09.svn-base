using NewModel.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewModel.Dao
{
    public class CodeDao
    {

        DBConnectData db = null;
        public CodeDao()
        {
            db = new DBConnectData();
        }

        public List<DATA_DEPARTMENT> ListDepartment()
        {
            List<DATA_DEPARTMENT> listDepartment = db.DATA_DEPARTMENTs.ToList();
            return listDepartment;
        }
        

        public List<Site> ListSite()
        {
            List<Site> listSite = db.Sites.ToList();
            return listSite;
        }

        public List<BU> ListBU()
        {
            List<BU> listBU = db.BUs.ToList();
            return listBU;
        }

        public List<Department> ListDepart()
        {
            List<Department> listDepart = db.Departments.ToList();
            return listDepart;
        }
        //public int getFormID(string formName)
        //{
        //    //var res = db.Forms.Find(m => m.FormName == formName).ToString();
        //    var res2 = db.Forms.Where(m => m.FormName == formName).ToList();
        //    string te = res2.
        //    var formID = Convert.ToInt32(res2);
        //    return formID;
        //}
        
    }
}
