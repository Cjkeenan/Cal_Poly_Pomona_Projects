using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_5
{
    public partial class P5 : Form
    {
        System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
        ColorDialog cd = new ColorDialog();
        System.Drawing.Graphics myGraphics;
        public P5()
        {
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            myGraphics = CreateGraphics();
            myGraphics.Clear(Color.White);
            myGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            double theta = 0.0;
            double pi = 4.0 * Math.Atan(1.0);

            int ry = (int)(100 + 40 * Math.Sin(theta)), rx = (int)(100 + 40 * Math.Cos(theta));
            int diameter = 80;
            int iterations = Convert.ToInt32(numberOfCirclesSizeUpDown.Value);
            for (int i = 0; i < iterations; i++)
            {
                myGraphics.DrawEllipse(myPen, rx, ry, diameter, diameter);
                theta += pi / 180 * (360.0 / iterations);
                rx = (int)(100 + 40 * Math.Sin(theta));
                ry = (int)(100 + 40 * Math.Cos(theta));
            }

        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            myGraphics = CreateGraphics();
            myGraphics.Clear(Color.White);
            if (cd.ShowDialog() == DialogResult.OK)
            {
                myPen.Color = cd.Color;
                colorButton.BackColor = cd.Color;   //color for background
                colorButton.ForeColor = Color.FromArgb(cd.Color.ToArgb() ^ 0xffffff);   //inverse for text
            }
        }
    }
}
