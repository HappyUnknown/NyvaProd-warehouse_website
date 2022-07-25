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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}