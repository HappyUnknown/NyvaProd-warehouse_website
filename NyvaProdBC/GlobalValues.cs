using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC
{
    public class GlobalValues
    {
        public static readonly System.Drawing.Color selectColor = System.Drawing.Color.CornflowerBlue;
        public static readonly System.Drawing.Color idleColor = System.Drawing.Color.LightGray;
        public const string HOST_EMAIL = "nyvaprod@gmail.com";
        public const string HOST_PASSWORD = "sgbrnvmkeunkteoj";
        public const string BRIDGE_ADDR = "smtp.gmail.com";
        public const int BRIDGE_PORT = 587;
        public static readonly List<Entity.Good> goods = new List<Entity.Good>()
        {
            new Entity.Good(5,"Salt", "Salty",1,2,3,4,5,6,"https://i.pinimg.com/564x/2d/b7/d8/2db7d8c53b818ce838ad8bf6a4768c71.jpg"),
            new Entity.Good(99,"Sugar", "Sweet",2,3,4,5,6,7,"https://i.pinimg.com/564x/59/1b/23/591b232ca14c99ad3b4bbf98b0b340f5.jpg"),
            new Entity.Good(41,"Pepper", "Hot",3,4,5,6,7,8,"https://i.pinimg.com/564x/c1/74/2d/c1742d01ea1d5d501c9d9736bbfe9504.jpg"),
            new Entity.Good(16,"Lemonpowder", "Sour",4,5,6,7,8,9,"https://i.pinimg.com/564x/76/f1/dc/76f1dcf48d7aa03f0baa46a4f283b023.jpg"),
            new Entity.Good(16,"Chili", "Overkill",5,6,7,8,9,0,"https://i.pinimg.com/564x/32/a5/fe/32a5fec188101ec9499f9106d61636f4.jpg")
        };
    }
}