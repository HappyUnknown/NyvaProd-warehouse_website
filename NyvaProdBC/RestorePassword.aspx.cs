﻿using NyvaProdBC.Entity.Contexts;
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
        int OpenedSessionIndex()
        {
            string key = Request.QueryString["restore_key"];
            var db = new PasswordRestoreSessionContext();
            var sessions = db.PasswordSessions.ToList();
            ResponseAlert(DateTime.Parse(sessions[sessions.Count - 1].DateClosed) + ">" + DateTime.UtcNow.ToString());
            var openedPasswordSession = sessions.Where(x => x.GUID == key && DateTime.Parse(x.DateClosed) > DateTime.UtcNow).FirstOrDefault();
            //bool sessionOpened = DateTime.Parse(passwordSession.DateClosed) > DateTime.Now;
            int result = sessions.IndexOf(openedPasswordSession);
            return result;
        }
        bool AnyOpenedSessionOnKey()
        {
            return OpenedSessionIndex() != -1;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            KeyValid = AnyOpenedSessionOnKey();
        }

        protected void btnRedeemRestore_Click(object sender, EventArgs e)
        {
            int sessionIndex = OpenedSessionIndex();
            if (sessionIndex != -1)
            {
                if (tbNewPassword.Text == tbNewConfirmation.Text)
                {
                    var sessionDB = new PasswordRestoreSessionContext();
                    var sessions = sessionDB.PasswordSessions.ToList();
                    var theSession = sessions[sessionIndex];
                    var userDB = new NyvaUserContext();
                    var users = userDB.Users.ToList();
                    var theUser = users.Where(x => x.Id == theSession.UID).FirstOrDefault();
                    int userIndex = users.IndexOf(theUser);
                    users[userIndex].Password = tbNewPassword.Text;
                    userDB.SaveChanges();
                    Response.Redirect("/Login");
                }
                else ResponseAlert("Passwords do not match");
            }
            else ResponseAlert("No sessions available");
            //Restore password using key-user relation table for password request
            //If some user session passes for the request-key - redeem passsword change for this user (or just prevent form load if key does not exist)
        }
    }
}