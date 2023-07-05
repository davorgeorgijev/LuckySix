using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySix
{
    public class Ball
    {
        public Point Center { get; set; }
        public static int Radius { get; set; } = 25;
        public Color Color { get; set; } //set in form
        public int Number { get; set; } //set in form
        public int Coefficient { get; set; }
        public bool IsSelected { get; set; }
        public string LeftOrRight { get; set; } //the ball is positioned left or right on the screen

        public Ball(Point center, int coefficient, string leftOrRight)
        {
            Color = Color.Gray;
            IsSelected = false;
            Center = center;
            Coefficient = coefficient;
            LeftOrRight = leftOrRight;
        }

        public void Draw(Graphics g)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 16, FontStyle.Bold, GraphicsUnit.Pixel);
            Brush brushText = new SolidBrush(Color.White);

            if (LeftOrRight == "left")
            {
                g.DrawString(Coefficient.ToString(), font, brushText, Center.X + 35, Center.Y-10);
            } 
            else if(LeftOrRight == "right")
            {
                if (Coefficient != 10)
                {
                    g.DrawString(Coefficient.ToString(), font, brushText, Center.X - 55, Center.Y - 9);
                }
                else
                {
                    g.DrawString(Coefficient.ToString(), font, brushText, Center.X - 65, Center.Y - 9);
                }
            }
            brushText.Dispose();

            Brush brush = new SolidBrush(Color.LightGray);
            Pen pen = new Pen(Color.White, 2);

            if (!IsSelected)
            {
                
                g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
                g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            }
            else
            {
                Brush brushBig = new SolidBrush(Color);
                Brush brushSmall = new SolidBrush(Color.White);

                FontFamily fontFamilySmall = new FontFamily("Arial");
                Font fontSmall = new Font(fontFamilySmall, 10, FontStyle.Bold, GraphicsUnit.Pixel);
                Brush brushTextSmall = new SolidBrush(Color.Black);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
                g.FillEllipse(brushBig, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
                g.FillEllipse(brushSmall, Center.X - 10, Center.Y - 10, 10 * 2, 10 * 2);
                
                if(Number <= 9)
                {
                    g.DrawString(Number.ToString(), fontSmall, brushTextSmall, Center.X, Center.Y, stringFormat);
                }
                else
                {
                    g.DrawString(Number.ToString(), fontSmall, brushTextSmall, Center.X, Center.Y, stringFormat);
                }

                brushSmall.Dispose();
                brushTextSmall.Dispose();
                brushBig.Dispose();
            }
            brush.Dispose();
            pen.Dispose();
        }
    }
}
