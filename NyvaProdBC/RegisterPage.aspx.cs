using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        Entity.Contexts.NyvaUserContext db = new Entity.Contexts.NyvaUserContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Entity.NyvaUser GetUserInput(bool encode = true)
        {
            string password = encode ? MD5Hasher.Encrypt(tbPassword.Text) : tbPassword.Text;
            return new Entity.NyvaUser(tbFirstName.Text, tbLastName.Text, tbFatherName.Text, tbEmail.Text, tbPhone.Text, password, GlobalValues.USER_ROLE, GlobalValues.USER_BANNED);
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
        protected void btnRegister_Click(object sender, EventArgs e)
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
    }
}