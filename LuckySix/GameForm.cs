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
    }
}
