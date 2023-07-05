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
        public Color Color { get; set; } = Color.LightGray; //changing
        public int Number { get; set; } //changing

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.White, 2);    
            Brush brushBig = new SolidBrush(Color);
            Brush brushSmall = new SolidBrush(Color.White);

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 40, FontStyle.Bold, GraphicsUnit.Point);
            Brush brushText = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            g.FillEllipse(brushBig, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);

            if (Number == 0)
            {
                g.DrawString("STARTING\nGAME", font, brushText, Center.X, Center.Y, stringFormat);
            }
            else
            {
                g.FillEllipse(brushSmall, Center.X - 80, Center.Y - 80, 80 * 2, 80 * 2);
                if (Number <= 9)
                {
                    g.DrawString(Number.ToString(), font, brushText, Center.X, Center.Y, stringFormat);
                }
                else
                {
                    g.DrawString(Number.ToString(), font, brushText, Center.X, Center.Y, stringFormat);
                }
            }

            pen.Dispose();
            brushBig.Dispose();
            brushSmall.Dispose();
            brushText.Dispose();
        }
    }
}
