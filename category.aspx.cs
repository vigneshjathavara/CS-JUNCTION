using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

public partial class category : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlDataReader dr;
    SqlCommand cmd;
    String s;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        //if (Page.IsPostBack == false)
        {
            con.Open();
            s = "select ca_name from categories where ca_id=" + Request.QueryString["cid"];
            cmd = new SqlCommand(s, con);
            category_title.Text = cmd.ExecuteScalar().ToString();
            s = "select top 10 * from articles where c_id=" + Request.QueryString["cid"] + " order by postdate desc";
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
                mostrecentph.Controls.Add(h);
                mostrecentph.Controls.Add(new LiteralControl("<br /><br />"));
            }
            dr.Close();
            s = "select top 10 title,SUM(r)as rating from(select a.a_id,title,rating as r from (select a_id,title from articles where c_id=" + Request.QueryString["cid"] + ")as a inner join (select a_id,rating from ratings)as b on a.a_id=b.a_id)as mr group by title order by rating desc";
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
                highestratedph.Controls.Add(h);
                highestratedph.Controls.Add(new LiteralControl("<br /><br />"));
            }
            con.Close();
        }
    }
    protected void searchbutton_Click(object sender, EventArgs e)
    {
        String[] sa=new String[10];
        String ss = searchbox.Text,s1="SELECT * FROM articles WHERE title LIKE '%",s2="SELECT *FROM articles WHERE title LIKE '%";
        ss.Trim();
        for(int i=0;i<ss.Length;i++)
        {
            if(ss[i].Equals(' '))
            {
                s1 += "%' AND title LIKE '%";
                s2 += "%' OR title LIKE '%";
            }
            else
            {
                s1+=ss[i];
                s2 += ss[i];
            }

        }
        s1 += "%' and c_id=" + Request.QueryString["cid"]; s2 += "%' and c_id=" + Request.QueryString["cid"];
        s2 = s2 + " except " + s1;
        con.Open();
        cmd = new SqlCommand(s1, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink();
            h.Text = dr["title"].ToString();
            h.NavigateUrl = "~/ArticleDisplay.aspx?title=" + Server.UrlEncode(dr["title"].ToString());
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            PlaceHolder searchresults =(PlaceHolder) up.FindControl("searchresults");
            searchresults.Controls.Add(h);
            searchresults.Controls.Add(new LiteralControl("<br /><br />"));
        }
        dr.Close();
        cmd = new SqlCommand(s2, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink();
            h.Text = dr["title"].ToString();
            h.NavigateUrl = "~/ArticleDisplay.aspx?title=" + Server.UrlEncode(dr["title"].ToString());
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            searchresults.Controls.Add(h);
            searchresults.Controls.Add(new LiteralControl("<br /><br />"));
        }
        con.Close();
        
    }
}