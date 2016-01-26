using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Drawing;

public partial class Account_Register : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
        //MembershipUser u = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        //if (u != null)
        {
            SmtpClient client = new SmtpClient();

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.EnableSsl =false;

            client.Host = "relay-hosting.secureserver.net";

            client.Port = 25;

            String newp;

            // setup Smtp authentication

           // System.Net.NetworkCredential credentials =
             //   new System.Net.NetworkCredential("vigneshjathavar@gmail.com", "vigiboiontop");

            client.UseDefaultCredentials = false;

            //client.Credentials = credentials;



            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("Registration@csjunction.in");

            msg.To.Add(new MailAddress(RegisterUser.Email));

            msg.Subject = "Login Details CS JUNCTION";

            msg.IsBodyHtml = true;

            msg.Body = string.Format("<html><head></head><body><b>WE WELCOME YOU TO CS JUNCTION!!!<br /><br />Your username:"+RegisterUser.UserName+"<br />And password:"+RegisterUser.Password+"</b></body>");



            try
            {

                client.Send(msg);

                lblMsg.Text = "Your login details has been successfully sent to the email provided";

            }

            catch (Exception ex)
            {

                lblMsg.ForeColor = Color.Red;

                lblMsg.Text = "Error occured while sending your message." + ex.Message;

            }
        }
        //else { lblMsg.Text = "user not found"; throw new Exception("user not found"); }
        string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/";
        }
        Response.Redirect(continueUrl);
    }

}
