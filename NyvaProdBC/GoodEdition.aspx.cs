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
        protected void Page_Load(object sender, EventArgs e)
        {
            NyvaUser userParse = ((Entity.NyvaUser)Application["user_data"]);
            NyvaUser nyvaUser = userParse != null ? userParse : new NyvaUser();
            if (nyvaUser.UserRole == (int)GlobalValues.UserRole.Admin)
            {
                lblMsg.Text = "Створення товару";
                pnlEditionUI.Visible = true;
                if (!Page.IsPostBack)
                {
                    LoadGoodUI(int.Parse(Request.QueryString["id"]));
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        lblMsg.Text = "Зміна товару із ID-" + Request.QueryString["id"];
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
            int gid = int.Parse(Request.QueryString["id"]);
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                using (var db = new GoodContext())
                {
                    Good theGood = db.Goods.FirstOrDefault(x => x.Id == gid);
                    Good input = GetInput();
                    //db.Goods.Attach(theGood);//No effect
                    //db.Entry(theGood).State = System.Data.Entity.EntityState.Modified; //No effect
                    if (theGood != default)
                    {
                        theGood.AmountSold = input.AmountSold;
                        theGood.APF = input.APF;
                        theGood.Barcode = input.Barcode;
                        theGood.Description = input.Description;
                        theGood.ImagesUrl = input.ImagesUrl;//"https://i.pinimg.com/564x/2d/b7/d8/2db7d8c53b818ce838ad8bf6a4768c71.jpg";
                        theGood.Name = input.Name;
                        theGood.OrderPrice = input.OrderPrice;
                        theGood.Profit = input.Profit;
                        theGood.RecievedOn = input.RecievedOn;//DateTime.Parse(GetInput().RecievedOn).Date.ToString();
                        theGood.TotalAmount = input.TotalAmount;
                        theGood.WeightKg = input.WeightKg;
                        //SetGoodValues(goods[editIndex],GetInput());//Non-working
                        db.Entry(theGood).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Response.Redirect("/AdminGoods");
                    }
                    else
                    {
                        Response.Write($"<script>alert('Good on ID does not exist');</script>");
                        Response.Redirect("/Default");
                    }
                }
            }
            else Response.Write($"<script>alert('Unable to change: element selected does not exist');</script>");
        }
    }
}