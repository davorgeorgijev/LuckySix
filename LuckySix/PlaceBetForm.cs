﻿using System;
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
        public PlaceBetForm()
        {
            InitializeComponent();
        }

        private void PlaceBetForm_Load(object sender, EventArgs e)
        {

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
                Numbers.Add(Int32.Parse(comboBox1.Text.ToString()));
                Numbers.Add(Int32.Parse(comboBox2.Text.ToString()));
                Numbers.Add(Int32.Parse(comboBox3.Text.ToString()));
                Numbers.Add(Int32.Parse(comboBox4.Text.ToString()));
                Numbers.Add(Int32.Parse(comboBox5.Text.ToString()));
                Numbers.Add(Int32.Parse(comboBox6.Text.ToString()));
                if (Numbers.Contains(0) || Numbers.Distinct().Count() != 6)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else if (playColorsRb.Checked)
            {
                if(comboBoxColor.Text == "None")
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    if (comboBoxColor.Text == "Red") Color = Color.Red;
                    else if (comboBoxColor.Text == "Green") Color = Color.Green;
                    else if (comboBoxColor.Text == "Blue") Color = Color.Blue;
                    else if (comboBoxColor.Text == "Pink") Color = Color.Pink;
                    else if (comboBoxColor.Text == "Brown") Color = Color.Brown;
                    else if (comboBoxColor.Text == "Yellow") Color = Color.Yellow;
                    else if (comboBoxColor.Text == "Orange") Color = Color.Orange;
                    else if (comboBoxColor.Text == "Black") Color = Color.Black;
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}