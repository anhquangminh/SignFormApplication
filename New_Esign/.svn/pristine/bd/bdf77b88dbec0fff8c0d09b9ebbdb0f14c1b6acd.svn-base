using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace New_Esign.AppCode
{
    public class getApprover
    {
        //public bool insertSchedule()
        private SQLServerDBHelper sqlHelp = new SQLServerDBHelper("EsignDB");
        public bool checkSignProcess(int formID, string appNo)
        {
            try
            {
                DataTable tb = new DataTable();
                string sqlQuery = @"select * from SubmitSign where FormID = '" + formID + "' order by SignNo asc ";

                tb = sqlHelp.DoSQLSelect(sqlQuery);
                if (tb.Rows.Count > 0)
                {
                    bool kq = true;
                    string status = "";
                    int step = 0;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        status = tb.Rows[i]["SignName"].ToString();
                        step = i;
                        kq = insertSchedule(appNo, status, step);
                        if(kq == false)
                        {                            
                            break;
                        }
                        
                    }
                    return kq;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool insertSchedule(string appNo,string status,int step1 )
        {
            try
            {
                string sqlInsert = @"insert into approvalSchedule(AppNo,statusName,step) values (@AppNo,@statusName,@step)";

                SqlParameter[] paRam = new SqlParameter[3];

                paRam.SetValue(new SqlParameter("AppNo", appNo), 0);
                paRam.SetValue(new SqlParameter("statusName", status), 1);
                paRam.SetValue(new SqlParameter("step", step1), 2);

                bool ket = sqlHelp.ExcuteNonQuery(sqlInsert);
                
                return ket;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}