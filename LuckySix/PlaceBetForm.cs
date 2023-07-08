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
    public partial class PlaceBetForm : Form
    {
        public List<int> Numbers { get; set; } = new List<int>();
        public Color Color { get; set; }
        public int Bet { get; set; }
        public bool ColorOrNumberPlayingAtm { get; set; } //true-numbers false-colors

        public PlaceBetForm()
        {
            InitializeComponent();
        }

        private void playNumbersRb_CheckedChanged(object sender, EventArgs e)
        {
            if(playNumbersRb.Checked == true)
            {
                foreach(ComboBox comboBox in new[] { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6 })
                {
                    comboBox.Enabled = true;
                }
            }
            else
            {
                foreach (ComboBox comboBox in new[] { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6 })
                {
                    comboBox.Enabled = false;
                }
            }          
        }

        private void playColorsRb_CheckedChanged(object sender, EventArgs e)
        {
            if(playColorsRb.Checked == true)
            {
                comboBoxColor.Enabled = true;
            }
            else
            {
                comboBoxColor.Enabled = false;
            }
        }

        private void startGameBtn_Click(object sender, EventArgs e)
        {
            if (playNumbersRb.Checked)
            {
                Numbers = new List<int>();
                ColorOrNumberPlayingAtm = true;
                bool containsNonPositiveNumberValueFlag = false;
                foreach (ComboBox comboBox in new[] { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6 }) 
                {
                    if (!int.TryParse(comboBox.Text, out _)) 
                    {
                        containsNonPositiveNumberValueFlag = true;
                        break;
                    }
                    Numbers.Add(Int32.Parse(comboBox.Text.ToString()));
                }
                if (containsNonPositiveNumberValueFlag)
                {
                    MessageBox.Show("You have to enter numbers!", "Error", MessageBoxButtons.OK);
                }
                else if (Numbers.Any(num => num > 48) || Numbers.Any(num => num <= 0))
                {
                    MessageBox.Show("You have to enter numbers in the range of 1 to 48!", "Error", MessageBoxButtons.OK);
                }
                else if (Numbers.Distinct().Count() != 6)
                {
                    MessageBox.Show("You have to enter distinct numbers!", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else if (playColorsRb.Checked)
            {
                ColorOrNumberPlayingAtm = false;
                if(comboBoxColor.Text == "")
                {
                    MessageBox.Show("You have to select color!", "", MessageBoxButtons.OK);
                }
                else
                {
                    Color = Color.FromName(comboBoxColor.Text);
                    DialogResult = DialogResult.OK;
                }
            }
            Bet = (int)betNud.Value;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            textBoxHelp.Visible = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            textBoxHelp.Visible = true;
        }
    }
}
