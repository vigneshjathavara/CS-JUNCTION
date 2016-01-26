using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class allanq : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlDataReader dr;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        con.Open();
        String s = "Select * from articles";
        cmd = new SqlCommand(s, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink();
            h.Text = dr["title"].ToString();
            h.NavigateUrl = "~/ArticleDisplay.aspx?title=" + Server.UrlEncode(dr["title"].ToString());
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            articlesph.Controls.Add(h);
            articlesph.Controls.Add(new LiteralControl("<br /><br />"));
        }

        dr.Close();
        cmd = new SqlCommand("select * from questions", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink();
            h.Text = dr["title"].ToString();
            h.NavigateUrl = "~/QDisplay.aspx?q_id=" + dr["q_id"].ToString();
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            quesph.Controls.Add(h);
            quesph.Controls.Add(new LiteralControl("<br /><br />"));
        }
        con.Close();


    }
}