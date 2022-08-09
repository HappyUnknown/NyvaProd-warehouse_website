﻿using NyvaProdBC.Entity;
using NyvaProdBC.Entity.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class GoodDeletion : System.Web.UI.Page
    {
        static string goodID;
        protected void Page_Load(object sender, EventArgs e)
        {
            goodID = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(goodID))
            {
                lblMsg.Text = $"Видалити товар із ID-{goodID}?";
                btnRedeemDelete.Visible = true;
            }
            else
            {
                lblMsg.Text = "Як ви потрапили на цю сторінку? Поверніться до таблиці адміністрування, і повторіть спробу.";
                btnRedeemDelete.Visible = false;
            }
        }

        protected void btnRedeemDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(goodID))
            {
                string goodID = Request.QueryString["id"];
                var db = new GoodContext();
                var goods = db.Goods.ToList();
                Good theGood = goods.Where(x => x.Id == int.Parse(goodID)).FirstOrDefault();
                int removeIndex = goods.IndexOf(theGood);
                goods.RemoveAt(removeIndex);
                db.SaveChanges();
                Response.Redirect("/AdminGoods");
            }
            else Response.Write($"<script>alert('Неможливо видалити: обраний елемент не існує');</script>");
        }
    }
}