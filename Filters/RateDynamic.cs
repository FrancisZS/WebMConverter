﻿using System;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class RateDynamicForm : Form
    {
        public int speed { get; set; }

        public RateDynamicForm()
        {
            speed = 100;
            InitializeComponent();
        }

        public RateDynamicForm(int pointSpeed) : this()
        {
            speed = pointSpeed;
        }

        private void RateForm_Load(object sender, EventArgs e)
        {
            numericUpDown.Value = 100;
            trackRate.Value = Convert.ToInt32(100);
            trackRate_ValueChanged(sender, e);
            this.Text = string.Format(this.Text, Program.originalFraps);

        }

        private float GetValue()
        {
            float outvalue;
            var value = trackRate.Value;
            var negative = value < 100;

            value -= 100;
            value = Math.Abs(Math.Max(-99, value));
            outvalue = value;

            outvalue = (100 + ((negative ? -1 : 1) * outvalue)) / 100;

            return outvalue;
        }

        private void trackRate_ValueChanged(object sender, EventArgs e)
        {
            var outvalue = GetValue();

            labelPercentIndicator.Text = outvalue.ToString("P");
            speed = trackRate.Value;
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {
            this.Focus();
            Close();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            trackRate.Value = Convert.ToInt32(numericUpDown.Value);
        }
    }

}
