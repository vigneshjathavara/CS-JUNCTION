using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class QDisplay : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    DataSet ds = new DataSet();
    SqlDataAdapter dr;
    SqlCommand commentscmd, insertCommentscmd, reportcmd;
    SqlDataReader commentReader;
    String s, s1, rs;
    int n;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        con.Open();
        s = "Select * from questions where q_id=" +Request.QueryString["q_id"];
        dr = new SqlDataAdapter(s,con);
        dr.Fill(ds);
        s = ds.Tables[0].Rows[0]["title"].ToString();
        category_title.Text = s;
        s = ds.Tables[0].Rows[0]["q_body"].ToString();
        textDisplay.Text = s;
        
        pdate.Text = "post date: " + ds.Tables[0].Rows[0]["postdate"].ToString();
        Author.Text = "posted by: " + ds.Tables[0].Rows[0]["u_name"].ToString();
        n = (int)ds.Tables[0].Rows[0]["q_id"];
        s = "Select * from answers where q_id=" + n;
        commentscmd = new SqlCommand(s,con);
        commentReader=commentscmd.ExecuteReader();
        while (commentReader.Read())
        {
            LiteralControl t = new LiteralControl(commentReader["ans_body"].ToString());
            Label l = new Label(),l2=new Label();
            l.Text = commentReader["u_name"].ToString()+":";
            l.Style.Add("font-family", "Arial Black");
            l.Style.Add("font-style", "italic");
            l.Style.Add("font-weight", "bold");
            ph.Controls.Add(l);
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

        s1 = "insert into answers(q_id,u_name,ans_body)values(" + (int)ds.Tables[0].Rows[0]["q_id"] + ",'" + HttpContext.Current.User.Identity.Name + "','" + tb.Text.Replace(Environment.NewLine, "<br />") + "')";
        insertCommentscmd = new SqlCommand(s1, con);
        int r = insertCommentscmd.ExecuteNonQuery();
        res.Text = "answer added";
        con.Close();
        Response.Redirect(Request.RawUrl);
    }
}
