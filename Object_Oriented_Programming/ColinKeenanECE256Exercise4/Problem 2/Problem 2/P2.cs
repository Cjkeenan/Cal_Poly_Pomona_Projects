using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_2
{
    public partial class P2 : Form
    {
        public P2()
        {
            InitializeComponent();
        }

        private int getDiameter()
        {
            int height = this.Height;
            int width = this.Width;

            // Make the drawable area proportional
            if (width < height)
            {
                height = width;
            }
            else
            {
                width = height;
            }

            return width / 2;
        }
        private void yinYangButton_Click(object sender, EventArgs e)
        {
            // create graphics object, Pen and SolidBrush
            Graphics myGraphics = base.CreateGraphics();

            // create SolidBrush using color Black
            SolidBrush SolidBlackBrush = new SolidBrush(Color.Black);

            // create SolidBrush using color White
            SolidBrush SolidWhiteBrush = new SolidBrush(Color.White);

            myGraphics.Clear(Color.AntiqueWhite);

            int diameter = getDiameter();
            int radius = diameter / 2;

            // Outer left circle
            myGraphics.FillPie(SolidBlackBrush, 0, 0, diameter, diameter, 0, 180);

            // Outer right circle        
            myGraphics.FillPie(SolidWhiteBrush, 0, 0, diameter, diameter, 0, -180);

            // Inner lower circle (white) - left side
            myGraphics.FillPie(SolidWhiteBrush, 0, diameter / 4, radius, radius, 0, 180);

            // Inner upper circle (black) - right side
            myGraphics.FillPie(SolidBlackBrush, radius, diameter / 4, radius, radius, 0, -180);

            // Inner left circle (black on white)
            myGraphics.FillPie(SolidBlackBrush, diameter / 4 - radius / 8, diameter / 2 - radius / 8, radius / 4, radius / 4, 0, 360);

            // Inner right circle (white on black)
            myGraphics.FillPie(SolidWhiteBrush, diameter / 2 + (radius / 8) * 3, diameter / 2 - radius / 8, radius / 4, radius / 4, 0, 360);
        }
    }
}
