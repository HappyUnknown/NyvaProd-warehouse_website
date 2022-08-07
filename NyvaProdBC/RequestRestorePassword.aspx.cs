using NyvaProdBC.Entity.Contexts;
using NyvaProdBC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class RequestRestorePassword : System.Web.UI.Page
    {
        public bool Submited { get; set; } = false;
        const int ACCESS_MINUTES = 30;
        //const string DT_PATTERN = "yy-MM-dd/hh:mm:ss:fff";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void ResponseAlert(string text)
        {
            Response.Write("<script>alert('" + text + "')</script>");
        }
        protected void btnRequestRestore_Click(object sender, EventArgs e)
        {
            var user = new NyvaUserContext().Users.ToList().Where(x => x.Email == tbUserEmail.Text).FirstOrDefault();
            if (user != default)
            {
                var openedPasswordSession = new PasswordRestoreSessionContext().PasswordSessions.ToList().Where(x => DateTime.Parse(x.DateClosed) > DateTime.UtcNow && x.UID == user.Id).FirstOrDefault();
                if (openedPasswordSession == default)
                {
                    string guid = Guid.NewGuid().ToString();
                    DateTime start = DateTime.UtcNow;
                    string startStr = start.ToString();
                    DateTime finish = start.AddMinutes(ACCESS_MINUTES);
                    string finishStr = finish.ToString();
                    var session = new Entity.PasswordRestoreSession(user.Id, guid, startStr, finishStr);
                    var db = new PasswordRestoreSessionContext();
                    db.PasswordSessions.Add(session);
                    db.SaveChanges();
                    Mailer.SendMail(tbUserEmail.Text, "Password change", $"https://localhost:44332/RestorePassword?restore_key={guid}");
                    ResponseAlert("Session added. Change password untill: " + finishStr);
                    Submited = true;
                }
                else
                    ResponseAlert("Password restoring is on cooldown");
            }
            else ResponseAlert("Inexisting user");
            //if email is registered and all restoration sessions are closed
            //Requesting Guid.NewGuid generation, to use it as a key to access password-change session
            //Generate Guid.NewGuid
            //Send link for RestorePassword.aspx.cs with Guid.NewGuid request parameter 
        }
    }
}