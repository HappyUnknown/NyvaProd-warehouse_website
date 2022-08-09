using NyvaProdBC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class ViewGood : System.Web.UI.Page
    {
        static string goodID;
        protected void Page_Load(object sender, EventArgs e)
        {
            goodID = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(goodID))
            {
                lblMsg.Text = $"Огляд товару із ID-{goodID}";
                pnlViewUI.Visible = true;
                LoadGoodUI(int.Parse(goodID));
            }
            else
            {
                lblMsg.Text = "Як ви потрапили на цю сторінку? Поверніться до таблиці адміністрування, і повторіть спробу.";
                pnlViewUI.Visible = false;
            }
        }
        void LoadGoodUI(int id)
        {
            var db = new Entity.Contexts.GoodContext();
            var goods = db.Goods.ToList();
            Good theGood = goods.Where(x => x.Id == id).FirstOrDefault();
            int editIndex = goods.IndexOf(theGood);
            FillUI(theGood);
        }
        void FillUI(Good good)
        {
            tbConsumedUntil.Text = good.ConsumedUntil;
            tbDescription.Text = good.Description;
            tbImageUrls.Text = good.ImageUrl;
            tbGoodName.Text = good.Name;
            tbOrderPrice.Text = good.OrderPrice.ToString();
            tbSellPrice.Text = good.SellPrice.ToString();
            tbProductionDate.Text = good.ProductionDate;
            tbWeightKg.Text = good.WeightKg.ToString();
            tbInWare.Text = good.InWare.ToString();
            tbGoodCode.Text = good.Barcode.GoodCode.ToString();
            tbProducerCode.Text = good.Barcode.ProducerCode.ToString();
            tbRegionCode.Text = good.Barcode.RegionCode.ToString();
            tbControlDigit.Text = good.Barcode.ControlDigit.ToString();
        }
    }
}