using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlDataReader dr;
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {

        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        con.Open();
        cmd = new SqlCommand("select * from categories", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink(); Label l = new Label();
            h.Text = dr["ca_name"].ToString(); l.Text = dr["ca_description"].ToString();
            h.NavigateUrl = "~/category.aspx?cid=" + dr["ca_id"].ToString();
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            tab1ph.Controls.Add(h); 
            tab1ph.Controls.Add(new LiteralControl("<br />"));
            tab1ph.Controls.Add(l);
            tab1ph.Controls.Add(new LiteralControl("<br /><br />"));
        }
        dr.Close();
        cmd = new SqlCommand("select top 25 * from articles order by postdate desc", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink();
            Label l=new Label();
            h.Text = dr["title"].ToString();
            h.NavigateUrl = "~/ArticleDisplay.aspx?title=" +Server.UrlEncode(dr["title"].ToString());
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            l.Text ="post date: "+ dr["postdate"].ToString();
            tab2ph.Controls.Add(h);
            tab2ph.Controls.Add(new LiteralControl("<br />"));
            tab2ph.Controls.Add(l);
            tab2ph.Controls.Add(new LiteralControl("<br /><br />"));
        }
        dr.Close();
        cmd = new SqlCommand("select top 25 * from(select u_name,SUM(ar_sum)as ur from(select a.a_id,a.ar_sum,b.u_name from (select a_id, SUM(rating)as ar_sum from ratings group by a_id) as a,(select a_id,u_name from articles)as b where a.a_id=b.a_id)as u_ratings group by u_name)as val_users order by ur desc", con);
        dr = cmd.ExecuteReader();
        int i=1;
        while (dr.Read())
        {
            Label h = new Label();
            h.Text = ""+i+". "+dr["u_name"].ToString();
            //h.NavigateUrl = "~/ArticleDisplay.aspx?title=" + dr["title"].ToString();
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            tab3ph.Controls.Add(h);
            tab3ph.Controls.Add(new LiteralControl("<br /><br />"));
            i++;
        }
        dr.Close();
        cmd = new SqlCommand("select * from questions where questions.q_id NOT IN(select distinct q_id from answers)", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            HyperLink h = new HyperLink();
            h.Text = dr["title"].ToString();
            h.NavigateUrl = "~/QDisplay.aspx?q_id=" + dr["q_id"].ToString();
            h.Style.Add("text-align", "center");
            h.Style.Add("font-family", "Copperplate Gothic Bold");
            h.Style.Add("font-size", "medium");
            tab4ph.Controls.Add(h);
            tab4ph.Controls.Add(new LiteralControl("<br /><br />"));
        }
        con.Close();
    }

}
