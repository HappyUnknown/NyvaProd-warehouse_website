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
    public partial class GoodEdition : System.Web.UI.Page
    {
        static string goodID;
        protected void Page_Load(object sender, EventArgs e)
        {
            NyvaUser userParse = ((Entity.NyvaUser)Application["user_data"]);
            NyvaUser nyvaUser = userParse != null ? userParse : new NyvaUser();
            if (nyvaUser.UserRole == (int)GlobalValues.UserRole.Admin)
            {
                lblMsg.Text = "Створення товару";
                pnlEditionUI.Visible = true;
                goodID = Request.QueryString["id"];
                if (!Page.IsPostBack)
                {
                    LoadGoodUI(int.Parse(goodID));
                    if (!string.IsNullOrEmpty(goodID))
                    {
                        lblMsg.Text = "Зміна товару із ID-" + goodID;
                        pnlEditionUI.Visible = true;
                    }
                    else
                    {
                        lblMsg.Text = "Як ви потрапили на цю сторінку? Поверніться до таблиці адміністрування, та повторіть спробу.";
                        pnlEditionUI.Visible = false;
                    }
                }
            }
            else
            {
                lblMsg.Text = "Ви не маєте права доступу до цієї сторінки";
                pnlEditionUI.Visible = false;
            }
        }
        void LoadGoodUI(int id)
        {
            var db = new GoodContext();
            var goods = db.Goods.ToList();
            Good theGood = goods.Where(x => x.Id == id).FirstOrDefault();
            int editIndex = goods.IndexOf(theGood);
            FillUI(theGood);
        }
        void FillUI(Good good)
        {
            lblMsg.Text = $"Зміна товару по ID-{good.Id}";
            tbGoodName.Text = good.Name;
            tbDescription.Text = good.Description;
            tbOrderPrice.Text = good.OrderPrice.ToString();
            tbAPF.Text = good.APF.ToString();
            tbProfit.Text = good.Profit.ToString();
            tbTotalAmount.Text = good.TotalAmount.ToString();
            tbAmountSold.Text = good.AmountSold.ToString();
            tbWeightKg.Text = good.WeightKg.ToString();
            tbImageUrls.Text = good.ImagesUrl.ToString();
            tbDeliveryDate.Text = good.RecievedOn.ToString();
            tbGoodCode.Text = good.Barcode.GoodCode.ToString();
            tbProducerCode.Text = good.Barcode.ProducerCode.ToString();
            tbRegionCode.Text = good.Barcode.RegionCode.ToString();
            tbControlDigit.Text = good.Barcode.ControlDigit.ToString();
        }
        Good GetInput()
        {
            Good good = new Good(tbGoodName.Text, tbDescription.Text, double.Parse(tbOrderPrice.Text), double.Parse(tbAPF.Text), double.Parse(tbProfit.Text), int.Parse(tbTotalAmount.Text), int.Parse(tbAmountSold.Text), double.Parse(tbWeightKg.Text), tbImageUrls.Text, tbDeliveryDate.Text, int.Parse(tbGoodCode.Text), int.Parse(tbProducerCode.Text), int.Parse(tbRegionCode.Text), int.Parse(tbControlDigit.Text));
            return good;
        }
        void SetGoodValues(Good to, Good from)
        {
            from.Name = to.Name;
            from.Description = to.Description;
            from.OrderPrice = to.OrderPrice;
            from.APF = to.APF;
            from.Profit = to.Profit;
            from.TotalAmount = to.TotalAmount;
            from.AmountSold = to.AmountSold;
            from.WeightKg = to.WeightKg;
            from.ImagesUrl = to.ImagesUrl;
            from.Barcode.GoodCode = to.Barcode.GoodCode;
            from.Barcode.ProducerCode = to.Barcode.ProducerCode;
            from.Barcode.RegionCode = to.Barcode.RegionCode;
            from.Barcode.ControlDigit = to.Barcode.ControlDigit;
        }
        protected void btnRedeemEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(goodID))
            {
                var db = new GoodContext();
                var goods = db.Goods.ToList();
                Good theGood = goods.Where(x => x.Id == int.Parse(goodID)).FirstOrDefault();
                if (theGood != default)
                {
                    int editIndex = goods.IndexOf(theGood);
                    goods[editIndex].AmountSold = GetInput().AmountSold;
                    goods[editIndex].APF = GetInput().APF;
                    goods[editIndex].Barcode = GetInput().Barcode;
                    goods[editIndex].Description = GetInput().Description;
                    goods[editIndex].ImagesUrl = GetInput().ImagesUrl;//"https://i.pinimg.com/564x/2d/b7/d8/2db7d8c53b818ce838ad8bf6a4768c71.jpg";
                    goods[editIndex].Name = GetInput().Name;
                    goods[editIndex].OrderPrice = GetInput().OrderPrice;
                    goods[editIndex].Profit = GetInput().Profit;
                    goods[editIndex].RecievedOn = DateTime.Parse(GetInput().RecievedOn).Date.ToString();
                    goods[editIndex].TotalAmount = GetInput().TotalAmount;
                    goods[editIndex].WeightKg = GetInput().WeightKg;
                    //SetGoodValues(goods[editIndex],GetInput());//Non-working
                    db.SaveChanges();
                    Response.Redirect("/AdminGoods");
                }
                else Response.Write($"<script>alert('Товар із даним ID не існує');</script>");
            }
            else Response.Write($"<script>alert('Неможливо змінити: обраний елемент не існує');</script>");
        }
    }
}