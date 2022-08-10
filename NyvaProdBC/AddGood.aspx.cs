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
            var newGood = new Good(tbGoodName.Text, tbDescription.Text, double.Parse(tbOrderPrice.Text), double.Parse(tbAPF.Text), double.Parse(tbProfit.Text), int.Parse(tbTotalAmount.Text), int.Parse(tbAmountSold.Text), double.Parse(tbWeightKg.Text), tbImageUrls.Text, DateTime.Today.ToString(), int.Parse(tbRegionCode.Text), int.Parse(tbProducerCode.Text), int.Parse(tbGoodCode.Text), int.Parse(tbControlDigit.Text));
            var db = new Entity.Contexts.GoodContext();
            db.Goods.Add(newGood);
            db.SaveChanges();
            Response.Redirect("/Warehouse");
        }
    }
}