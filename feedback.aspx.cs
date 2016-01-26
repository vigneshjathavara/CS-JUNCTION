using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class feedback : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["la"].ConnectionString;
        String s = "Select * from feedback";
        con.Open();
        cmd = new SqlCommand(s, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            LiteralControl t = new LiteralControl(dr["f_body"].ToString());
            ph.Controls.Add(t);
            ph.Controls.Add(new LiteralControl("<br />"));
            ph.Controls.Add(new LiteralControl("<hr size=\"2pt\" />"));


        }
        con.Close();
}
    protected void submit_Click(object sender, EventArgs e)
    {
        con.Open();
        String s="insert into feedback(f_body)values('"+txtb.Text+"')";
        cmd = new SqlCommand(s,con);
        int r = cmd.ExecuteNonQuery();
        lbl1.Text = "Thankyou For ur Feedback";
        Response.Redirect(Request.RawUrl);
    }
}