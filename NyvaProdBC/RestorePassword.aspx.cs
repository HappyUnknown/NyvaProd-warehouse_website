using NyvaProdBC.Entity.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class RestorePassword : System.Web.UI.Page
    {
        public bool KeyValid { get; set; }
        void ResponseAlert(string text)
        {
            Response.Write("<script>alert('" + text + "')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request.QueryString["restore_key"];
            var db = new PasswordRestoreSessionContext();
            var sessions = db.PasswordSessions.ToList();
            ResponseAlert(DateTime.Parse(sessions[sessions.Count - 1].DateClosed) + ">" + DateTime.UtcNow.ToString());
            var openedPasswordSession = sessions.Where(x => x.GUID == key && DateTime.Parse(x.DateClosed) > DateTime.UtcNow).FirstOrDefault();
            //bool sessionOpened = DateTime.Parse(passwordSession.DateClosed) > DateTime.Now;
            bool anyOpenedSession = openedPasswordSession != default;
            KeyValid = anyOpenedSession;
        }

        protected void btnRedeemRestore_Click(object sender, EventArgs e)
        {
            //Restore password using key-user relation table for password request
            //If some user session passes for the request-key - redeem passsword change for this user (or just prevent form load if key does not exist)
        }
    }
}