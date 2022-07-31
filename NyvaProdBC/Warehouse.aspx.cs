﻿using NyvaProdBC.Entity;
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
    public partial class Warehouse : System.Web.UI.Page
    {
        static readonly System.Drawing.Color selectColor = System.Drawing.Color.CornflowerBlue;
        static readonly System.Drawing.Color idleColor = System.Drawing.Color.LightGray;
        static List<Models.SelectorPair> selectors;
        static List<Good> goods;

        Good GoodByButton(SelectorPair pair)
        {
            try
            {
                for (int i = 0; i < selectors.Count; i++)
                {
                    if (selectors[i].selector.UniqueID == pair.selector.UniqueID)
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
                    if (selectors[i].selector == (Button)sender)
                    {
                        Basket.Add(selectors[i]);
                        selectors[i].counter.Text = (int.Parse(selectors[i].counter.Text) + 1).ToString();
                    }
                    else if (selectors[i].selector.BackColor != selectColor)
                    {
                        selectors[i].selector.BackColor = idleColor;
                    }
                }
            }
            catch (Exception ex) { ResponseAlert("GS: " + goods.Count + " == SL:" + selectors.Count + " => " + ex.Message); }
            RefreshBasketUI();
        }
        private void UnselectorButton_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < selectors.Count; i++)
            //    selectors[i].BackColor = idleColor;

            try
            {
                for (int i = 0; i < selectors.Count; i++)
                {
                    if (selectors[i].unselector == (Button)sender)
                    {
                        int counter = int.Parse(selectors[i].counter.Text);
                        if (counter > 0) selectors[i].counter.Text = (counter - 1).ToString();
                        else ResponseAlert("Неможливо замовити менше нуля одиниць товару.");
                        int removeAt = Basket.IndexOf(selectors[i]);//-1
                        string rmsg = Basket.RemoveAt(removeAt);
                        if (rmsg != string.Empty) ResponseAlert(rmsg);
                        break;
                    }
                    else if (selectors[i].selector.BackColor != selectColor)
                    {
                        selectors[i].selector.BackColor = idleColor;
                    }
                }
            }
            catch (Exception ex) { ResponseAlert("GS: " + goods.Count + " == SL:" + selectors.Count + " => " + ex.Message); }
            RefreshBasketUI();
        }
        void RefreshButtonUI()
        {
            for (int i = 0; i < selectors.Count; i++)
                selectors[i].selector.BackColor = idleColor;
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

                TableCell tcCounter = new TableCell();
                tcSelector.CssClass = "tableCell";
                TextBox counterField = new TextBox();
                counterField.Height = 20;
                counterField.BackColor = idleColor;
                counterField.Text = "0";
                tcCounter.Controls.Add(counterField);

                TableCell tcUnselector = new TableCell();
                tcUnselector.CssClass = "tableCell";
                Button unselectorButton = new Button();
                unselectorButton.BackColor = idleColor;
                unselectorButton.Click += UnselectorButton_Click;
                unselectorButton.Text = "✓";
                tcUnselector.Controls.Add(unselectorButton);
                selectors.Add(new SelectorPair(selectorButton, counterField, unselectorButton));

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
                tr.Cells.Add(tcCounter);
                tr.Cells.Add(tcUnselector);
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
            string orderKey = Request.QueryString["order"];
            if (orderKey == "yes")
            {
                ResponseAlert("STATE: ORDERED");
                selectors.Clear();
                Basket.Clear();
                Response.Redirect("/Warehouse.aspx");///Inconfidence - You need to press button to reset request: need returning on a page with no request
            }
            if (!Page.IsPostBack)
            {
                Basket.Clear(); //In case session continues after window closing
                selectors = new List<Models.SelectorPair>();
                goods = GlobalValues.goods;
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
        }
    }
}