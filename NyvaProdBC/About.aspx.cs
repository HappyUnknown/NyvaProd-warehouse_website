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
        public static int ImgIteraror { get; set; }
        public static List<Entity.Good> Goods;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Goods = GlobalValues.goods;
                ImgIteraror = 0;
                tblCarouselUI.BackImageUrl = Goods[ImgIteraror].ImagesUrl;
                tmrSwitchCarousel.Interval = GlobalValues.TIMER_MILLIS_INTERVAL;
                RefreshInfoUI();
            }
        }

        protected void btnPrevMedia_Click(object sender, EventArgs e)
        {
            ImgIteraror--;
            if (ImgIteraror < 0) ImgIteraror = Goods.Count - 1;
            tblCarouselUI.BackImageUrl = Goods[ImgIteraror].ImagesUrl;
            RefreshInfoUI();
        }

        protected void btnNextMedia_Click(object sender, EventArgs e)
        {
            ImgIteraror++;
            if (ImgIteraror > Goods.Count - 1) ImgIteraror = 0;
            tblCarouselUI.BackImageUrl = Goods[ImgIteraror].ImagesUrl;
            RefreshInfoUI();
        }
        void RefreshInfoUI()
        {
            lblUpTitle.Text = Goods[ImgIteraror].Name;
            lblDownTitle.Text = Goods[ImgIteraror].Description.ToString();
        }

        protected void tmrSwitchCarousel_Tick(object sender, EventArgs e)
        {
            btnNextMedia_Click(sender, e);
        }
    }
}