using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class Warehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> urls = new List<string>() { "https://i.pinimg.com/564x/2d/b7/d8/2db7d8c53b818ce838ad8bf6a4768c71.jpg", "https://i.pinimg.com/564x/59/1b/23/591b232ca14c99ad3b4bbf98b0b340f5.jpg", "https://i.pinimg.com/564x/c1/74/2d/c1742d01ea1d5d501c9d9736bbfe9504.jpg", "https://i.pinimg.com/564x/76/f1/dc/76f1dcf48d7aa03f0baa46a4f283b023.jpg", "https://i.pinimg.com/564x/e7/6a/0a/e76a0aa2d6f1433a539b780cbe2b2076.jpg", "https://i.pinimg.com/564x/a7/31/e5/a731e5b3b04f240d2ee19ecad50f5270.jpg", "https://i.pinimg.com/564x/79/72/92/797292038b1592ec361975bb6b8ef76a.jpg", "https://i.pinimg.com/564x/32/a5/fe/32a5fec188101ec9499f9106d61636f4.jpg", "https://i.pinimg.com/750x/48/5d/e7/485de7d77dea7ff90a306873f0fa1314.jpg", "https://i.pinimg.com/564x/d3/00/71/d30071078b36d93ee025ec6079de2b62.jpg", "https://i.pinimg.com/564x/47/4e/be/474ebe59a9e6e6542b08b705a0f18ff2.jpg", "https://i.pinimg.com/564x/69/d7/44/69d7441f188683c3b1b730be986a355a.jpg" };
            for (int i = 0; i < 2; i++)
            {
                System.Threading.Thread.Sleep(1);
                Image img = new Image();
                img.ImageUrl = urls[new Random().Next(0, urls.Count - 1)];
                img.Height = 100;
                img.Width = 100;
                TableCell tc1 = new TableCell();
                Label lblItemName = new Label();
                tc1.CssClass = "tableCell";
                lblItemName.Text = "#" + i.ToString();
                tc1.Controls.Add(lblItemName);
                TableCell tc2 = new TableCell();
                tc2.CssClass = "tableCell";
                tc2.Controls.Add(img);
                TableRow tr = new TableRow();
                tr.BorderStyle = BorderStyle.Solid;
                tr.BorderColor = System.Drawing.Color.Green;
                tr.BorderWidth = 3;
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tblGoods.Rows.Add(tr);
            }
        }
    }
}