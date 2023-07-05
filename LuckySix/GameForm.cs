using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuckySix
{
    public partial class GameForm : Form
    {
        public Scene Scene { get; set; }
        public List<int> PlayedNumbers { get; set; }
        public Color PlayedColor { get; set; }
        public Random Random { get; set; }
        public List<int> AlreadyGeneratedNumbers { get; set; }
        public int CounterTicksForShuffling { get; set; }
        public int CounterGeneratedBalls { get; set; }
        public int CounterHits { get; set; }
        public int CashWon { get; set; }
        public int Bet { get; set; }
        public bool ColorOrNumberPlayingAtm { get; set; } //true-numbers false-colors
        public GameForm()
        {
            PlaceBetForm placeBetForm = new PlaceBetForm();
            if(placeBetForm.ShowDialog() == DialogResult.OK)
            {
                InitializeComponent();

                DoubleBuffered = true;
                Scene = new Scene();

                PlayedNumbers = placeBetForm.Numbers;
                PlayedColor = placeBetForm.Color;
                Bet = placeBetForm.Bet;
                ColorOrNumberPlayingAtm = placeBetForm.ColorOrNumberPlayingAtm;
                Random = new Random();
                AlreadyGeneratedNumbers = new List<int>();

                timerGeneratingBall.Start();
            }
            else
            {
                Environment.Exit(0);
            }             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Scene.Draw(e.Graphics);
        }

        private void timerGeneratingBall_Tick(object sender, EventArgs e)
        { 
            if(CounterGeneratedBalls == 35)
            {
                timerGeneratingBall.Stop();
                Invalidate();
                string message;
                if(CashWon > 0)
                {
                    message = $"You won {CashWon} denars!\nDo you want to play again?";
                }
                else
                {
                    message = $"You did not won any money.\nDo you want to play again?";
                }
                DialogResult dialogResult = MessageBox.Show(message, "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    Application.Restart();
                }
                else
                {
                    Environment.Exit(0);
                }
                return;
            }
            timerSufflingBalls.Start();
            Invalidate();
        }

        private void timerSufflingBalls_Tick(object sender, EventArgs e)
        {
            CounterTicksForShuffling++;
            int number;
            while (true)
            {
                number = Random.Next(1, 49);
                if (!AlreadyGeneratedNumbers.Contains(number))
                {
                    break;
                }
            }
            Scene.GeneratingBall.Number = number;
            Scene.GeneratingBall.Color = GenerateColor(number);

            if (CounterTicksForShuffling >= 15)
            {
                CounterTicksForShuffling = 0;
                timerSufflingBalls.Stop();
                AlreadyGeneratedNumbers.Add(number);
                Scene.Balls[CounterGeneratedBalls].Number = number;
                Scene.Balls[CounterGeneratedBalls].Color = GenerateColor(number);
                Scene.Balls[CounterGeneratedBalls].IsSelected = true;
                if (ColorOrNumberPlayingAtm) //numbers
                {
                    if (PlayedNumbers.Contains(number))
                    {
                        CounterHits++;
                        if (CounterHits == 6)
                        {
                            CashWon = Bet * Scene.Balls[CounterGeneratedBalls].Coefficient;
                        }
                    }
                }
                else
                {
                    if(PlayedColor == GenerateColor(number))
                    {
                        CounterHits++;
                        if (CounterHits == 6)
                        {
                            CashWon = Bet * Scene.Balls[CounterGeneratedBalls].Coefficient;
                        }
                    }
                }
                CounterGeneratedBalls++;
            }

            Invalidate();
        }

        private Color GenerateColor(int number)
        {
            if (number % 8 == 1) return Color.Red;
            else if (number % 8 == 2) return Color.Green;
            else if (number % 8 == 3) return Color.Blue;
            else if (number % 8 == 4) return Color.Pink;
            else if (number % 8 == 5) return Color.Purple;
            else if (number % 8 == 6) return Color.Yellow;
            else if (number % 8 == 7) return Color.Orange;
            else return Color.Black; //if (number % 8 == 0)
        }
    }
}
