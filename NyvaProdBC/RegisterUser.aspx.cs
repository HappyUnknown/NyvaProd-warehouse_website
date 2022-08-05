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
        public const string cellPattern = @"^\+(?:[0-9]●?){6,14}[0-9]$";

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

        Entity.NyvaUser GetUserInput()
        {
            int id;
            int.TryParse(tbId.Text, out id);
            return new Entity.NyvaUser(id, tbFirstName.Text, tbLastName.Text, tbFatherName.Text, tbEmail.Text, tbPhone.Text, tbPassword.Text);
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

            Entity.NyvaUser nyvaUser = GetUserInput();

            bool lengthValid = tbPassword.Text.Length >= MIN_PASSWORD_LENGTH;
            bool passwordConfirmed = tbPassword.Text == tbPasswordVerifiy.Text;
            bool passwordValid = lengthValid && passwordConfirmed;

            bool mailUnique = !MailClone(nyvaUser);
            bool mailSyntaxed = RegexCheck.IsEmail(nyvaUser.Email);
            bool mailValid = mailUnique && mailSyntaxed;

            bool phoneValid = RegexCheck.IsCellNumber(nyvaUser.Phone);

            if (passwordValid && mailValid && phoneValid)
            {
                Response.Write("<script>alert('Registration done');</script>");
                db.Users.Add(nyvaUser);
                db.SaveChanges();
            }
            else
            {
                if (!phoneValid)
                {
                    Response.Write("<script>alert('Phone invalid');</script>");
                }
                else if (!mailValid)
                {
                    if (!mailUnique)
                    {
                        Response.Write("<script>alert('Mail already used');</script>");
                    }
                    else if (!mailSyntaxed)
                    {
                        Response.Write("<script>alert('Mail syntax check fail');</script>");
                    }
                }
                else if (!passwordValid)
                {
                    if (!passwordConfirmed)
                    {
                        Response.Write($"<script>alert('Password confirmation fails');</script>");
                    }
                    else if (!lengthValid)
                    {
                        Response.Write($"<script>alert('Password length restricted: must be longer than {MIN_PASSWORD_LENGTH}');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid registration input');</script>");
                }
            }
        }

        protected void btnCheckRegistration_Click(object sender, EventArgs e)
        {
            Entity.NyvaUser nyvaUser = GetUserInput();
            bool mailClone = MailClone(nyvaUser);
            Entity.NyvaUser lastNyvaUser = db.Users.Count() == 0 ? new Entity.NyvaUser() : db.Users.ToList()[db.Users.Count() - 1];// new() != default
            string userStr = lastNyvaUser.Email;
            if (mailClone)
                Response.Write("<script>alert('Mail known. Last e-mail: " + userStr + "');</script>");
            else
                Response.Write("<script>alert('New mail. Last e-mail: " + userStr + "');</script>");
        }

        protected void btnLoginUser_Click(object sender, EventArgs e)
        {
            List<Entity.NyvaUser> users = new Entity.Contexts.NyvaUserContext().Users.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                Entity.NyvaUser userInput = GetUserInput();
                if (users[i].Email == GetUserInput().Email && users[i].Password == GetUserInput().Password)
                {
                    Application["user_data"] = users[i];
                    Response.Write("<script>alert('User logged in as " + users[i].Email + ": " + users[i].Password.ToString() + "==" + userInput.Password + "');</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('" + users[i].Email + "==" + userInput.Email + " | " + users[i].Password.ToString() + "==" + userInput.Password + "');</script>");
                }
            }
            Response.Write("<script>alert('Cannot log in');</script>");
        }

        protected void btnCurrentUser_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('User is: " + ((Entity.NyvaUser)Application["user_data"]).Email + "');</script>");
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Warehouse.aspx");
        }
    }
}