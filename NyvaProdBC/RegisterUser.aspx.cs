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
                db.Users.Add(nyvaUser);
                db.SaveChanges();
                Response.Write("<script>alert('Користувача зареєстровано.');</script>");
            }
            else
            {
                if (!phoneValid)
                {
                    Response.Write("<script>alert('Синтаксичну перевірку телефону не складено.');</script>");
                }
                else if (!mailValid)
                {
                    if (!mailUnique)
                    {
                        Response.Write("<script>alert('Пошту вже зайнято.');</script>");
                    }
                    else if (!mailSyntaxed)
                    {
                        Response.Write("<script>alert('Синтаксичну перевірку пошти не складено.');</script>");
                    }
                }
                else if (!passwordValid)
                {
                    if (!passwordConfirmed)
                    {
                        Response.Write($"<script>alert('Підтвердження не співпадає з паролем.');</script>");
                    }
                    else if (!lengthValid)
                    {
                        Response.Write($"<script>alert('Довжину паролю обмежено: повинна бути більшою за {MIN_PASSWORD_LENGTH}');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Невірні вхідні дані реєстрації');</script>");
                }
            }
        }

        protected void btnCheckRegistration_Click(object sender, EventArgs e)
        {
            Entity.NyvaUser nyvaUser = GetUserInput();
            Entity.NyvaUser lastNyvaUser = db.Users.Count() == 0 ? new Entity.NyvaUser() : db.Users.ToList()[db.Users.Count() - 1];// new() != default
            if (RegexCheck.IsEmail(nyvaUser.Email))
            {
                bool mailClone = MailClone(nyvaUser);
                string userStr = lastNyvaUser.Email;
                if (mailClone)
                    Response.Write("<script>alert('Пошта відома. Остання: " + userStr + "');</script>");
                else
                    Response.Write("<script>alert('Нова пошта. Остання: " + userStr + "');</script>");
            }
            else
                Response.Write("<script>alert('Це не пошта. Остання: " + lastNyvaUser.Email + "');</script>");
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
                    Response.Write("<script>alert('Користувач увійшов як " + users[i].Email + ": " + users[i].Password.ToString() + "==" + userInput.Password + "');</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('" + users[i].Email + "==" + userInput.Email + " | " + users[i].Password.ToString() + "==" + userInput.Password + "');</script>");
                }
            }
            Response.Write("<script>alert('Користувач з такими даними не існує.');</script>");
        }

        protected void btnCurrentUser_Click(object sender, EventArgs e)
        {
            if (Application["user_data"] != null)
                Response.Write("<script>alert('Поточний користувач: " + ((Entity.NyvaUser)Application["user_data"]).Email + "');</script>");
            else
                Response.Write("<script>alert('Для перевірки необхідно увійти.');</script>");
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Warehouse.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (((Entity.NyvaUser)Application["user_data"]) != null)
            {
                Response.Write($"<script>alert('Вдалий вихід з акаунту: {((Entity.NyvaUser)Application["user_data"]).Email}');</script>");//Не відображається
                Application["user_data"] = null;
            }
            else
            {
                Response.Write("<script>alert('Неможливо вийти - користувач не увійшов до акаунту.');</script>");
            }

        }
    }
}