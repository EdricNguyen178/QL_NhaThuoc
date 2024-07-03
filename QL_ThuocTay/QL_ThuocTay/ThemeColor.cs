using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuocTay
{
    public class ThemeColor
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }
        public static List<string> ColorList = new List<string>()
        {
            "#4876FF",
            "#436EEE",
            "#3A5FCD",
            "#27408B",
            "#0000FF",
            "#0000EE",
            "#00008B",
            "#000080",
            "#191970",
            "#6495ED",
            "#0000CD",
            "#B0E0E6",
            "#1E90FF",
            "#1C86EE",
            "#1874CD",
            "#104E8B",
            "#4682B4",
            "#63B8FF",
            "#5CACEE",
            "#4F94CD",
            "#36648B",
            "#00BFFF",
            "#00B2EE",
            "#009ACD",
            "#00688B",
            "#87CEEB",
            "#87CEFF",
            "#7EC0EE",
            "#6CA6CD",
            "#4A708B",
            "#87CEFA",
            "#B0E2FF",
            "#A4D3EE",
            "#8DB6CD",


        };
        public static Color ChangeColor(Color color, double correctinFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctinFactor < 0)
            {
                correctinFactor = 1 + correctinFactor;
                red *= correctinFactor;
                green *= correctinFactor;
                blue *= correctinFactor;
            }
            else
            {
                red = (255 - red) * correctinFactor + red;
                green = (255 - green) * correctinFactor + green;
                blue = (255 - blue) * correctinFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
