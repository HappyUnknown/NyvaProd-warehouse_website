using NyvaProdBC.Entity;
using NyvaProdBC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class SiteMaster : MasterPage
    {
        void ResponseAlert(string text)
        {
            Response.Write("<script>alert('" + text + "')</script>");
        }
        public UpdatePanel UPMaster
        {
            get
            {
                return upnlSiteContent;
            }
        }
        public string WebEcho
        {
            get
            {
                return lblWebEcho.Text;
            }
            set
            {
                lblWebEcho.Text = value;
            }
        }
        public string CurrentEmail
        {
            get;
            set;
        }
        public int UserRole
        {
            get;
            set;
        }
        public int CountUniques(Good[] goods, string name)
        {
            int counter = 0;
            for (int i = 0; i < goods.Length; i++)
                if (goods[i].Name == name)
                    counter++;
            return counter;
        }
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
        public void RefreshBasketUI()
        {
            BasketClear();
            SelectorPair[] basket = (SelectorPair[])Application["basket"];
            if (basket != null)
            {
                #region Display wrapped (counted) basket goods
                Good[] basketGoods = new Good[basket.Length];//Creating good array for basket goods
                for (int i = 0; i < basket.Length; i++)
                    basketGoods[i] = GoodByButton(basket[i]);//Translating every basket element into respective good by selector-button
                List<string> uniqueNames = new List<string>();//Array to store unique names - they will be used to wrap element group into 1 line
                List<int> counters = new List<int>();//Array to store unique names' respective counters - they will be used to wrap element group into 1 line without user losing count
                for (int i = 0; i < basketGoods.Length; i++)//For every basket good, translated from button
                    if (!uniqueNames.Contains(basketGoods[i].Name))//We look if its' name is not already being stored inside of unique names' array
                    {
                        uniqueNames.Add(basketGoods[i].Name);//Only then we add the name
                        counters.Add(CountUniques(basketGoods, uniqueNames[uniqueNames.Count - 1]));//And respective counter, calculated by searching for last unique name in the good-list
                    }
                List<GoodInBasket> basketGoodCount = new List<GoodInBasket>();//Array to join counter-arrays, created earlier
                for (int i = 0; i < uniqueNames.Count; i++)//For every counter element
                    basketGoodCount.Add(new GoodInBasket(uniqueNames[i], counters[i]));//Add this counter element into shared basket
                for (int i = 0; i < basketGoodCount.Count; i++)//For every grouped basket good bunch
                    BasketAdd(basketGoodCount[i].Count + "x" + basketGoodCount[i].GoodName);//Add this bunch as a UI-basket element 
                #endregion
            }
        }

        public void BasketAdd(string text)
        {
            ListItem li = new ListItem();
            li.Text = text;
            liBasket.Items.Add(li);
        }
        public void BasketRemoveAt(int index)
        {
            liBasket.Items.RemoveAt(index);
        }
        public void BasketRefresh(params ListItem[] listItems)
        {
            liBasket.Items.Clear();
            for (int i = 0; i < listItems.Length; i++)
                liBasket.Items.Add(listItems[i]);
        }
        public void BasketClear()
        {
            liBasket.Items.Clear();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            NyvaUser currentUser = (NyvaUser)Application["user_data"];
            if (currentUser != null)
            {
                UserRole = currentUser.UserRole;
                CurrentEmail = currentUser.Email;
            }
            else
            {
                UserRole = (int)GlobalValues.UserRole.User;
                CurrentEmail = string.Empty;
            }
            RefreshBasketUI();//In order to display everywhere
        }
        public string FormedOrder()
        {
            var basketItems = liBasket.Items;
            string[] basketLines = new string[basketItems.Count];
            for (int i = 0; i < basketItems.Count; i++)
            {
                basketLines[i] = basketItems[i].Text;
            }
            string order = string.Join("\n", basketLines).TrimEnd('\n');
            return order;
        }
        protected void btnOrder_Click(object sender, EventArgs e)
        {
            string launcher = GlobalValues.HOST_EMAIL;
            //string reciever = tbShipper.Text;
            Entity.NyvaUser reciever = ((Entity.NyvaUser)Application["user_data"]);
            string admsubject = $@"New order by {reciever}";
            string admtext = FormedOrder();
            string usersubject = $@"Ваше замовлення прийняте.";
            string usertext = $@"{reciever}, ваше замовлення було отримане. Очікуйте відповіді від офіційного представника на дану поштову скриньку.";
            if (reciever != null)
            {
                if (liBasket.Items.Count == 0) { ResponseAlert("Не обрано товарів для замовлення. Оберіть товари."); return; }
                try { MailAddress address = new MailAddress(reciever.Email); } catch { ResponseAlert($"\"{reciever}\" не є дійсною електронною адресою. Уведіть дійсну адресу замовника."); return; }
                Mailer.SendMail(launcher, admsubject, admtext);
                Mailer.SendMail(reciever.Email, usersubject, usertext);
                liBasket.Items.Clear();
                AppState.Ordered = true;
                Response.Redirect("/Warehouse.aspx?order=yes");
            }
            else ResponseAlert("Спершу зареєструйтесь.");
        }
    }
}