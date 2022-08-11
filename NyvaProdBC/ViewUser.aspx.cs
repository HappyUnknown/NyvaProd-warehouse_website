using NyvaProdBC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NyvaUser userParse = ((Entity.NyvaUser)Application["user_data"]);
            NyvaUser nyvaUser = userParse != null ? userParse : new NyvaUser();
            if (nyvaUser.UserRole == (int)GlobalValues.UserRole.Admin)
            {
                pnlViewUserUI.Visible = true;
                int uid = int.Parse(Request.QueryString["id"]);
                RefreshUserUI(uid);
            }
            else
            {
                pnlViewUserUI.Visible = false;
                lblMsg.Text = $"Ви не маєте права доступу до цієї сторінки";
            }
        }
        void RefreshUserUI(int id)
        {
            Entity.NyvaUser user = new Entity.Contexts.NyvaUserContext().Users.ToList().Where(x => x.Id == id).FirstOrDefault();
            if (user != default)
            {
                tbEmail.Text = user.Email;
                tbFatherName.Text = user.FatherName;
                tbFirstName.Text = user.FirstName;
                tbLastName.Text = user.LastName;
                tbPassword.Text = user.Password;
                tbPhone.Text = user.Phone;
                tbUserRole.Text = user.UserRole.ToString();
                chkIsBanned.Checked = user.IsBanned;
                lblMsg.Text = $"Дані про куристувача за ID-{id}";
            }
        }

        protected void chkIsBanned_CheckedChanged(object sender, EventArgs e)
        {
            ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
        }
    }
}