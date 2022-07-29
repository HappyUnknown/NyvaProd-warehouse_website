using NyvaProdBC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public static class Basket
    {
        public static Button[] BaseArray = new Button[0];
        public static void Add(Button b)
        {
            Button[] temp = new Button[BaseArray.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = BaseArray[i];
            }
            BaseArray = new Button[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                BaseArray[i] = temp[i];
            }
            BaseArray[BaseArray.Length - 1] = b;
        }
        public static string RemoveAt(int index)
        {
            int i = 0;
            int j = 0;
            try
            {
                Button[] temp = new Button[BaseArray.Length];
                for (i = 0; i < temp.Length; i++)
                    temp[i] = BaseArray[i];
                BaseArray = new Button[temp.Length - 1];
                for (j = 0; j < index; j++)
                    BaseArray[j] = temp[j];
                for (j = index + 1; j < temp.Length; j++)
                    BaseArray[j - 1] = temp[j];
            }
            catch (Exception ex)
            {
                return new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name + ", i-" + i + ", j-" + j + ", rindex-" + index + ": " + ex.Message;
            }
            return string.Empty;
        }
        public static int IndexOf(Button b)
        {
            for (int i = 0; i < BaseArray.Length; i++)
            {
                if (BaseArray[i].UniqueID == b.UniqueID)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void Clear()
        {
            BaseArray = new Button[0];
        }
    }
    public partial class Warehouse : System.Web.UI.Page
    {
        static readonly System.Drawing.Color selectColor = System.Drawing.Color.CornflowerBlue;
        static readonly System.Drawing.Color idleColor = System.Drawing.Color.LightGray;
        static List<Button> selectors;
        static List<Good> goods;

        Good GoodByButton(Button button)
        {
            try
            {
                for (int i = 0; i < selectors.Count; i++)
                {
                    if (selectors[i].UniqueID == button.UniqueID)
                    {
                        return goods[i];
                    }
                }
                ResponseAlert("No good on button");
            }
            catch (Exception ex) { ResponseAlert(ex.Message); }
            return default;
        }
        void ResponseAlert(string text)
        {
            Response.Write("<script>alert('" + text + "')</script>");
        }
        void Alert(string msg)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('" + msg + "');", true);
        }
        private void SelectorButton_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < selectors.Count; i++)
            //    selectors[i].BackColor = idleColor;

            try
            {
                for (int i = 0; i < selectors.Count; i++)
                {
                    if (selectors[i] == (Button)sender)
                    {
                        if (selectors[i].BackColor == idleColor)
                        {
                            selectors[i].BackColor = selectColor;
                            //basket.Add(new GoodUI(goods[i], selectors[i], 1)); //Bug with removing is not refreshing indexes: need references instead of variables
                            Basket.Add(selectors[i]);
                        }
                        else
                        {
                            selectors[i].BackColor = idleColor;
                            int removeAt = Basket.IndexOf(selectors[i]);//-1
                            string rmsg = Basket.RemoveAt(removeAt);
                            if (rmsg != string.Empty) ResponseAlert(rmsg);
                            break;
                        }
                    }
                    else if (selectors[i].BackColor != selectColor)
                    {
                        selectors[i].BackColor = idleColor;
                    }
                }
            }
            catch (Exception ex) { ResponseAlert("GS: " + goods.Count + " == SL:" + selectors.Count + " => " + ex.Message); }
            ResponseAlert("basket: " + Basket.BaseArray.Length);
            RefreshBasketUI();
        }
        void RefreshTableUI()
        {
            selectors.Clear();//Preventing selector-button duplicating
            for (int i = 0; i < goods.Count; i++)
            {
                System.Threading.Thread.Sleep(1);
                Image img = new Image();
                img.ImageUrl = goods[i].ImageUrl;
                img.Height = 100;
                img.Width = 100;

                TableCell tcId = new TableCell();
                Label lblItemId = new Label();
                lblItemId.Text = "#" + goods[i].Id.ToString();
                tcId.CssClass = "tableCell";
                tcId.Controls.Add(lblItemId);

                TableCell tcName = new TableCell();
                Label lblItemName = new Label();
                lblItemName.Text = goods[i].Name.ToString();
                tcName.CssClass = "tableCell";
                tcName.Controls.Add(lblItemName);

                TableCell tcOrderPrice = new TableCell();
                Label lblOrderPrice = new Label();
                lblOrderPrice.Text = goods[i].OrderPrice.ToString();
                tcOrderPrice.CssClass = "tableCell";
                tcOrderPrice.Controls.Add(lblOrderPrice);

                TableCell tcSellPrice = new TableCell();
                Label lblSellPrice = new Label();
                lblSellPrice.Text = goods[i].SellPrice.ToString();
                tcSellPrice.CssClass = "tableCell";//TROUBLE
                tcSellPrice.Controls.Add(lblSellPrice);

                TableCell tcWeightKg = new TableCell();
                Label lblWeightKg = new Label();
                lblWeightKg.Text = goods[i].WeightKg.ToString();
                tcWeightKg.CssClass = "tableCell";
                tcWeightKg.Controls.Add(lblWeightKg);

                TableCell tcImage = new TableCell();
                Image image = new Image();
                image.Height = 100;
                image.Width = 100;
                image.ImageUrl = goods[i].ImageUrl.ToString();
                tcImage.CssClass = "tableCell";
                tcImage.Controls.Add(image);

                TableCell tcRegionCode = new TableCell();
                Label lblRegionCode = new Label();
                lblRegionCode.Text = goods[i].Barcode.RegionCode.ToString();
                tcRegionCode.CssClass = "tableCell";
                tcRegionCode.Controls.Add(lblRegionCode);

                TableCell tcProducerCode = new TableCell();
                Label lblProducerCode = new Label();
                lblProducerCode.Text = goods[i].Barcode.ProducerCode.ToString();
                tcProducerCode.CssClass = "tableCell";
                tcProducerCode.Controls.Add(lblProducerCode);

                TableCell tcGoodCode = new TableCell();
                Label lblGoodCode = new Label();
                lblGoodCode.Text = goods[i].Barcode.GoodCode.ToString();
                tcGoodCode.CssClass = "tableCell";
                tcGoodCode.Controls.Add(lblGoodCode);

                TableCell tcControlDigit = new TableCell();
                Label lblControlDigit = new Label();
                lblControlDigit.Text = goods[i].Barcode.ControlDigit.ToString();
                tcControlDigit.CssClass = "tableCell";
                tcControlDigit.Controls.Add(lblControlDigit);

                TableCell tcSelector = new TableCell();
                tcSelector.CssClass = "tableCell";
                Button selectorButton = new Button();
                selectorButton.BackColor = idleColor;
                selectorButton.Click += SelectorButton_Click;
                selectorButton.Text = "✓";
                tcSelector.Controls.Add(selectorButton);
                selectors.Add(selectorButton);

                TableRow tr = new TableRow();
                tr.Cells.Add(tcId);
                tr.Cells.Add(tcName);
                tr.Cells.Add(tcOrderPrice);
                tr.Cells.Add(tcSellPrice);
                tr.Cells.Add(tcWeightKg);
                tr.Cells.Add(tcImage);
                tr.Cells.Add(tcRegionCode);
                tr.Cells.Add(tcProducerCode);
                tr.Cells.Add(tcGoodCode);
                tr.Cells.Add(tcControlDigit);
                tr.Cells.Add(tcSelector);
                tblGoods.Rows.Add(tr);
            }
        }
        void RefreshBasketUI()
        {
            ResponseAlert(Basket.BaseArray.Length.ToString());
            Master.BasketClear();
            for (int i = 0; i < Basket.BaseArray.Length; i++)
            {
                var item = GoodByButton(Basket.BaseArray[i]);
                Master.BasketAdd(item.Name);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Basket.Clear(); //In case session continues after window closing
                selectors = new List<Button>();
                goods = new List<Good>()
                {
                    new Good(5,"Salt",1,2,3,0,"https://i.pinimg.com/564x/2d/b7/d8/2db7d8c53b818ce838ad8bf6a4768c71.jpg"),
                    new Good(99,"Sugar",2,3,4,0,"https://i.pinimg.com/564x/59/1b/23/591b232ca14c99ad3b4bbf98b0b340f5.jpg"),
                    new Good(41,"Pepper",3,4,5,0,"https://i.pinimg.com/564x/c1/74/2d/c1742d01ea1d5d501c9d9736bbfe9504.jpg"),
                    new Good(16,"Lemonpowder",4,5,6,0,"https://i.pinimg.com/564x/76/f1/dc/76f1dcf48d7aa03f0baa46a4f283b023.jpg")
                };
            }
            else
            {
                if (AppState.Ordered)
                {
                    selectors.Clear();
                    goods.Clear();
                    Basket.Clear();
                    AppState.Ordered = !AppState.Ordered;
                }
                /*
                List<string> urls = new List<string>() {
                    "https://i.pinimg.com/564x/2d/b7/d8/2db7d8c53b818ce838ad8bf6a4768c71.jpg",
                    "https://i.pinimg.com/564x/59/1b/23/591b232ca14c99ad3b4bbf98b0b340f5.jpg",
                    "https://i.pinimg.com/564x/c1/74/2d/c1742d01ea1d5d501c9d9736bbfe9504.jpg",
                    "https://i.pinimg.com/564x/76/f1/dc/76f1dcf48d7aa03f0baa46a4f283b023.jpg",
                    "https://i.pinimg.com/564x/e7/6a/0a/e76a0aa2d6f1433a539b780cbe2b2076.jpg",
                    "https://i.pinimg.com/564x/a7/31/e5/a731e5b3b04f240d2ee19ecad50f5270.jpg",
                    "https://i.pinimg.com/564x/79/72/92/797292038b1592ec361975bb6b8ef76a.jpg",
                    "https://i.pinimg.com/564x/32/a5/fe/32a5fec188101ec9499f9106d61636f4.jpg",
                    "https://i.pinimg.com/750x/48/5d/e7/485de7d77dea7ff90a306873f0fa1314.jpg",
                    "https://i.pinimg.com/564x/d3/00/71/d30071078b36d93ee025ec6079de2b62.jpg",
                    "https://i.pinimg.com/564x/47/4e/be/474ebe59a9e6e6542b08b705a0f18ff2.jpg",
                    "https://i.pinimg.com/564x/69/d7/44/69d7441f188683c3b1b730be986a355a.jpg"
                };
                */
            }
            RefreshTableUI();
        }
    }
}