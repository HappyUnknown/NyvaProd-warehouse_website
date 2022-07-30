using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Threading;

namespace NyvaProdBC
{
    public partial class About : Page
    {
        public static DispatcherTimer t;
        public static int ImgIteraror { get; set; }
        public static List<Entity.Good> Goods;
        protected void Page_Load(object sender, EventArgs e)
        {
            t = new DispatcherTimer();
            t.Tick += T_Tick;
            t.Interval = new TimeSpan(0, 0, 1);
            t.Start();
            if (!Page.IsPostBack)
            {
                Goods = GlobalValues.goods;
                ImgIteraror = 0;
                imgCarousel.ImageUrl = Goods[ImgIteraror].ImageUrl;
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            btnNextMedia_Click(sender, e);
        }

        protected void btnPrevMedia_Click(object sender, EventArgs e)
        {
            ImgIteraror--;
            if (ImgIteraror < 0) ImgIteraror = Goods.Count - 1;
            imgCarousel.ImageUrl = Goods[ImgIteraror].ImageUrl;
        }

        protected void btnNextMedia_Click(object sender, EventArgs e)
        {
            ImgIteraror++;
            if (ImgIteraror > Goods.Count - 1) ImgIteraror = 0;
            imgCarousel.ImageUrl = Goods[ImgIteraror].ImageUrl;
        }

    }
}