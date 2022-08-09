using NyvaProdBC.Entity;
using NyvaProdBC.Models;
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
        public static SelectorPair[] BaseArray = new SelectorPair[0];
        public static void Add(SelectorPair b)
        {
            SelectorPair[] temp = new SelectorPair[BaseArray.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = BaseArray[i];
            }
            BaseArray = new SelectorPair[temp.Length + 1];
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
                SelectorPair[] temp = new SelectorPair[BaseArray.Length];
                for (i = 0; i < temp.Length; i++)
                    temp[i] = BaseArray[i];
                BaseArray = new SelectorPair[temp.Length - 1];
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
        public static int IndexOf(SelectorPair b)
        {
            for (int i = 0; i < BaseArray.Length; i++)
            {
                if (BaseArray[i].selector.UniqueID == b.selector.UniqueID)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int IndexOfUnselector(SelectorPair b)
        {
            for (int i = 0; i < BaseArray.Length; i++)
            {
                if (BaseArray[i].selector.UniqueID == b.unselector.UniqueID)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void Clear()
        {
            BaseArray = new SelectorPair[0];
        }
    }
    public static class Ware
    {
        public static List<Good> Goods;
        public static List<Models.SelectorPair> Selectors;

    }
    //static class StrExt
    //{
    //    public static int CompareTo(this string str1, string str2)
    //    {
    //        int minLen = (str1.Length > str2.Length ? str1 : str2).Length;
    //        for (int i = 0; i < minLen; i++)
    //            if (str1[i] > str2[i]) return 1;
    //            else if (str1[i] < str2[i]) return -1;
    //        return 0;
    //    }
    //}
    public partial class Warehouse : System.Web.UI.Page
    {
        Good GoodByButton(SelectorPair pair)
        {
            try
            {
                for (int i = 0; i < Ware.Selectors.Count; i++)
                {
                    if (Ware.Selectors[i].selector.UniqueID == pair.selector.UniqueID)
                    {
                        return Ware.Goods[i];
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
        /// <summary>
        /// Function is being called not only to refresh, but also to sync global basket with local on change
        /// </summary>
        void RefreshBasketUI()
        {
            Application["basket"] = Basket.BaseArray;
            Master.RefreshBasketUI();
        }
        private void SelectorButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Ware.Selectors.Count; i++)
                {
                    if (Ware.Selectors[i].selector == (Button)sender)
                    {
                        Basket.Add(Ware.Selectors[i]);
                        Ware.Selectors[i].counter.Text = (int.Parse(Ware.Selectors[i].counter.Text) + 1).ToString();
                    }
                    else if (Ware.Selectors[i].selector.BackColor != GlobalValues.selectColor)
                    {
                        Ware.Selectors[i].selector.BackColor = GlobalValues.idleColor;
                    }
                }
                for (int i = 0; i < Basket.BaseArray.Length; i++)
                {
                    for (int j = i; j < Basket.BaseArray.Length; j++)
                    {
                        if (GoodByButton(Basket.BaseArray[i]).Name.CompareTo(GoodByButton(Basket.BaseArray[j]).Name) == 1)//Caller goes second, but first in queue
                        {
                            SelectorPair temp = Basket.BaseArray[i];
                            Basket.BaseArray[i] = Basket.BaseArray[j];
                            Basket.BaseArray[j] = temp;
                        }
                    }
                }
            }
            catch (Exception ex) { ResponseAlert("GS: " + Ware.Goods + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
            RefreshBasketUI();
        }
        private void UnselectorButton_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < selectors.Count; i++)
            //    selectors[i].BackColor = idleColor;

            try
            {
                for (int i = 0; i < Ware.Selectors.Count; i++)
                {
                    if (Ware.Selectors[i].unselector == (Button)sender)
                    {
                        int counter = int.Parse(Ware.Selectors[i].counter.Text);
                        if (counter > 0) Ware.Selectors[i].counter.Text = (counter - 1).ToString();
                        else ResponseAlert("Неможливо замовити менше нуля одиниць товару.");
                        int removeAt = Basket.IndexOf(Ware.Selectors[i]);//-1
                        string rmsg = Basket.RemoveAt(removeAt);
                        if (rmsg != string.Empty) ResponseAlert(rmsg);
                        break;
                    }
                    else if (Ware.Selectors[i].selector.BackColor != GlobalValues.selectColor)
                    {
                        Ware.Selectors[i].selector.BackColor = GlobalValues.idleColor;
                    }
                }
            }
            catch (Exception ex) { ResponseAlert("GS: " + Ware.Goods.Count + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
            RefreshBasketUI();
        }
        void RefreshButtonUI()
        {
            for (int i = 0; i < Ware.Selectors.Count; i++)
                Ware.Selectors[i].selector.BackColor = GlobalValues.idleColor;
        }
        void RefreshTableUI()
        {
            Ware.Selectors.Clear();//Preventing selector-button duplicating
            for (int i = 0; i < Ware.Goods.Count; i++)
            {
                System.Threading.Thread.Sleep(1);
                Image img = new Image();
                img.ImageUrl = Ware.Goods[i].ImageUrl;
                img.Height = 100;
                img.Width = 100;

                TableCell tcId = new TableCell();
                Label lblItemId = new Label();
                lblItemId.Text = "#" + Ware.Goods[i].Id.ToString();
                tcId.CssClass = "tableCell";
                tcId.Controls.Add(lblItemId);

                TableCell tcName = new TableCell();
                Label lblItemName = new Label();
                lblItemName.Text = Ware.Goods[i].Name.ToString();
                tcName.CssClass = "tableCell";
                tcName.Controls.Add(lblItemName);

                TableCell tcDescription = new TableCell();
                Label lblDescription = new Label();
                lblDescription.Text = Ware.Goods[i].Description.ToString();
                tcDescription.CssClass = "tableCell";
                tcDescription.Controls.Add(lblDescription);

                TableCell tcOrderPrice = new TableCell();
                Label lblOrderPrice = new Label();
                lblOrderPrice.Text = Ware.Goods[i].OrderPrice.ToString();
                tcOrderPrice.CssClass = "tableCell";
                tcOrderPrice.Controls.Add(lblOrderPrice);

                TableCell tcAPF = new TableCell();
                Label lblAPF = new Label();
                lblAPF.Text = Ware.Goods[i].APF.ToString();
                tcAPF.CssClass = "tableCell";//TROUBLE
                tcAPF.Controls.Add(lblAPF);

                TableCell tcProfit = new TableCell();
                Label lblProfit = new Label();
                lblProfit.Text = Ware.Goods[i].Profit.ToString();
                tcProfit.CssClass = "tableCell";//TROUBLE
                tcProfit.Controls.Add(lblProfit);

                TableCell tcWeightKg = new TableCell();
                Label lblWeightKg = new Label();
                lblWeightKg.Text = Ware.Goods[i].WeightKg.ToString();
                tcWeightKg.CssClass = "tableCell";
                tcWeightKg.Controls.Add(lblWeightKg);

                TableCell tcTotalAmount = new TableCell();
                Label lblTotalAmount = new Label();
                lblTotalAmount.Text = Ware.Goods[i].TotalAmount.ToString();
                tcTotalAmount.CssClass = "tableCell";
                tcTotalAmount.Controls.Add(lblTotalAmount);

                TableCell tcAmountSold = new TableCell();
                Label lblAmountSold = new Label();
                lblAmountSold.Text = Ware.Goods[i].AmountSold.ToString();
                tcAmountSold.CssClass = "tableCell";
                tcAmountSold.Controls.Add(lblAmountSold);

                TableCell tcImage = new TableCell();
                Image image = new Image();
                image.Height = 100;
                image.Width = 100;
                image.ImageUrl = Ware.Goods[i].ImageUrl.ToString();
                tcImage.CssClass = "tableCell";
                tcImage.Controls.Add(image);

                TableCell tcRegionCode = new TableCell();
                Label lblRegionCode = new Label();
                lblRegionCode.Text = Ware.Goods[i].Barcode.RegionCode.ToString();
                tcRegionCode.CssClass = "tableCell";
                tcRegionCode.Controls.Add(lblRegionCode);

                TableCell tcProducerCode = new TableCell();
                Label lblProducerCode = new Label();
                lblProducerCode.Text = Ware.Goods[i].Barcode.ProducerCode.ToString();
                tcProducerCode.CssClass = "tableCell";
                tcProducerCode.Controls.Add(lblProducerCode);

                TableCell tcGoodCode = new TableCell();
                Label lblGoodCode = new Label();
                lblGoodCode.Text = Ware.Goods[i].Barcode.GoodCode.ToString();
                tcGoodCode.CssClass = "tableCell";
                tcGoodCode.Controls.Add(lblGoodCode);

                TableCell tcControlDigit = new TableCell();
                Label lblControlDigit = new Label();
                lblControlDigit.Text = Ware.Goods[i].Barcode.ControlDigit.ToString();
                tcControlDigit.CssClass = "tableCell";
                tcControlDigit.Controls.Add(lblControlDigit);

                TableCell tcSelector = new TableCell();
                tcSelector.CssClass = "tableCell";
                Button selectorButton = new Button();
                selectorButton.BackColor = GlobalValues.idleColor;
                selectorButton.Click += SelectorButton_Click;
                selectorButton.Text = "✓";
                tcSelector.Controls.Add(selectorButton);

                TableCell tcCounter = new TableCell();
                tcCounter.CssClass = "tableCell";
                TextBox counterField = new TextBox();
                counterField.Height = 20;
                counterField.BackColor = GlobalValues.idleColor;
                counterField.Text = "0";
                counterField.TextMode = TextBoxMode.Number;//still allows float
                tcCounter.Controls.Add(counterField);

                TableCell tcUnselector = new TableCell();
                tcUnselector.CssClass = "tableCell";
                Button unselectorButton = new Button();
                unselectorButton.BackColor = GlobalValues.idleColor;
                unselectorButton.Click += UnselectorButton_Click;
                unselectorButton.Text = "✓";
                tcUnselector.Controls.Add(unselectorButton);

                Ware.Selectors.Add(new SelectorPair(unselectorButton, counterField, selectorButton));

                TableRow tr = new TableRow();
                tr.Cells.Add(tcId);
                tr.Cells.Add(tcName);
                tr.Cells.Add(tcDescription);
                tr.Cells.Add(tcOrderPrice);
                tr.Cells.Add(tcAPF);
                tr.Cells.Add(tcProfit);
                tr.Cells.Add(tcTotalAmount);
                tr.Cells.Add(tcAmountSold);
                tr.Cells.Add(tcWeightKg);
                tr.Cells.Add(tcImage);
                tr.Cells.Add(tcGoodCode);
                tr.Cells.Add(tcProducerCode);
                tr.Cells.Add(tcRegionCode);
                tr.Cells.Add(tcControlDigit);

                tr.Cells.Add(tcUnselector);
                tr.Cells.Add(tcCounter);
                tr.Cells.Add(tcSelector);
                tblGoods.Rows.Add(tr);
            }
        }
        struct GoodInBasket
        {
            public string GoodName { get; set; }
            public int Count { get; set; }
            public GoodInBasket(string goodName, int count)
            {
                GoodName = goodName;
                Count = count;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            string orderKey = Request.QueryString["order"];
            if (orderKey == "yes")
            {
                ResponseAlert("STATE: ORDERED");
                Ware.Selectors.Clear();
                Basket.Clear();
                Response.Redirect("/Warehouse.aspx");///Inconfidence - You need to press button to reset request: need returning on a page with no request
            }
            if (!Page.IsPostBack)
            {
                //Basket.Clear(); //In case session continues after window closing
                Ware.Selectors = new List<Models.SelectorPair>();
                using (Entity.Contexts.GoodContext db = new Entity.Contexts.GoodContext())
                {
                    if (db.Goods.Count() == 0)
                    {
                        for (int i = 0; i < GlobalValues.goods.Count; i++)
                            db.Goods.Add(GlobalValues.goods[i]);
                        db.SaveChanges();
                    }
                    Ware.Goods = db.Goods.ToList();
                }
            }
            else
            {
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
            RefreshBasketUI();
        }

    }
}