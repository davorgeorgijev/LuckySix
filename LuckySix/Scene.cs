using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySix
{
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        public List<int> Coefficients { get; set; }
        public GeneratingBall GeneratingBall { get; set; }
        public Scene() 
        { 
            GeneratingBall = new GeneratingBall();
            Balls = new List<Ball>();
            Coefficients = new List<int>() { 0, 0, 0, 0, 0, 10000, 7500, 5000, 2500, 1000, 500, 300, 200, 150, 100, 50, 40, 30, 25, 20, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int x = 475;
            int y = 40;
            for(int i = 1; i <= 35; i++)
            {
                if (i <= 5) //upper five 
                {
                    Balls.Add(new Ball(new Point(x, y), Coefficients[i - 1], "nothing"));
                    x += 60;
                    if (i == 5) 
                    {
                        x = 50;
                        y = 80;
                    }
                }
                else if (i > 5 && i <= 15)  //left ten
                {
                    Balls.Add(new Ball(new Point(x, y), Coefficients[i - 1], "left"));
                    y += 60;
                    if (i == 15) 
                    {
                        x = 260;
                        y = 380;
                    }
                }
                else if (i > 15 && i <= 20) //left five
                {
                    Balls.Add(new Ball(new Point(x, y), Coefficients[i - 1], "left"));
                    y += 60;
                    if (i == 20) 
                    {
                        x = 920;
                        y = 380;
                    }
                }
                else if (i > 20 && i <= 25) //right five
                {
                    Balls.Add(new Ball(new Point(x, y), Coefficients[i - 1], "right"));
                    y += 60;
                    if (i == 25) 
                    {
                        x = 1130;
                        y = 80;
                    }
                }
                else if (i > 25 && i <= 35) //right ten
                {
                    Balls.Add(new Ball(new Point(x, y), Coefficients[i - 1], "right"));
                    y += 60;
                }
            }
        }

        public void Draw(Graphics g)
        {
            GeneratingBall.Draw(g);
            foreach(Ball b in Balls)
            {
                b.Draw(g);
            }
        }
    }
}
