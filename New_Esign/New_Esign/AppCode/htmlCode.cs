using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace New_Esign.AppCode
{
    public class htmlCode
    {
        public DataTable listFormContent(int formID)
        {
            SQLServerDBHelper sqlHelper = new SQLServerDBHelper();
            DataTable tb = new DataTable();

            //sqlHelper.DoSQLSelect
            string sqlQuery = @"select * from FormContent where FormID =" + formID + "";
            tb = sqlHelper.DoSQLSelect(sqlQuery);
            return tb;
        }

        public string htmlView()
        {
            DataTable tb = new DataTable();
            tb = listFormContent(1);

            string htmlFormContentStr = "";
            foreach (DataRow dr in tb.Rows)
            {
                string inputType = dr["InputType"].ToString();
                string[] inputTypeArr = inputType.Split(':');
                string elementHtml = "";
                switch (inputTypeArr[0])
                {
                    case "Textbox":
                        string[] elementName = dr["InputName"].ToString().Split(':');
                        elementHtml = "<label><input type='Text' id='" + elementName[0] + "' value='"+elementName[1]+"' {0}/>";
                        string elementProperties = "";
                        if (inputTypeArr.Length > 0)
                        {
                            if (inputTypeArr[1].Contains("Disable"))
                            {
                                elementProperties += "disabled='disabled' ";
                            }
                            else
                            if (inputTypeArr[1].Contains("Placeholder"))
                            {
                                elementProperties += "placeholder='demo' ";
                            }
                        }
                        if ("True".Equals(dr["IsRequired"].ToString()))
                        {
                            elementProperties += "required ";
                        }
                        elementHtml = string.Format(elementHtml, elementProperties);
                        break;
                    case "Combobox":
                        elementHtml = "<a href='https://chat.zalo.me/'>Testter</a> floated by you.</br>";
                        break;
                } //End switch	
                htmlFormContentStr += elementHtml;
                //+ Enviroment.NewLine;
            }
            return htmlFormContentStr;
        }
    }
}