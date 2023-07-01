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
                g.DrawString(Coefficient.ToString(), font, brushText, Center.X - 55, Center.Y-9);
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
                //to do
            }
            brush.Dispose();
            pen.Dispose();
        }
    }
}
