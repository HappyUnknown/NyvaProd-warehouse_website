using NyvaProdBC.Entity;
using NyvaProdBC.Models;
using NyvaProdTest_ExcelCRUD;
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
        public static Entity.NyvaUser User { get; set; }
        Good GoodByButton(SelectorPair pair)
        {
            try
            {
                for (int i = 0; i < Ware.Selectors.Count; i++)//For all ware selectors
                {
                    if (Ware.Selectors[i].selector.UniqueID == pair.selector.UniqueID)//If caller is in range
                    {
                        return Ware.Goods[i];//Return coresponding good
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
                for (int i = 0; i < Ware.Selectors.Count; i++)//For all good-selectors 
                {
                    if (Ware.Selectors[i].selector == (Button)sender)//If selector pressed is in range
                    {
                        Basket.Add(Ware.Selectors[i]);//Add coresponding selector to basket (stands for good)
                        Ware.Selectors[i].counter.Text = (int.Parse(Ware.Selectors[i].counter.Text) + 1).ToString();//Refresh UI counter in textbox
                    }
                }
                for (int i = 0; i < Basket.BaseArray.Length; i++)//For all basket items
                {
                    for (int j = i; j < Basket.BaseArray.Length; j++)//Parallel to basket items
                    {
                        if (GoodByButton(Basket.BaseArray[i]).Name.CompareTo(GoodByButton(Basket.BaseArray[j]).Name) == 1)//Basket item's name goes second, but button standing first
                        {
                            //swap
                            SelectorPair temp = Basket.BaseArray[i];
                            Basket.BaseArray[i] = Basket.BaseArray[j];
                            Basket.BaseArray[j] = temp;
                        }
                    }
                }
            }
            catch (Exception ex) { ResponseAlert("GS: " + Ware.Goods + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
            RefreshBasketUI();//Refresh basket UI (no matter it refreshes in master)
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
                        //Ware.Selectors[i].counter.Text = (int.Parse(Ware.Selectors[i].counter.Text) - 1).ToString();//Refresh UI counter in textbox
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
        void RefreshTableUI(string key = "")
        {
            tblGoods.Rows.Clear();
            Ware.Selectors.Clear();//Preventing selector-button duplicating
            for (int i = 0; i < Ware.Goods.Count; i++)
            {
                if (Ware.Goods[i].Name.Contains(key))
                {
                    System.Threading.Thread.Sleep(1);
                    Image img = new Image();
                    img.ImageUrl = Ware.Goods[i].ImagesUrl;
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
                    image.ImageUrl = Ware.Goods[i].ImagesUrl.ToString();
                    tcImage.CssClass = "tableCell";
                    tcImage.Controls.Add(image);

                    TableCell tcArriveDate = new TableCell();
                    Label arriveDate = new Label();
                    arriveDate.Text = Ware.Goods[i].RecievedOn;
                    tcImage.CssClass = "tableCell";
                    tcImage.Controls.Add(arriveDate);

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

                    TableCell tcGoToView = new TableCell();
                    tcGoToView.CssClass = "tableCell";
                    Button btnGoToView = new Button();
                    btnGoToView.BackColor = GlobalValues.idleColor;
                    btnGoToView.Click += BtnGoToView_Click;
                    btnGoToView.Text = "👁";
                    tcGoToView.Controls.Add(btnGoToView);

                    TableCell tcUnselector = new TableCell();
                    tcUnselector.CssClass = "tableCell";
                    Button unselectorButton = new Button();
                    unselectorButton.BackColor = GlobalValues.idleColor;
                    unselectorButton.Click += UnselectorButton_Click;
                    unselectorButton.Text = "-";
                    tcUnselector.Controls.Add(unselectorButton);

                    TableCell tcCounter = new TableCell();
                    tcCounter.CssClass = "tableCell";
                    TextBox counterField = new TextBox();
                    counterField.Height = 20;
                    counterField.BackColor = GlobalValues.idleColor;
                    counterField.Text = "0";
                    counterField.TextMode = TextBoxMode.Number;//still allows float
                    counterField.TextChanged += NewCounterField_TextChanged;
                    counterField.AutoPostBack = true;
                    tcCounter.Controls.Add(counterField);

                    TableCell tcSelector = new TableCell();
                    tcSelector.CssClass = "tableCell";
                    Button selectorButton = new Button();
                    selectorButton.BackColor = GlobalValues.idleColor;
                    selectorButton.Click += SelectorButton_Click;
                    selectorButton.Text = "+";
                    tcSelector.Controls.Add(selectorButton);

                    Ware.Selectors.Add(new SelectorPair(btnGoToView, unselectorButton, counterField, selectorButton));

                    TableRow tr = new TableRow();
                    tr.Cells.Add(tcId);
                    tr.Cells.Add(tcName);
                    tr.Cells.Add(tcDescription);
                    tr.Cells.Add(tcOrderPrice);
                    tr.Cells.Add(tcProfit);
                    tr.Cells.Add(tcAPF);
                    tr.Cells.Add(tcTotalAmount);
                    tr.Cells.Add(tcAmountSold);
                    tr.Cells.Add(tcWeightKg);
                    tr.Cells.Add(tcArriveDate);
                    tr.Cells.Add(tcImage);
                    tr.Cells.Add(tcGoodCode);
                    tr.Cells.Add(tcProducerCode);
                    tr.Cells.Add(tcRegionCode);
                    tr.Cells.Add(tcControlDigit);

                    tr.Cells.Add(tcGoToView);
                    tr.Cells.Add(tcUnselector);
                    tr.Cells.Add(tcCounter);
                    tr.Cells.Add(tcSelector);
                    tblGoods.Rows.Add(tr);
                }
            }
        }
        private void NewCounterField_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ////0.Given
                //tbCounter = (TextBox)sender
                //replaceValue = Basket.BaseArray.Where(x=>x.counter==tbCounter).FirstOrDefault()
                //replaceCount = int.Parse(tbCounter.Text)
                var tbCounter = (TextBox)sender;
                var replaceValue = Basket.BaseArray.Where(x => x.counter == (TextBox)sender).FirstOrDefault();
                try
                {
                    if (replaceValue == default) { Master.WebEcho = "default"; return; }
                    var replaceCount = int.Parse(replaceValue.counter.Text);
                    try
                    {
                        ////1.Remove to-replace items
                        //SelectorPair[] fullBasketTemp = new SelectorPair[Basket.BaseArray.Length]
                        //for int i=0;i<Basket.BaseArray;i++: fullBasketTemp[i]=el
                        //skipCounters=0
                        //for int i=0;i<fullBasketTemp.Length;i++: if fullBasketTemp[i].Counter.UniqueID==tbCounter.UniqueID: skipCounters++
                        //Basket.BaseArray=new int[fullBasketTemp.Length-skipCounters]
                        SelectorPair[] fullBasketTemp = new SelectorPair[Basket.BaseArray.Length];
                        for (int i = 0; i < fullBasketTemp.Length; i++)
                            fullBasketTemp[i] = Basket.BaseArray[i];
                        int skipCounter = 0;
                        try
                        {
                            for (int i = 0; i < fullBasketTemp.Length; i++)
                                if (fullBasketTemp[i].counter.UniqueID == tbCounter.UniqueID)
                                    skipCounter++;
                            Basket.BaseArray = new SelectorPair[fullBasketTemp.Length - skipCounter];

                            ////2.Re-add skipping to-replaces
                            //slope=0; for int i=0;i<fullBasketTemp.Length;i++: if fullBasketTemp[i] != replaceValue: Basket.BaseArray[slope++]=fullBasketTemp[i]
                            for (int i = 0, slope = 0; i < fullBasketTemp.Length; i++)
                                if (fullBasketTemp[i].counter.UniqueID != replaceValue.counter.UniqueID)
                                    Basket.BaseArray[slope++] = fullBasketTemp[i];
                            //3.Add items back in amount
                            //for int ri=0;ri<replaceCount;ri++:
                            //SelectorPair[] pushBackTemp = new SelectorPair[Basket.BaseArray.Length]
                            //for int i=0;i<Basket.BaseArray.Length;i++: pushBackTemp[i]=Basket.BaseArray[i]
                            //Basket.BaseArray=new int[Basket.BaseArray.Length+1]
                            //for int i=0;i<pushBackTemp.Length;i++: Basket.BaseArray[i]=pushBackTemp[i]
                            //Basket.BaseArray[Basket.BaseArray.Length-1]=replaceValue
                            try
                            {
                                for (int ri = 0; ri < replaceCount; ri++)
                                {
                                    //Perform pushback operation multiple times
                                    SelectorPair[] pushBackTemp = new SelectorPair[Basket.BaseArray.Length];
                                    for (int i = 0; i < Basket.BaseArray.Length; i++)
                                        pushBackTemp[i] = Basket.BaseArray[i];
                                    Basket.BaseArray = new SelectorPair[Basket.BaseArray.Length + 1];
                                    for (int i = 0; i < pushBackTemp.Length; i++)
                                        Basket.BaseArray[i] = pushBackTemp[i];
                                    Basket.BaseArray[Basket.BaseArray.Length - 1] = replaceValue;
                                }

                                for (int i = 0; i < Basket.BaseArray.Length; i++)//For all basket items
                                {
                                    for (int j = i; j < Basket.BaseArray.Length; j++)//Parallel to basket items
                                    {
                                        if (GoodByButton(Basket.BaseArray[i]).Name.CompareTo(GoodByButton(Basket.BaseArray[j]).Name) == 1)//Basket item's name goes second, but button standing first
                                        {
                                            //swap
                                            SelectorPair temp = Basket.BaseArray[i];
                                            Basket.BaseArray[i] = Basket.BaseArray[j];
                                            Basket.BaseArray[j] = temp;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex) { Master.WebEcho = ("4GS: " + Ware.Goods.Count + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
                        }
                        catch (Exception ex) { Master.WebEcho = ("3GS: " + Ware.Goods.Count + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
                    }
                    catch (Exception ex) { Master.WebEcho = ("2.5GS: " + Ware.Goods.Count + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
                }
                catch (Exception ex) { Master.WebEcho = ("2GS: " + Ware.Goods.Count + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
            }
            catch (Exception ex) { Master.WebEcho = ("1GS: " + Ware.Goods.Count + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
            RefreshBasketUI();//Refresh basket UI (no matter it refreshes in master)
        }
        private void CounterField_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Master.WebEcho = "CounterField_TextChanged";
                //for (int i = 0; i < Ware.Selectors.Count; i++)//For all good-selectors 
                //{
                //    if (Ware.Selectors[i].selector == (Button)sender)//If selector pressed is in range
                //    {
                //        Ware.Selectors[i].counter.Text = (int.Parse(Ware.Selectors[i].counter.Text)).ToString();//Refresh UI counter in textbox
                //        //Basket.RemoveAt();///Separate loop looks for each ware selectors' good, then compares. If good id matches with related to selector pressed - add good's basket index to array. Next - we skip those indexes when recreating.
                //        Basket.Add(Ware.Selectors[i]);//Add coresponding selector to basket (stands for good)
                //    }
                //}
                //for (int i = 0; i < Basket.BaseArray.Length; i++)//For all basket items
                //{
                //    for (int j = i; j < Basket.BaseArray.Length; j++)//Parallel to basket items
                //    {
                //        if (GoodByButton(Basket.BaseArray[i]).Name.CompareTo(GoodByButton(Basket.BaseArray[j]).Name) == 1)//Basket item's name goes second, but button standing first
                //        {
                //            //swap
                //            SelectorPair temp = Basket.BaseArray[i];
                //            Basket.BaseArray[i] = Basket.BaseArray[j];
                //            Basket.BaseArray[j] = temp;
                //        }
                //    }
                //}
            }
            catch (Exception ex) { ResponseAlert("GS: " + Ware.Goods + " == SL:" + Ware.Selectors.Count + " => " + ex.Message); }
            RefreshBasketUI();//Refresh basket UI (no matter it refreshes in master)
        }

        private void BtnGoToView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Ware.Selectors.Count; i++)
            {
                if (((Button)sender).UniqueID == Ware.Selectors[i].viewer.UniqueID)//wry: parallel arrays
                {
                    Response.Redirect("/ShopGood?id=" + Ware.Goods[i].Id);
                }
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
            User = (NyvaUser)Application["user_data"];
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
        //https://stackoverflow.com/questions/12914473/how-can-i-show-up-openfiledialog-class-in-asp-net
        protected void btnDbToExcel_Click(object sender, EventArgs e)
        {
            string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string download = System.IO.Path.Combine(user, "Downloads");
            string name = download + @"\Test.xlsx";
            try
            {
                NyvaExcel.ExampleToExcel(name);
            }
            catch (Exception ex) { Master.WebEcho = ex.Message + ": " + name; }
        }

        protected void btnRedeemSearch_Click(object sender, EventArgs e)
        {
            btnClearKey.Visible = true;
            RefreshTableUI(tbKey.Text);
        }

        protected void btnClearKey_Click(object sender, EventArgs e)
        {
            btnClearKey.Visible = false;
            tbKey.Text = string.Empty;
            RefreshTableUI(tbKey.Text);
        }
    }
}