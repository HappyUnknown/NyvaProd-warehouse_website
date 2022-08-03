using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        Entity.Contexts.NyvaUserContext db = new Entity.Contexts.NyvaUserContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        Entity.NyvaUser GetUserData()
        {
            return new Entity.NyvaUser(tbFirstName.Text, tbLastName.Text, tbFatherName.Text, tbEmail.Text, tbPhone.Text);
        }

        bool MailClone(Entity.NyvaUser nyvaUser)
        {
            List<Entity.NyvaUser> nyvaUsers = new Entity.Contexts.NyvaUserContext().Users.ToList();
            for (int i = 0; i < nyvaUsers.Count; i++)
            {
                if (nyvaUsers[i].Email == nyvaUser.Email.Trim(' '))
                {
                    return true;
                }
                else
                {
                    string msg = nyvaUser.Email + "!=" + nyvaUsers[i].Email;
                    Response.Write("<script>console.log('" + msg + "');</script>");
                }
            }
            return false;
        }
        protected void btnRegisterUser_Click(object sender, EventArgs e)
        {
            Entity.NyvaUser nyvaUser = GetUserData();
            bool mailClone = MailClone(nyvaUser);
            if (mailClone)
            {
                Response.Write("<script>alert('Unique mail registered');</script>");
                db.Users.Add(nyvaUser);
                db.SaveChanges();
            }
        }

        protected void btnCheckRegistration_Click(object sender, EventArgs e)
        {
            Entity.NyvaUser nyvaUser = GetUserData();
            bool mailClone = MailClone(nyvaUser);
            Entity.NyvaUser lastNyvaUser = db.Users.ToList()[db.Users.Count() - 1];
            string userStr = "Email:" + lastNyvaUser.Email;
            if (mailClone)
                Response.Write("<script>alert('Mail duplicate. Last e-mail: " + userStr + "');</script>");
            else
                Response.Write("<script>alert('Mail unique. Last e-mail: " + userStr + "');</script>");
        }
    }
}