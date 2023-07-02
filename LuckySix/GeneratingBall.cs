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
        public Color Color { get; set; } //changing
        public int Number { get; set; } //changing

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.White, 2);
            g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            pen.Dispose();

            Brush brushBig = new SolidBrush(Color);
            g.FillEllipse(brushBig, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brushBig.Dispose();

            Brush brushSmall = new SolidBrush(Color.White);
            g.FillEllipse(brushSmall, Center.X - 80, Center.Y - 80, 80 * 2, 80 * 2);
            brushSmall.Dispose();

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 40, FontStyle.Bold, GraphicsUnit.Pixel);
            Brush brushText = new SolidBrush(Color.Black);
            if (Number <= 9) 
            {
                g.DrawString(Number.ToString(), font, brushText, Center.X - 18, Center.Y - 20);
            }
            else
            {
                g.DrawString(Number.ToString(), font, brushText, Center.X - 27, Center.Y - 20);
            }
        }
    }
}
