﻿using NyvaProdBC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class UserEdition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NyvaUser currentUser = (NyvaUser)Application["user_data"];
            if (currentUser != null)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    LoadUserUI(int.Parse(Request.QueryString["id"]));
                    lblMsg.Text = $"Видалити користувача із ID-{Request.QueryString["id"]}?";
                    pnlEditionUI.Visible = true;
                    if (!Page.IsPostBack)
                    {
                        int uid = int.Parse(Request.QueryString["id"]);
                        LoadUserUI(uid);

                    } //LOAD REQUIRED WHEN LOADING START, BECAUSE IT FIRST REFRESHES AND THEN PROCESSES CLICK
                }
                else
                {
                    lblMsg.Text = "Як ви потрапили на цю сторінку? Поверніться до таблиці адміністрування, і повторіть спробу.";
                    pnlEditionUI.Visible = false;
                }
            }
            else
            {
                lblMsg.Text = $"Ви не маєте права доступу до цієї сторінки";
                pnlEditionUI.Visible = false;
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
        void SetUserValues(NyvaUser to, NyvaUser from)
        {
            to.FatherName = from.FatherName;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Email = from.Email;
            to.Phone = from.Phone;
            to.UserRole = from.UserRole;
            to.IsBanned = from.IsBanned;
        }
        NyvaUser InputUser()
        {
            NyvaUser nyvaUser = new NyvaUser(tbFirstName.Text, tbLastName.Text, tbFatherName.Text, tbEmail.Text, tbPhone.Text, tbPassword.Text, int.Parse(tbUserRole.Text), chkIsBanned.Checked);
            return nyvaUser;
        }
        protected void btnRedeemEdit_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(goodID))
            //{
            //    var db = new GoodContext();
            //    var goods = db.Goods.ToList();
            //    Good theGood = goods.Where(x => x.Id == int.Parse(goodID)).FirstOrDefault();
            //    if (theGood != default)
            //    {
            //        int editIndex = goods.IndexOf(theGood);
            //        goods.RemoveAt(editIndex);
            //        db.SaveChanges();
            //        Response.Redirect("/AdminGoods");
            //    }
            //    else Response.Write($"<script>alert('Товар із даним ID не існує');</script>");
            //}
            //else Response.Write($"<script>alert('Неможливо змінити: обраний елемент не існує');</script>");

            int uid = int.Parse(Request.QueryString["id"]);
            var db = new Entity.Contexts.NyvaUserContext();
            var users = db.Users.ToList();
            NyvaUser nyvaUser = users.Where(x => x.Id == uid).FirstOrDefault();
            if (nyvaUser != default)
            {
                NyvaUser userInput = InputUser();
                int editIndex = users.IndexOf(nyvaUser);
                users[editIndex].FatherName = userInput.FatherName;
                users[editIndex].FirstName = userInput.FirstName;
                users[editIndex].LastName = userInput.LastName;
                users[editIndex].Email = userInput.Email;
                users[editIndex].Phone = userInput.Phone;
                users[editIndex].UserRole = userInput.UserRole;
                //users[editIndex].IsBanned = userInput.IsBanned;
                db.SaveChanges();
                Response.Redirect("/ManageUsers");
            }
        }

        protected void chkIsBanned_CheckedChanged(object sender, EventArgs e)
        {
            int uid = int.Parse(Request.QueryString["id"]);
            if (((NyvaUser)Application["user_data"]).Id == uid)
                Response.Write("<script>alert('Ви не можете забанити себе!');</script>");
            else
                Response.Write("<script>alert('OK');</script>");
        }
    }
}