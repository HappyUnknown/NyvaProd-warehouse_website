using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC
{
    public class GoodUI
    {
        public System.Web.UI.WebControls.Button GoodButton { get; set; }
        public int Amount { get; set; }
        public GoodUI() { }
        public GoodUI(System.Web.UI.WebControls.Button goodButton, int amount)
        {
            GoodButton = goodButton;
            Amount = amount;
        }
    }
}