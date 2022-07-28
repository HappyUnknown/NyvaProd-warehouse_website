using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class SiteMaster : MasterPage
    {
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
    }
}