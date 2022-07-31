using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Models
{
    public class SelectorPair
    {
        public System.Web.UI.WebControls.Button selector = new System.Web.UI.WebControls.Button();
        public System.Web.UI.WebControls.Button unselector = new System.Web.UI.WebControls.Button();
        public SelectorPair(System.Web.UI.WebControls.Button selector, System.Web.UI.WebControls.Button unselector)
        {
            this.selector = selector;
            this.unselector = unselector;
        }
        public SelectorPair() { }
    }
}