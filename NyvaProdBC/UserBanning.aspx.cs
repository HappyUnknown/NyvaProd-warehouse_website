using NyvaProdBC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class UserBanning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NyvaUser currentUser = (NyvaUser)Application["user_data"];
            if (currentUser != null)
            {
                int uid = int.Parse(Request.QueryString["id"]);
                LoadUserUI(uid);
                pnlBanning.Visible = true;
            }
            else { lblMsg.Text = "Ви не маєте повноважень для доступу до сторінки"; pnlBanning.Visible = false; }
        }
        void LoadUserUI(int id)
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
            if (user.IsBanned)
            {
                lblMsg.Text = $"Розбанити користувача з ID-{user.Id}?";
            }
            else
            {
                lblMsg.Text = $"Забанити користувача з ID-{user.Id}?";
            }
        }
        protected void btnRedeemBan_Click(object sender, EventArgs e)
        {
            int uid = int.Parse(Request.QueryString["id"]);
            var db = new Entity.Contexts.NyvaUserContext();
            var users = db.Users.ToList();
            NyvaUser nyvaUser = users.Where(x => x.Id == uid).FirstOrDefault();
            if (nyvaUser != default)
            {
                int editIndex = users.IndexOf(nyvaUser);
                users[editIndex].IsBanned = !users[editIndex].IsBanned;
                db.SaveChanges();
                Response.Redirect("/ManageUsers");
            }
        }
    }
}