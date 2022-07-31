using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Models
{
    public class SelectorPair
    {
        public System.Web.UI.WebControls.Button selector = new System.Web.UI.WebControls.Button();
        public System.Web.UI.WebControls.TextBox counter = new System.Web.UI.WebControls.TextBox();
        public System.Web.UI.WebControls.Button unselector = new System.Web.UI.WebControls.Button();
        public SelectorPair(System.Web.UI.WebControls.Button selector, System.Web.UI.WebControls.TextBox counter, System.Web.UI.WebControls.Button unselector)
        {
            this.selector = selector;
            this.counter = counter;
            this.unselector = unselector;
        }
        public SelectorPair() { }
    }
}