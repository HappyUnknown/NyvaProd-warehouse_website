using NyvaProdBC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class AddGood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateGood_Click(object sender, EventArgs e)
        {
            double orderPrice = double.Parse(tbOrderPrice.Text);
            double apf = double.Parse(tbAPF.Text);
            double profit = double.Parse(tbProfit.Text);
            int totalAmount = int.Parse(tbTotalAmount.Text);
            int amountSold = int.Parse(tbAmountSold.Text);
            double weightKg = double.Parse(tbWeightKg.Text);
            int regionCode = int.Parse(tbRegionCode.Text);
            int producerCode = int.Parse(tbProducerCode.Text);
            int goodCode = int.Parse(tbGoodCode.Text);
            int controlDigit = int.Parse(tbControlDigit.Text);
            var newGood = new Good(tbGoodName.Text, tbDescription.Text, orderPrice, apf, profit, totalAmount, amountSold, weightKg, tbImageUrls.Text, tbDeliveryDate.Text, regionCode, producerCode, goodCode, controlDigit);
            var db = new Entity.Contexts.GoodContext();
            db.Goods.Add(newGood);
            db.SaveChanges();
            Response.Redirect("/Warehouse");
        }
    }
}