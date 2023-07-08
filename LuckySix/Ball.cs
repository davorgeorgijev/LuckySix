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
        public Color Color { get; set; } 
        public int Number { get; set; } 
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
            //drawing coefficients

            Font font = new Font(new FontFamily("Arial"), 16, FontStyle.Bold, GraphicsUnit.Pixel);
            Brush brushTextBig = new SolidBrush(Color.White);

            if (LeftOrRight == "left")
            {
                g.DrawString(Coefficient.ToString(), font, brushTextBig, Center.X + 35, Center.Y - 10);
            } 
            else if(LeftOrRight == "right")
            {
                g.DrawString(Coefficient.ToString(), font, brushTextBig, Center.X - 65, Center.Y - 9);
            }
            brushTextBig.Dispose();


            if (!IsSelected) //empty space for ball
            {
                Brush brush = new SolidBrush(Color.LightGray);
                Pen pen = new Pen(Color.White, 2);

                g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
                g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);

                brush.Dispose();
                pen.Dispose();
            }
            else //already generated ball
            {
                Brush brushBig = new SolidBrush(Color);
                Brush brushSmall = new SolidBrush(Color.White);
                Brush brushTextSmall = new SolidBrush(Color.Black);
                Pen pen = new Pen(Color.White, 3);

                Font fontSmall = new Font(new FontFamily("Arial"), 10, FontStyle.Bold, GraphicsUnit.Pixel);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
                g.FillEllipse(brushBig, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
                g.FillEllipse(brushSmall, Center.X - 10, Center.Y - 10, 10 * 2, 10 * 2);
                g.DrawString(Number.ToString(), fontSmall, brushTextSmall, Center.X + 1, Center.Y, stringFormat);

                brushSmall.Dispose();
                brushBig.Dispose();
                brushTextSmall.Dispose();
                pen.Dispose();
            }
        }
    }
}
