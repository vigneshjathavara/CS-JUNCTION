using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Drawing;

public partial class Account_passwordRecovery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        MembershipUser u = Membership.GetUser(tb1.Text);
        if (u == null)
        {
            Label1.Text = "unkown user Enter Again";
        }
        else
        {
            SmtpClient client = new SmtpClient();

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.EnableSsl = false;

            client.Host = " relay-hosting.secureserver.net.";

            client.Port = 25;

            String newp;

            // setup Smtp authentication

           // System.Net.NetworkCredential credentials =
             //   new System.Net.NetworkCredential("password_change@csjunction.in", "password");

           // client.UseDefaultCredentials = false;

            //client.Credentials = credentials;



            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("password_change@csjunction.in");

            msg.To.Add(new MailAddress(u.Email));

            newp= u.ResetPassword();

            msg.Subject = "NEW PASSWORD FROM CS JUNCTION";

            msg.IsBodyHtml = true;

            msg.Body ="<html><head></head><body><b>Your new password:"+newp+"</b></body>";



            try
            {

                client.Send(msg);

                lblMsg.Text = "Your message has been successfully sent.";
              
            }

            catch (Exception ex)
            {

                lblMsg.ForeColor = Color.Red;

                lblMsg.Text = "Error occured while sending your message." + ex.Message;

            }
        }
    }
}