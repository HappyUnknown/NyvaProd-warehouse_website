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
    public partial class GoodEdition : System.Web.UI.Page
    {
        static string goodID;
        protected void Page_Load(object sender, EventArgs e)
        {
            goodID = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(goodID))
            {
                lblMsg.Text = "Зміна товару із ID-" + goodID;
                pnlEditionUI.Visible = true;
                LoadGoodUI(int.Parse(goodID));
            }
            else
            {
                lblMsg.Text = "Як ви потрапили на цю сторінку? Поверніться до таблиці адміністрування, і повторіть спробу.";
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
                    SetGoodValues(goods[editIndex], GetInput());
                    db.SaveChanges();
                    Response.Redirect("/AdminGoods");
                }
                else Response.Write($"<script>alert('Товар із даним ID не існує');</script>");
            }
            else Response.Write($"<script>alert('Неможливо змінити: обраний елемент не існує');</script>");
        }
    }
}