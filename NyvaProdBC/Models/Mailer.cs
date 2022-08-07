using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace NyvaProdBC.Models
{
    public static class Mailer
    {
        public static void SendMail(string reciever, string subject, string text)
        {
            string bridgeAddr = GlobalValues.BRIDGE_ADDR;
            int bridgePort = GlobalValues.BRIDGE_PORT;
            string launcher = GlobalValues.HOST_EMAIL;
            string launcherPass = GlobalValues.HOST_PASSWORD;
            using (MailMessage mail = new MailMessage(launcher, reciever, subject, text))
            {
                using (SmtpClient bridge = new SmtpClient(bridgeAddr, bridgePort))
                {
                    bridge.UseDefaultCredentials = true;
                    bridge.EnableSsl = true;
                    bridge.Credentials = new System.Net.NetworkCredential(launcher, launcherPass);//HARDER PASSWORD, Secured acc
                    bridge.Send(mail);
                }
            }
        }

    }
}