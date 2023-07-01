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
    public partial class Form1 : Form
    {
        public Scene Scene { get; set; }
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Scene = new Scene();
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
