using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


/// <summary>
/// Summary description for search
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class search : System.Web.Services.WebService {

    public search () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] searchpredict(string prefixText)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        //int count = 10;
        string sql;
        sql = "Select title from articles Where title like '%" + prefixText + "' + '%'";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr[0].ToString(), i);
            i++;
        }

        return items;
    }

    [WebMethod]
    public string[] searchpredictq(string prefixText)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        //int count = 10;
        string sql;
        sql = "Select title from questions Where title like '%" + prefixText + "' + '%'";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr[0].ToString(), i);
            i++;
        }

        return items;
    }
    
}
