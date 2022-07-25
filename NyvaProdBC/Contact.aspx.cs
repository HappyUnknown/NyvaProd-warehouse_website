using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class Contact : Page
    {
        public static string appMail = "michelotakuwatson@gmail.com";
        public static string appMailPwd = "iyqzxgwdivjscrdo";
        public static string bridgeAddr = "smtp.gmail.com";
        public static int bridgePort = 587;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool EmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        protected void btnSubmitMail_Click(object sender, EventArgs e)
        {
            if (EmailValid(tbUserEmail.Text))
            {
                tbUserEmail.CssClass = "entryNeutral";
                using (MailMessage mail = new MailMessage(appMail, appMail, "Запит від " + tbUserEmail.Text, tbMailText.Text))
                {
                    using (SmtpClient bridge = new SmtpClient(bridgeAddr, bridgePort))
                    {
                        bridge.UseDefaultCredentials = true;
                        bridge.EnableSsl = true;
                        bridge.Credentials = new NetworkCredential(appMail, appMailPwd);//HARDER PASSWORD, Secured acc
                        bridge.Send(mail);
                    }
                }
                btnSubmitMail.Enabled = false;
            }
            else
            {
                Master.WebEcho = "User e-mail invaild";
                tbUserEmail.CssClass = "entryInvalid";
                //Response.Write("<script language=javascript>alert('E-Mail invalid');</script>");
            }
        }
    }
}