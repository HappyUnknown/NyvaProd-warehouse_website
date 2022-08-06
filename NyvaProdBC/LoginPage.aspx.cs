using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Entity.NyvaUser GetUserInput()
        {
            return new Entity.NyvaUser("NO_FIRST_NAME_INPUT", "NO_LAST_NAME_INPUT", "NO_FATHER_NAME_INPUT", tbEmail.Text,"NO_PHONE_INPUT", tbPassword.Text);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            List<Entity.NyvaUser> users = new Entity.Contexts.NyvaUserContext().Users.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                Entity.NyvaUser userInput = GetUserInput();
                if (users[i].Email == GetUserInput().Email && users[i].Password == GetUserInput().Password)
                {
                    Application["user_data"] = users[i];
                    Response.Write("<script>alert('Користувач увійшов як " + users[i].Email + ": " + users[i].Password.ToString() + "==" + userInput.Password + "');</script>");
                    Response.Redirect("/Default");
                }
                else
                {
                    Response.Write("<script>alert('" + users[i].Email + "==" + userInput.Email + " | " + users[i].Password.ToString() + "==" + userInput.Password + "');</script>");
                }
            }
            Response.Write("<script>alert('Користувач з такими даними не існує.');</script>");
        }
    }
}