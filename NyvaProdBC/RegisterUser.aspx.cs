using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public static class RegexCheck
    {
        public const string cellPattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        public static bool IsCellNumber(string line)
        {
            if (line != null) return System.Text.RegularExpressions.Regex.IsMatch(line, cellPattern);
            else return false;
        }
        public static bool IsEmail(string line)
        {
            try { var mailAddr = new System.Net.Mail.MailAddress(line); } catch { return false; }
            return true;
        }
    }
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
            const int MIN_PASSWORD_LENGTH = 6;

            Entity.NyvaUser nyvaUser = GetUserData();

            bool lengthValid = tbPassword.Text.Length >= MIN_PASSWORD_LENGTH;
            bool passwordConfirmed = tbPassword.Text == tbPasswordVerifiy.Text;
            bool passwordValid = lengthValid && passwordConfirmed;

            bool mailClone = MailClone(nyvaUser);
            bool mailExists = RegexCheck.IsEmail(nyvaUser.Email);
            bool mailValid = mailClone && mailExists;

            bool phoneValid = RegexCheck.IsCellNumber(nyvaUser.Phone);

            if (!mailClone && passwordValid && mailValid && phoneValid)
            {
                Response.Write("<script>alert('Registration done');</script>");
                db.Users.Add(nyvaUser);
                db.SaveChanges();
            }
            else Response.Write("<script>alert('Invalid registration input');</script>");
        }

        protected void btnCheckRegistration_Click(object sender, EventArgs e)
        {
            Entity.NyvaUser nyvaUser = GetUserData();
            bool mailClone = MailClone(nyvaUser);
            Entity.NyvaUser lastNyvaUser = db.Users.Count() == 0 ? new Entity.NyvaUser() : db.Users.ToList()[db.Users.Count() - 1];// new() != default
            string userStr = lastNyvaUser.Email;
            if (mailClone)
                Response.Write("<script>alert('Mail known. Last e-mail: " + userStr + "');</script>");
            else
                Response.Write("<script>alert('New mail. Last e-mail: " + userStr + "');</script>");
        }
    }
}