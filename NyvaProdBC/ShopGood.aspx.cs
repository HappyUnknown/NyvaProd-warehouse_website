using NyvaProdBC.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class ShopGood : System.Web.UI.Page
    {
        static string[] ImageUrls { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pnlGoodPage.Visible = true;
                ImageUrls = new string[]
                {
                //"https://files.yande.re/sample/43baf1155996358570eabd7ebb16ef91/yande.re%20993730%20sample%20ass%20feet%20genshin_impact%20keqing%20nanaken_nana%20pantyhose%20topless.jpg",
                //"https://files.yande.re/sample/169068cff01138edb6e6b07733ccc4c5/yande.re%201009147%20sample%20dress%20natsuki_marina%20no_bra%20see_through%20summer_dress.jpg",
                //"https://files.yande.re/sample/a91d4fab75e9e18ba252e58b46158077/yande.re%201009132%20sample%20genshin_impact%20maid%20no_bra%20noelle_%28genshin_impact%29%20rosumerii%20thighhighs.jpg",
                //"https://files.yande.re/sample/5a75fcda416f2a739a99b1f77b0b30a7/yande.re%201009158%20sample%20hatsune_miku%20headphones%20magical_mirai%20tagme%20vocaloid%20wallpaper.jpg",
                //"https://files.yande.re/sample/7e14e02c305eec776e2e80449772aefa/yande.re%201009118%20sample%20kenzo_093%20landscape%20seifuku%20umbrella%20wet.jpg",
                //"https://files.yande.re/sample/178c54e551c4ebd39e37499c886cf59c/yande.re%201009046%20sample%20puracotte%20wet%20yukata.jpg",
                //"https://files.yande.re/sample/ab9760d3d9692d137e843dc7cb81eddd/yande.re%201008986%20sample%20hiten%20minase_akiha%20sankaku_no_kyori_wa_kagiri_nai_zero%20seifuku.jpg",
                //"https://files.yande.re/sample/84fe1cfac228fcd2a54a9a2362b5e04a/yande.re%201008981%20sample%20hiten%20minase_akiha%20sankaku_no_kyori_wa_kagiri_nai_zero%20seifuku.jpg",
                //"https://files.yande.re/sample/beb6b6e54eb690a4cc0ed34ef4d0549e/yande.re%201008916%20sample%20bikini%20breast_hold%20emori_miku%20emori_miku_project%20emu_alice%20swimsuits%20yoruhoshi_owl.jpg",
                //"https://files.yande.re/sample/6eee2169b2495508b1b987b778c51e36/yande.re%201008984%20sample%20hiten%20minase_haruka%20sankaku_no_kyori_wa_kagiri_nai_zero%20seifuku.jpg",
                //"https://files.yande.re/sample/338634df5b15102e42af951cbfb66dd2/yande.re%20981106%20sample%20animal_ears%20breast_hold%20bunny_ears%20bunny_girl%20cameltoe%20heels%20no_bra%20pantyhose%20shu-ri%20tenka_hyakken.jpg",
                //"https://files.yande.re/sample/7d1bdfb948df2732da67daf2a0bb6c13/yande.re%201008789%20sample%20areola%20genshin_impact%20greatodoggo%20mona_megistus%20no_bra%20witch.jpg",
                //"https://files.yande.re/sample/bb0a6dcf2a6189b1aeaf12a3e2806fd6/yande.re%201003882%20sample%20landscape%20seifuku%20y_y.jpg",
                //"https://files.yande.re/sample/55714d41d733c7f8fc18403ab29faffe/yande.re%201003955%20sample%20arknights%20bukui_shi_wo%20garter%20landscape%20monster%20no_bra%20skadi_%28arknights%29.jpg",
                //"https://files.yande.re/sample/319b9fe93794cfe1af22fa0acae0e458/yande.re%20997500%20sample%20amatsuki_rei%20landscape%20pantyhose%20skirt_lift.jpg",
                //"https://files.yande.re/sample/c945ce328fb245da9f4d53d611489ccc/yande.re%20977276%20sample%20landscape%20nakomo%20seifuku.jpg",
                //"https://files.yande.re/sample/90be89bf1be30cf1eea4dce87250a401/yande.re%20980079%20sample%20banishment%20landscape.jpg",
                //"https://files.yande.re/sample/367c31a48c83fe718d4bcb6d065f0331/yande.re%20959799%20sample%20landscape%20seifuku%20teardrops_%28user_vgvd7733%29.jpg",
                //"https://files.yande.re/sample/87f00f82c2290e4cb707c3493f3cb987/yande.re%20953013%20sample%20dress%20kijineko%20landscape.jpg",
                //"https://files.yande.re/sample/ff525516482b4186dbfe8284b827c388/yande.re%20942806%20sample%20landscape%20pantyhose%20seifuku%20tagme%20umbrella%20widea7.jpg"
                "https://i.pinimg.com/564x/da/35/df/da35dfdccd5f4b31eeb27e214db7c58a.jpg",
                "https://i.pinimg.com/564x/a5/66/51/a56651ec1726be9b5ddafd3c9f3c8943.jpg",
                "https://i.pinimg.com/564x/44/43/8b/44438b63db0a0ad3343379745e1db0d5.jpg",
                "https://i.pinimg.com/564x/6c/36/dd/6c36dda535064b620130862b1721474c.jpg",
                "https://i.pinimg.com/564x/8c/30/41/8c30419d4d4d9588d0232580936d1052.jpg",
                "https://i.pinimg.com/564x/5c/8f/e5/5c8fe56d92d0b60c00de049cd2abc666.jpg",
                "https://i.pinimg.com/564x/f7/a8/ff/f7a8ff021e9f09d0637ecddf00057ca9.jpg",
                "https://i.pinimg.com/564x/f6/4b/02/f64b02cd451c9f9f9d92bb2f05b9d2f5.jpg",
                "https://i.pinimg.com/564x/3e/18/e7/3e18e7c667189a777f1493a1ae830698.jpg",
                "https://i.pinimg.com/564x/f4/c6/cb/f4c6cb5d992bc3e7c07e4806ac9f9961.jpg",
                "https://i.pinimg.com/564x/e3/7e/c6/e37ec6022b424ef5aa992ea9206071e8.jpg",
                "https://i.pinimg.com/564x/d8/4b/04/d84b04bd2bdea53dda0fb9c182fbf6b5.jpg",
                "https://i.pinimg.com/564x/a2/ac/7e/a2ac7e5e9288f262d9fc2b97c0026b05.jpg",
                "https://i.pinimg.com/564x/42/b0/65/42b0652de7585a9b38227ac031fe5af0.jpg",
                "https://i.pinimg.com/564x/cd/74/78/cd747895ac32e3c03c1a0bb1ac3b0c00.jpg",
                "https://i.pinimg.com/564x/54/f1/1d/54f11d02aad722703fec72642608fc5c.jpg",
                "https://i.pinimg.com/564x/d2/2d/5d/d22d5db508204dace620d8757bf3f0a2.jpg",
                "https://i.pinimg.com/564x/1c/c9/ef/1cc9ef6e1231781841bc73fc925e5b3f.jpg",
                "https://i.pinimg.com/564x/62/53/73/625373b51336be048058e661d36921ad.jpg",
                "https://i.pinimg.com/564x/c8/12/89/c8128924bdaa16945cadc0f1d009327b.jpg",
                "https://i.pinimg.com/564x/47/10/5b/47105ba47579eb37783ef65dbbc71c68.jpg",
                "https://i.pinimg.com/564x/94/0b/e8/940be894a0b0772ea0443acbb61075fc.jpg",
                "https://i.pinimg.com/564x/ac/53/cb/ac53cbf1633eb8349ee65ed54c9b855f.jpg",
                "https://i.pinimg.com/564x/0b/1a/e1/0b1ae1969bf5a2947d22dfc2321b1354.jpg",
                };
                //lblGoodName.Text = LoremIpsum.Generate(2, 4, 1, 1, 1);
                //string firstParagraph = LoremIpsum.Generate(1, 7, 1, 5, 1);
                //lblGoodDescription.Text = firstParagraph.Substring(0, 1).ToUpper() + firstParagraph.Substring(1);
                //System.Threading.Thread.Sleep(1);
                //string secondParagraph = LoremIpsum.Generate(1, 7, 1, 5, 1);
                //lblGoodDescription.Text += secondParagraph.Substring(0, 1).ToUpper() + secondParagraph.Substring(1);
                var currentUser = (Entity.NyvaUser)Application["user_data"];
                if (currentUser != null)
                {
                    string idStr = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(idStr))
                    {
                        pnlGoodPage.Visible = true;
                        int goodID = int.Parse(idStr);
                        var db = new Entity.Contexts.GoodContext();
                        var goods = db.Goods.ToList();
                        var theGood = goods.Where(x => x.Id == goodID).FirstOrDefault();
                        if (theGood != default)
                        {
                            lblGoodName.Text = theGood.Name;
                            lblGoodDescription.Text = theGood.Description;
                        }
                        imgGoodPreview.Height = 900;
                        imgGoodPreview.ImageUrl = theGood.ImagesUrl;//ImageUrls[new Random().Next(0, ImageUrls.Length - 1)];
                        lblMsg.Text = "Огляд товару";
                        lblPrice.Text = $"{theGood.GetFullPrice()}₴";
                    }
                    else
                    {
                        pnlGoodPage.Visible = false;
                        lblMsg.Text = "Як ви потрапили на цю сторінку? Поверніться до списку товарів, та спробуйте ще раз.";
                    }
                }
                else
                {
                    pnlGoodPage.Visible = false;
                    lblMsg.Text = "Огляд товарів доступний лише для зареєстрованих користувачів.";
                }
            }
        }

        protected void btnBackToWare_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Warehouse");
        }
    }
}