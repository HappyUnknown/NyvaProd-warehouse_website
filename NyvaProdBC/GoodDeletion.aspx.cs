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
    public partial class GoodDeletion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string goodID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(goodID))
                {
                    lblMsg.Text = $"Видалити товар із ID-{goodID}?";
                    pnlDeletionUI.Visible = true;
                    Good good = new GoodContext().Goods.ToList().Where(x => x.Id == int.Parse(goodID)).FirstOrDefault();
                    FillUI(good);
                }
                else
                {
                    lblMsg.Text = "Як ви потрапили на цю сторінку? Поверніться до таблиці адміністрування, і повторіть спробу.";
                    pnlDeletionUI.Visible = false;
                }
            }
        }
        void FillUI(Good good)
        {
            lblMsg.Text = $"Видалення товару по ID-{good.Id}";
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
        //https://stackoverflow.com/questions/17723276/delete-a-single-record-from-entity-framework
        protected void btnRedeemDelete_Click(object sender, EventArgs e)
        {
            string goodID = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(goodID))
            {
                var db = new GoodContext();
                var goods = db.Goods.ToList();
                Good theGood = goods.Where(x => x.Id == int.Parse(goodID)).FirstOrDefault();
                //int removeIndex = goods.IndexOf(theGood);
                //Response.Write($"<script>alert('INDEX-{removeIndex};ID-{theGood.Id}');</script>");
                db.Goods.Attach(theGood);//Unignore changes //Alternitive: db.Entry(theGood).State = EntityState.Modified; 
                db.Goods.Remove(theGood);
                db.SaveChanges();
                Response.Redirect("/AdminGoods");
            }
            else Response.Write($"<script>alert('Неможливо видалити: обраний елемент не існує');</script>");
        }
    }
}