public class SystemConfigHelper
{
    public static object GetSystemConfig(string _name)
    {
        SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
        string tempSQL = "SELECT Value FROM SystemConfig WHERE Name='" + _name + "'";
        return db.GetSingleValueSelect(tempSQL);
    }
}