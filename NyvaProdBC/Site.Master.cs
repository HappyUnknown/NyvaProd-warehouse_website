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
            string reciever = tbShipper.Text;
            string subject = $@"New order by {reciever}";
            string text = FormedOrder();
            string launcherPass = GlobalValues.HOST_PASSWORD;
            string bridgeAddr = GlobalValues.BRIDGE_ADDR;
            int bridgePort = GlobalValues.BRIDGE_PORT;
            if (liBasket.Items.Count == 0) { ResponseAlert("Не обрано товарів для замовлення. Оберіть товари."); return; }
            try { MailAddress address = new MailAddress(reciever); } catch { ResponseAlert($"\"{reciever}\" не є дійсною електронною адресою. Уведіть дійсну адресу замовника."); return; }
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
            liBasket.Items.Clear();
            tbShipper.Text = string.Empty;
            AppState.Ordered = true;
            ResponseAlert("Очікуйте відповіді від власника за своєю адресою.");
            //Response.Redirect("/Default.aspx");
        }
    }
}