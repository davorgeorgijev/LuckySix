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
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
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
                    MessageBox.Show("You have to enter only numbers!", "Error", MessageBoxButtons.OK);
                }
                else if (Numbers.Any(num => num < 0))
                {
                    MessageBox.Show("You have to enter only positive numbers!", "Error", MessageBoxButtons.OK);
                }
                else if (Numbers.Contains(0))
                {
                    MessageBox.Show("You have to enter numbers different than 0!", "Error", MessageBoxButtons.OK);
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
                    MessageBox.Show("You have to enter color!", "", MessageBoxButtons.OK);
                }
                else
                {
                    if (comboBoxColor.Text == "Red") Color = Color.Red;
                    else if (comboBoxColor.Text == "Green") Color = Color.Green;
                    else if (comboBoxColor.Text == "Blue") Color = Color.Blue;
                    else if (comboBoxColor.Text == "Pink") Color = Color.Pink;
                    else if (comboBoxColor.Text == "Purple") Color = Color.Purple;
                    else if (comboBoxColor.Text == "Yellow") Color = Color.Yellow;
                    else if (comboBoxColor.Text == "Orange") Color = Color.Orange;
                    else if (comboBoxColor.Text == "Black") Color = Color.Black;
                    DialogResult = DialogResult.OK;
                }
            }
            Bet = (int)betNud.Value;
        }

    }
}
