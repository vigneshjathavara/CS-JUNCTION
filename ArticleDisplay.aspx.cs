using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ArticleDisplay : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    DataSet ds = new DataSet();
    DataSet rds = new DataSet();
    SqlDataAdapter dr,rdr;
    SqlCommand commentscmd,insertCommentscmd,reportcmd;
    SqlDataReader commentReader;
    String s,s1,rs;
    int n;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        con.Open();
        s = "Select * from articles where title='" +Request.QueryString["title"]+"'";
        dr = new SqlDataAdapter(s,con);
        dr.Fill(ds);
        s = ds.Tables[0].Rows[0]["title"].ToString();
        category_title.Text = s;
        Page.Title = s;
        s = ds.Tables[0].Rows[0]["a_body"].ToString();
        textDisplay.Text = s;
        
        pdate.Text = "post date: " + ds.Tables[0].Rows[0]["postdate"].ToString();

        rs = "SELECT SUM(rating) As RatingSum, COUNT(*) As RatingCount FROM ratings WHERE a_id=" + (int)ds.Tables[0].Rows[0]["a_id"];
        rdr = new SqlDataAdapter(rs, con);
        rdr.Fill(rds);
        if ((int)rds.Tables[0].Rows[0]["RatingCount"] == 0)
        {
            rating.Text = "RATING: not rated";
            Image1.Visible = false;
        }
        else
        {
            rating.Text = "RATING:" + (int)rds.Tables[0].Rows[0]["RatingSum"] / (int)rds.Tables[0].Rows[0]["RatingCount"];
            Image1.Visible = true;
        }
        Author.Text = "posted by: " + ds.Tables[0].Rows[0]["u_name"].ToString();
        n = (int)ds.Tables[0].Rows[0]["a_id"];
        s = "Select * from comments where a_id=" + n;
        commentscmd = new SqlCommand(s,con);
        commentReader=commentscmd.ExecuteReader();
        while (commentReader.Read())
        {
            LiteralControl t = new LiteralControl(commentReader["co_body"].ToString());
            Label l = new Label(),l2=new Label();
            Button b = new Button();
            b.ID = commentReader["co_id"].ToString();
            b.Click+=new EventHandler(b_Click);
            b.Text = "Report abuse";
            l.Text = commentReader["u_name"].ToString()+":";
            l.Style.Add("font-family", "Arial Black");
            l.Style.Add("font-style", "italic");
            l.Style.Add("font-weight", "bold");
            l2.ID = commentReader["co_id"].ToString()+"l";
            ph.Controls.Add(l);
            ph.Controls.Add(b);
            ph.Controls.Add(l2);
            ph.Controls.Add(new LiteralControl("<br />"));
            ph.Controls.Add(t);
            ph.Controls.Add(new LiteralControl("<hr size=\"2pt\" />"));
           
           
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        TextBox tb = (TextBox)LoginView2.FindControl("ncom");

        s1 = "insert into comments(a_id,u_name,co_body)values(" + (int)ds.Tables[0].Rows[0]["a_id"] + ",'" + HttpContext.Current.User.Identity.Name + "','" + tb.Text.Replace(Environment.NewLine, "<br />") +"')";
        insertCommentscmd = new SqlCommand(s1, con);
        int r = insertCommentscmd.ExecuteNonQuery();
        res.Text = "comment added";
        con.Close();
        Response.Redirect(Request.RawUrl);
    }

    public void b_Click(object sender, EventArgs e)
    {
        Button tempbutton=(Button)sender;
        Label l2 = (Label)ph.FindControl(tempbutton.ID + "l");
        con.Open();
        s = "SELECT COUNT(*) As co_count FROM co_reports WHERE co_id=" + tempbutton.ID + " AND u_name ='" + HttpContext.Current.User.Identity.Name + "'";
        reportcmd = new SqlCommand(s, con);
        int chk = (int)reportcmd.ExecuteScalar();
        if (chk == 0)
        {
            s = "insert into co_reports(co_id,u_name) values(" + tempbutton.ID + ",'" + HttpContext.Current.User.Identity.Name + "')";
            reportcmd = new SqlCommand(s, con);
            int r = reportcmd.ExecuteNonQuery();
            l2.Text = "comment reported";
        }
        else if (chk == 1)
        {
            l2.Text = "Already Reported";
        }
            con.Close();
    }

    
    protected void rate_Click(object sender, EventArgs e)
    {
        DropDownList d1 = (DropDownList)LoginView1.FindControl("DDL1");
        Label l = (Label)LoginView1.FindControl("rlabel");
        if (d1.SelectedIndex == 0)
        {
            l.Text = "Select Rating";
        }
        else
        {
            con.Open();
            s = "SELECT COUNT(*) As RatingCount FROM ratings WHERE a_id=" + (int)ds.Tables[0].Rows[0]["a_id"] + " AND u_name ='" + HttpContext.Current.User.Identity.Name + "'";
            reportcmd = new SqlCommand(s, con);

            int chk = (int)reportcmd.ExecuteScalar();
            if (chk == 0)
            {

                s = "insert into ratings(a_id,rating,u_name) values(" + (int)ds.Tables[0].Rows[0]["a_id"] + "," + d1.SelectedValue + ",'" + HttpContext.Current.User.Identity.Name + "')";
                reportcmd = new SqlCommand(s, con);
                int r = reportcmd.ExecuteNonQuery();
                l.Text = "Rating confirmed";
            }
            else if (chk == 1)
            {
                l.Text = "Already Rated";
            }
            con.Close();
        }
    }
}
