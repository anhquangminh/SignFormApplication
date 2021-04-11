using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System;

public class SQLServerDBHelper
{
    string connString = "Data Source=10.224.81.131,3000;Initial Catalog=esign;Persist Security Info=True;User ID=sa;Password=foxconn168!!";
    SqlConnection conn;
    SqlDataAdapter da;

    public SQLServerDBHelper()
    {
        ConnectionStringSettings cib = ConfigurationManager.ConnectionStrings["ass"];
    }

    public SQLServerDBHelper(string _connectionName)
    {
        ConnectionStringSettings conSet = ConfigurationManager.ConnectionStrings[_connectionName];
        string conStr = conSet != null ? conSet.ConnectionString : null;
        if (!string.IsNullOrEmpty(conStr)) connString = conStr;
    }

    public SQLServerDBHelper(string _serverIp, string _dbName, string _user, string _pass)
    {
        connString = "Data Source=" + _serverIp + ";Initial Catalog=" + _dbName + ";Persist Security Info=True;User ID=" + _user + ";Password=" + _pass + "";
    }

    public bool TestConnect(Label _label_error = null)
    {
        try
        {
            conn = new SqlConnection(connString);
            conn.Open();
            conn.Close();
            return true;
        }
        catch (SqlException se)
        {
            if (_label_error != null)
            {
                _label_error.Text = se.Message;
                _label_error.Visible = true;
            }
        }
        return false;
    }

    public DataTable DoSQLSelect(string _sqlQuery, Label _label_error = null)
    {
        DataTable dt = new DataTable();
        try
        {
            conn = new SqlConnection(connString);
            conn.Open();
            da = new SqlDataAdapter(_sqlQuery, conn);
            da.Fill(dt);
            conn.Close();
        }
        catch (SqlException se)
        {
            if (_label_error != null)
            {
                _label_error.Text = se.Message;
                _label_error.Visible = true;
            }
        }
        return dt;
    }
    public DataTable DoSQLSelect(string _sqlQuery, int? _page, int _pageSize, Label _label_error = null)
    {
        int start = (int)_pageSize * ((int)_page - 1);
        return DoSQLSelect(_sqlQuery, start, _pageSize, _label_error);
    }
    public DataTable DoSQLSelect(string _sqlQuery, int _startIndex, int _numberRow, Label _label_error = null)
    {
        DataTable dt = new DataTable();
        try
        {
            conn = new SqlConnection(connString);
            conn.Open();
            da = new SqlDataAdapter(_sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, _startIndex, _numberRow, "Data row" + _startIndex + "_" + _numberRow);
            if (ds.Tables.Count > 0) dt = ds.Tables[0];
            conn.Close();
        }
        catch (SqlException se)
        {
            if (_label_error != null)
            {
                _label_error.Text = se.Message;
                _label_error.Visible = true;
            }
        }
        return dt;
    }

    public string GetSingleValueSelect(string _sqlQuery, Label _label_error = null)
    {
        string value = "";
        try
        {
            conn = new SqlConnection(connString);
            conn.Open();
            da = new SqlDataAdapter(_sqlQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0) value = dt.Rows[0][0].ToString();
            conn.Close();
        }
        catch (SqlException se)
        {
            if (_label_error != null)
            {
                _label_error.Text = se.Message;
                _label_error.Visible = true;
            }
        }
        return value;
    }

    public bool ExcuteNonQuery(string _sql, Label _label_error = null)
    {
        try
        {
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(_sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (SqlException se)
        {
            if (_label_error != null)
            {
                _label_error.Text = se.Message;
                _label_error.Visible = true;
            }
        }
        return false;
    }
    public bool ExcuteNonQuery(string _sql, SqlParameter[] listParameters, Label _label_error = null)
    {
        try
        {
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(_sql, conn);
            cmd.Parameters.AddRange(listParameters);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (SqlException se)
        {
            if (_label_error != null)
            {
                _label_error.Text = se.Message;
                _label_error.Visible = true;
            }
        }
        return false;
    }       
}
