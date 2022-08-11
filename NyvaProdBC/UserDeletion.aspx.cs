using NyvaProdBC.Entity;
using NyvaProdBC.Entity.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class UserDeletion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    LoadUserUI(int.Parse(Request.QueryString["id"]));
                    lblMsg.Text = $"Видалити користувача із ID-{Request.QueryString["id"]}?";
                    pnlDeletionUI.Visible = true;
                }
                else
                {
                    lblMsg.Text = "Як ви потрапили на цю сторінку? Поверніться до таблиці адміністрування, і повторіть спробу.";
                    pnlDeletionUI.Visible = false;
                }
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
        }
        //https://stackoverflow.com/questions/17723276/delete-a-single-record-from-entity-framework
        protected void btnRedeemDelete_Click(object sender, EventArgs e)
        {
            string userID = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(userID))
            {
                var db = new NyvaUserContext();
                var users = db.Users.ToList();
                NyvaUser theUser = users.Where(x => x.Id == int.Parse(userID)).FirstOrDefault();
                //int removeIndex = goods.IndexOf(theGood);
                //Response.Write($"<script>alert('INDEX-{removeIndex};ID-{theGood.Id}');</script>");
                db.Users.Attach(theUser);//Unignore changes
                db.Users.Remove(theUser);
                db.SaveChanges();
                Response.Redirect("/ManageUsers");
            }
            else Response.Write($"<script>alert('Неможливо видалити: обраний елемент не існує');</script>");
        }
    }
}