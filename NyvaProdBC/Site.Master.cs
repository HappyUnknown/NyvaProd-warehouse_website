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
            object currentUser = Application["user_data"];
            if (currentUser != null)
                CurrentEmail = currentUser.ToString();
            else
                CurrentEmail = string.Empty;
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
        void SendMail(string reciever, string subject, string text)
        {
            string bridgeAddr = GlobalValues.BRIDGE_ADDR;
            int bridgePort = GlobalValues.BRIDGE_PORT;
            string launcher = GlobalValues.HOST_EMAIL;
            string launcherPass = GlobalValues.HOST_PASSWORD;
            using (MailMessage mail = new MailMessage(launcher, reciever, subject, text))
            {
                using (SmtpClient bridge = new SmtpClient(bridgeAddr, bridgePort))
                {
                    bridge.UseDefaultCredentials = true;
                    bridge.EnableSsl = true;
                    bridge.Credentials = new System.Net.NetworkCredential(launcher, launcherPass);//HARDER PASSWORD, Secured acc
                    bridge.Send(mail);
                }
            }
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
                SendMail(launcher, admsubject, admtext);
                SendMail(reciever.Email, usersubject, usertext);
                liBasket.Items.Clear();
                tbShipper.Text = string.Empty;
                AppState.Ordered = true;
                ResponseAlert("Очікуйте відповіді від власника за своєю адресою.");
                Response.Redirect("/Warehouse.aspx?order=yes");
            }
            else ResponseAlert("Спершу зареєструйтесь.");
        }
    }
}