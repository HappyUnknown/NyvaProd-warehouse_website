namespace NyvaProdBC
{
    public partial class SiteMaster
    {
        struct GoodInBasket
        {
            public string GoodName { get; set; }
            public int Count { get; set; }
            public GoodInBasket(string goodName, int count)
            {
                GoodName = goodName;
                Count = count;
            }
        }
    }
}