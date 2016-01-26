using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;

public partial class UserPage : System.Web.UI.Page
{
    String uname;
    SqlConnection con = new SqlConnection();
    SqlDataReader dr;
    SqlCommand cmd;
    String s;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        con.Open();
        uname = HttpContext.Current.User.Identity.Name;
        if (Page.IsPostBack == false)
        {
            
            user.Text = uname;
            
            s = "select * from articles where u_name='" + uname + "'";
            cmd = new SqlCommand(s, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ArticleBox1.Items.Add((String)dr["title"]);
            }
            dr.Close();
        }

        s = "select * from questions where u_name='" + uname + "'";
        cmd = new SqlCommand(s, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink();
            h.Text = dr["title"].ToString();
            h.NavigateUrl = "~/QDisplay.aspx?q_id=" + dr["q_id"].ToString();
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            aqph.Controls.Add(h);
            aqph.Controls.Add(new LiteralControl("<br /><br />"));
        }

        dr.Close();
        s = "select * from questions where q_id in(select distinct q_id from answers where u_name='" + uname + "')";
        cmd = new SqlCommand(s, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink();
            h.Text = dr["title"].ToString();
            h.NavigateUrl = "~/QDisplay.aspx?q_id=" + dr["q_id"].ToString();
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            ansqph.Controls.Add(h);
            ansqph.Controls.Add(new LiteralControl("<br /><br />"));
        }
    }
    protected void view_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ArticleDisplay.aspx?title="+Server.UrlEncode(ArticleBox1.SelectedItem.Text));
    }
    protected void remove_Click(object sender, EventArgs e)
    {
        if (ArticleBox1.SelectedIndex != -1)
        {
            pan.Visible = true;
            select.Text = "";
        }
        else
            select.Text = "Select item first";
    }
    protected void no_Click(object sender, EventArgs e)
    {
        pan.Visible = false;
    }
    protected void edit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/neweditArticle/editArticle.aspx?title="+Server.UrlEncode(ArticleBox1.SelectedItem.Text));
    }
    protected void yes_Click(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        con.Open();
        s = "delete from articles where title='"+ArticleBox1.SelectedItem.Text+"'";
        cmd = new SqlCommand(s, con);
        int r = cmd.ExecuteNonQuery();
        result.Text ="Article deleted";
        ArticleBox1.Items.Remove(ArticleBox1.SelectedItem);
        pan.Visible = false;
    }
}