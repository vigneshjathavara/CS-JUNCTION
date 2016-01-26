using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class neweditArticle_editArticle : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlDataAdapter dr;
    SqlCommand cmd;
    String s;
    DataSet ds=new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
            con.Open();
            s = "Select * from articles where title='" + Request.QueryString["title"] + "'";
            dr = new SqlDataAdapter(s, con);
            dr.Fill(ds);
            title.Text = ds.Tables[0].Rows[0]["title"].ToString();
            Editor1.Content = ds.Tables[0].Rows[0]["a_body"].ToString();
            ddl.SelectedValue = ds.Tables[0].Rows[0]["c_id"].ToString();
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddl.SelectedIndex == 0 || title.Text == "Enter the Title" || Editor1.Content == "")
        {
            result.Text = "Please give a title or choose category or type some content ";
        }
        else
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
            con.Open();
            String s = Editor1.Content;
            s = s.Replace("'", "''");
            cmd = new SqlCommand("update articles set title='" + title.Text + "',postdate=getdate(), a_body='" + s + "' where title='" + Request.QueryString["title"] + "'", con);

            int r = cmd.ExecuteNonQuery();
            result.Text = "Article edited successfully";
            con.Close();
        }
    }
}