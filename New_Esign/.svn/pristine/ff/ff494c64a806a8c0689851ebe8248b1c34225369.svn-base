using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New_Esign.AppCode
{
    public class EmployeeModel
    {
        public string USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string SEX { get; set; }
        public string GRADE { get; set; }
        public string JOB_TITLE { get; set; }
        public string CURRENT_OU_CODE { get; set; }
        //CURRENT_OU_NAME
        public string DEPARTMENT_NAME { get; set; }
        public string NOTES_ID { get; set; }
        public string EMAIL { get; set; }
        public string LOCATION { get; set; }
        public string ALL_MANAGERS { get; set; }
        public string SITE_ALL_MANAGERS { get; set; }
        public string BU_ALL_MANAGERS { get; set; }
        public string UPPER_OU_CODE { get; set; }
        public string NOTDUTY { get; set; }
        public string TRAVEL { get; set; }
        public string HIREDATE { get; set; }
        public string LEAVEDAY { get; set; }
        public string USER_ID_EXT { get; set; }
        public string JOB_TYPE { get; set; }
        public string USER_LEVEL { get; set; }
        public string[] List_manager { get; set; }
        public EmployeeModel()
        {

        }
        public EmployeeModel(string uSER_ID, string uSER_NAME, string sEX, string gRADE, string jOB_TITLE, string cURRENT_OU_CODE, string cURRENT_OU_NAME, string nOTES_ID, string eMAIL, string lOCATION, string aLL_MANAGERS, string sITE_ALL_MANAGERS, string bU_ALL_MANAGERS, string uPPER_OU_CODE, string nOTDUTY, string tRAVEL, string hIREDATE, string lEAVEDAY, string uSER_ID_EXT, string jOB_TYPE, string uSER_LEVEL)
        {
            USER_ID = uSER_ID;
            USER_NAME = uSER_NAME;
            SEX = sEX;
            GRADE = gRADE;
            JOB_TITLE = jOB_TITLE;
            CURRENT_OU_CODE = cURRENT_OU_CODE;
            DEPARTMENT_NAME = cURRENT_OU_NAME;
            NOTES_ID = nOTES_ID;
            EMAIL = eMAIL;
            LOCATION = lOCATION;
            ALL_MANAGERS = aLL_MANAGERS;
            SITE_ALL_MANAGERS = sITE_ALL_MANAGERS;
            BU_ALL_MANAGERS = bU_ALL_MANAGERS;
            UPPER_OU_CODE = uPPER_OU_CODE;
            NOTDUTY = nOTDUTY;
            TRAVEL = tRAVEL;
            HIREDATE = hIREDATE;
            LEAVEDAY = lEAVEDAY;
            USER_ID_EXT = uSER_ID_EXT;
            JOB_TYPE = jOB_TYPE;
            USER_LEVEL = uSER_LEVEL;
            //V0000637;811641;009260
            List_manager = BU_ALL_MANAGERS.Split(';');
        }
    }
}