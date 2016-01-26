using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class neweditArticle_newquestion : System.Web.UI.Page
{
    SqlConnection con=new SqlConnection();
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (keywords.Text == "Enetr keywords(better noticeability)" || title.Text == "Enter the Title" || Editor1.Content == "")
        {
            result.Text = "Please give a title or choose category or type some content ";
        }
        else
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
            con.Open();
            String s = Editor1.Content,st=title.Text;
            st = st.Replace("'", "''");
            s = s.Replace("'", "''");
            cmd = new SqlCommand("insert into questions(title,q_body,keywords,u_name) values('" + st + "','" + s + "','" + keywords.Text + "','" + HttpContext.Current.User.Identity.Name + "')", con);

            int r = cmd.ExecuteNonQuery();
            result.Text = "Question added successfully";
        }
    }
}