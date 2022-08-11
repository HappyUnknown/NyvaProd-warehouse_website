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
    public partial class ManageUsers1 : System.Web.UI.Page
    {
        static List<SelectorQuad> selectors = new List<SelectorQuad>();
        class SelectorQuad
        {
            public Button GoToView { get; set; }
            public Button GoToEdit { get; set; }
            public Button GoToBan { get; set; }
            public Button GoToDelete { get; set; }
            public SelectorQuad(Button btnToView, Button btnToEdit, Button btnToBan, Button btnToDelete)
            {
                GoToView = btnToView;
                GoToEdit = btnToEdit;
                GoToBan = btnToBan;
                GoToDelete = btnToDelete;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            NyvaUser userParse = ((Entity.NyvaUser)Application["user_data"]);
            NyvaUser nyvaUser = userParse != null ? userParse : new NyvaUser();
            if (nyvaUser.UserRole == (int)GlobalValues.UserRole.Admin)
            {
                lblMsg.Text = "Зареєстровані користувачі";
                RefreshUsers();
            }
            else
            {
                lblMsg.Text = "Ваші повноваження недостатні для доступу до сторінки";
            }
        }
        void RefreshUsers()
        {
            selectors.Clear();
            var users = new Entity.Contexts.NyvaUserContext().Users.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                TableCell tcId = new TableCell();
                Label lblId = new Label();
                lblId.Text = users[i].Id.ToString();
                tcId.Controls.Add(lblId);

                TableCell tcFirstName = new TableCell();
                Label lblFirstName = new Label();
                lblFirstName.Text = users[i].FirstName.ToString();
                tcFirstName.Controls.Add(lblFirstName);

                TableCell tcLastName = new TableCell();
                Label lblLastName = new Label();
                lblLastName.Text = users[i].LastName.ToString();
                tcLastName.Controls.Add(lblLastName);

                TableCell tcFatherName = new TableCell();
                Label lblFatherName = new Label();
                lblFatherName.Text = users[i].FatherName.ToString();
                tcFatherName.Controls.Add(lblFatherName);

                TableCell tcEmail = new TableCell();
                Label lblEmail = new Label();
                lblEmail.Text = users[i].Email.ToString();
                tcEmail.Controls.Add(lblEmail);

                TableCell tcPhone = new TableCell();
                Label lblPhone = new Label();
                lblPhone.Text = users[i].Phone.ToString();
                tcPhone.Controls.Add(lblPhone);

                TableCell tcPassword = new TableCell();
                Label lblPassword = new Label();
                lblPassword.Text = users[i].Password.ToString();
                tcPassword.Controls.Add(lblPassword);
                tcPhone.Controls.Add(lblPhone);

                TableCell tcUserRole = new TableCell();
                Label lblUserRole = new Label();
                lblUserRole.Text = users[i].UserRole.ToString();
                tcUserRole.Controls.Add(lblUserRole);

                TableCell tcIsBanned = new TableCell();
                Label lblIsBanned = new Label();
                lblIsBanned.Text = users[i].IsBanned.ToString();
                tcIsBanned.Controls.Add(lblIsBanned);

                Button btnViewUser = new Button();
                btnViewUser.Text = "👁";
                btnViewUser.Click += BtnViewUser_Click;
                TableCell tcViewUser = new TableCell();
                tcViewUser.Controls.Add(btnViewUser);

                Button btnEditUser = new Button();
                btnEditUser.Text = "✏️";
                btnEditUser.Click += BtnEditUser_Click;
                TableCell tcEditUser = new TableCell();
                tcEditUser.Controls.Add(btnEditUser);

                Button btnBanUser = new Button();
                btnBanUser.Text = "⚠️";
                btnBanUser.Click += BtnBanUser_Click;
                TableCell tcBanUser = new TableCell();
                if (users[i].Email != ((NyvaUser)Application["user_data"]).Email) tcBanUser.Controls.Add(btnBanUser);

                Button btnDeleteUser = new Button();
                btnDeleteUser.Text = "❌";
                btnDeleteUser.Click += BtnDeleteUser_Click;
                TableCell tcDeleteUser = new TableCell();
                if (users[i].Email != ((NyvaUser)Application["user_data"]).Email) tcDeleteUser.Controls.Add(btnDeleteUser);

                TableRow row = new TableRow();
                row.Cells.Add(tcId);
                row.Cells.Add(tcFirstName);
                row.Cells.Add(tcLastName);
                row.Cells.Add(tcFatherName);
                row.Cells.Add(tcEmail);
                row.Cells.Add(tcPhone);
                row.Cells.Add(tcPassword);
                row.Cells.Add(tcUserRole);
                row.Cells.Add(tcIsBanned);

                row.Cells.Add(tcViewUser);
                row.Cells.Add(tcEditUser);
                row.Cells.Add(tcBanUser);
                row.Cells.Add(tcDeleteUser);
                tblUsers.Rows.Add(row);

                SelectorQuad quad = new SelectorQuad(btnViewUser, btnEditUser, btnBanUser, btnDeleteUser);
                selectors.Add(quad);
            }
        }
        int ViewButtonIndex(Button vb)
        {
            for (int i = 0; i < selectors.Count; i++)
                if (selectors[i].GoToView == vb)
                    return i;
            return -1;
        }
        int DeleteButtonIndex(Button db)
        {
            for (int i = 0; i < selectors.Count; i++)
                if (selectors[i].GoToDelete == db)
                    return i;
            return -1;
        }
        int EditButtonIndex(Button eb)
        {
            for (int i = 0; i < selectors.Count; i++)
                if (selectors[i].GoToEdit == eb)
                    return i;
            return -1;
        }
        int BanButtonIndex(Button bb)
        {
            for (int i = 0; i < selectors.Count; i++)
                if (selectors[i].GoToBan == bb)
                    return i;
            return -1;
        }
        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            int index = DeleteButtonIndex((Button)sender);
            var db = new NyvaUserContext();
            var users = db.Users.ToList();
            Response.Redirect("/UserDeletion?id=" + users[index].Id);
        }
        private void BtnBanUser_Click(object sender, EventArgs e)
        {
            int index = BanButtonIndex((Button)sender);
            var db = new NyvaUserContext();
            var users = db.Users.ToList();
            Response.Redirect("/UserBanning?id=" + users[index].Id);
        }
        private void BtnViewUser_Click(object sender, EventArgs e)
        {
            int index = ViewButtonIndex((Button)sender);
            var db = new NyvaUserContext();
            var users = db.Users.ToList();
            Response.Redirect("/ViewUser?id=" + users[index].Id);
        }
        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            int index = EditButtonIndex((Button)sender);
            var db = new NyvaUserContext();
            var users = db.Users.ToList();
            Response.Redirect("/UserEdition?id=" + users[index].Id);
        }
    }
}