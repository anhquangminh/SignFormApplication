using NewModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModel.Dao
{
    public class AccountDao
    {
        DBConnectData db = null;
        public AccountDao()
        {
            db = new DBConnectData();
        }
        public Account GetByID(string userNo)
        {
            return db.Accounts.SingleOrDefault(x => x.UserID == userNo);
        }
        public int Login(string userID, string userPass)
        {
            var res = db.Accounts.SingleOrDefault(m => m.UserID == userID && m.Password == userPass);
            if(res == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public int Login2(string userID)
        {
            var res = db.Accounts.SingleOrDefault(m => m.UserID == userID);
            if (res == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

    }
}
