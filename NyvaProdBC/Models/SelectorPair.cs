using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Models
{
    public class SelectorPair
    {
        public System.Web.UI.WebControls.Button viewer = new System.Web.UI.WebControls.Button();
        public System.Web.UI.WebControls.Button unselector = new System.Web.UI.WebControls.Button();
        public System.Web.UI.WebControls.TextBox counter = new System.Web.UI.WebControls.TextBox();
        public System.Web.UI.WebControls.Button selector = new System.Web.UI.WebControls.Button();
        public SelectorPair(System.Web.UI.WebControls.Button viewer, System.Web.UI.WebControls.Button unselector, System.Web.UI.WebControls.TextBox counter, System.Web.UI.WebControls.Button selector)
        {
            this.unselector = unselector;
            this.counter = counter;
            this.selector = selector;
            this.viewer = viewer;
        }
        public SelectorPair() { }
    }
}