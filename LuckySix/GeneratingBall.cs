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
        public Color Color { get; set; } = Color.LightGray; 
        public int Number { get; set; } 

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.White, 2);    
            Brush brushBig = new SolidBrush(Color);
            Brush brushSmall = new SolidBrush(Color.White);
            Brush brushText = new SolidBrush(Color.Black);

            Font font = new Font(new FontFamily("Arial"), 40, FontStyle.Bold, GraphicsUnit.Point);
            
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            g.FillEllipse(brushBig, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);

            if (Number == 0)
            {
                g.DrawString("STARTING\nGAME", font, brushText, Center.X, Center.Y + 10, stringFormat);
            }
            else
            {
                g.FillEllipse(brushSmall, Center.X - 80, Center.Y - 80, 80 * 2, 80 * 2);
                g.DrawString(Number.ToString(), font, brushText, Center.X, Center.Y + 5, stringFormat);
            }

            pen.Dispose();
            brushBig.Dispose();
            brushSmall.Dispose();
            brushText.Dispose();
        }
    }
}
