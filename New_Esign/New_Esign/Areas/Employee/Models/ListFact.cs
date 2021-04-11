using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace New_Esign.Areas.Employee.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["ESignDB"].ConnectionString;
        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
    public class ListFact
    {
        public string name;
    }
    public class getListFact
    {
        DBConnection db;
        public getListFact()
        {
            db = new DBConnection();
        }
        public List<ListFact> getListFactory()
        {
            string sql;
            sql = "select Location from Location_Fac";
           
            List<ListFact> Listfc = new List<ListFact>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            ListFact tmpFactory;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpFactory = new ListFact();
                tmpFactory.name = dt.Rows[i]["Location"].ToString(); 

                Listfc.Add(tmpFactory);
            }
            return Listfc;

        }
    }
}