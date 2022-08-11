using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class LogoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (((Entity.NyvaUser)Application["user_data"]) != null)
                {
                    lblMsg.Text = "Вихід";
                    pnlLogoutUI.Visible = true;
                }
                else
                {
                    lblMsg.Text = "Ви ще не увійшли - вихід неможливий";
                    pnlLogoutUI.Visible = false;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (((Entity.NyvaUser)Application["user_data"]) != null)
            {
                Response.Write($"<script>alert('Вдалий вихід з акаунту: {((Entity.NyvaUser)Application["user_data"]).Email}');</script>");//Не відображається
                Application["user_data"] = null;
                Response.Redirect("/Default");
            }
            else
            {
                Response.Write("<script>alert('Неможливо вийти - користувач не увійшов до акаунту.');</script>");
            }
        }
    }
}