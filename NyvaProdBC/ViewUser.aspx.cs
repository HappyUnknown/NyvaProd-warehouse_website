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
            int uid = int.Parse(Request.QueryString["id"]);
            RefreshUserUI(uid);
        }
        void RefreshUserUI(int id)
        {
            Entity.NyvaUser user = new Entity.Contexts.NyvaUserContext().Users.ToList().Where(x => x.Id == id).FirstOrDefault();
            tbEmail.Text = user.Email;
            tbFatherName.Text = user.FatherName;
            tbFirstName.Text = user.FirstName;
            tbLastName.Text = user.LastName;
            tbPassword.Text = user.Password;
            tbPhone.Text = user.Phone;
            tbUserRole.Text = user.UserRole.ToString();
            chkIsBanned.Checked = user.IsBanned;
        }

        protected void chkIsBanned_CheckedChanged(object sender, EventArgs e)
        {
            ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
        }
    }
}