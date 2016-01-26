using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class NewArticle : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddl.SelectedIndex == 0 || title.Text == "Enter the Title" ||Editor1.Content=="")
        {
            result.Text = "Please give a title or choose category or type some content ";
        }
        else
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
            con.Open();
            String s = Editor1.Content;
            s = s.Replace("'", "''");
            cmd = new SqlCommand("insert into articles(title,a_body,c_id,u_name) values('" + title.Text + "','" + s + "'," + ddl.SelectedValue + ",'" + HttpContext.Current.User.Identity.Name + "')", con);

            int r = cmd.ExecuteNonQuery();
            result.Text = "Article added successfully";
            Editor1.Content = "";
            title.Text = "";
        }
    }
}