using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySix
{
    public class GeneratingBall
    {
        public static Point Center { get; set; } = new Point(590, 350);
        public static int Radius { get; set; } = 200;
        public Color Color { get; set; } = Color.Pink;
        public int Number { get; set; } 
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.White, 2);
            g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            pen.Dispose();

            Brush brushBig = new SolidBrush(Color);
            g.FillEllipse(brushBig, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brushBig.Dispose();

            Brush brushSmall = new SolidBrush(Color.White);
            g.FillEllipse(brushSmall, Center.X - 100, Center.Y - 100, 100 * 2, 100 * 2);
            brushSmall.Dispose();

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 40, FontStyle.Bold, GraphicsUnit.Pixel);
            Brush brushText = new SolidBrush(Color.Black);
            g.DrawString(Number.ToString(), font, brushText, Center.X - 20, Center.Y - 20);
        }
    }
}
