using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshUsers();
        }
        void RefreshUsers()
        {
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
                TableCell tcViewUser = new TableCell();
                tcViewUser.Controls.Add(btnViewUser);

                Button btnEditUser = new Button();
                TableCell tcEditUser = new TableCell();
                tcEditUser.Controls.Add(btnEditUser);

                Button btnBanUser = new Button();
                TableCell tcBanUser = new TableCell();
                tcBanUser.Controls.Add(btnBanUser);

                Button btnDeleteUser = new Button();
                TableCell tcDeleteUser = new TableCell();
                tcDeleteUser.Controls.Add(btnDeleteUser);

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
            }
        }
    }
}