using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_7
{
    public partial class P7 : Form
    {
        System.Drawing.Pen TLPen = new System.Drawing.Pen(System.Drawing.Color.Black);
        System.Drawing.Pen TRPen = new System.Drawing.Pen(System.Drawing.Color.Red);
        System.Drawing.Pen BLPen = new System.Drawing.Pen(System.Drawing.Color.Green);
        System.Drawing.Pen BRPen = new System.Drawing.Pen(System.Drawing.Color.Blue);
        ColorDialog cd = new ColorDialog();
        System.Drawing.Graphics myGraphics;
        public P7()
        {
            InitializeComponent();
        }

        private void TLButton_Click(object sender, EventArgs e)
        {
            myGraphics = CreateGraphics();
            myGraphics.Clear(Color.White);
            if (cd.ShowDialog() == DialogResult.OK)
            {
                TLPen.Color = cd.Color;
                TLButton.BackColor = cd.Color;
                TLButton.ForeColor = Color.FromArgb(cd.Color.ToArgb() ^ 0xffffff);
            }
        }

        private void TRButton_Click(object sender, EventArgs e)
        {
            myGraphics = CreateGraphics();
            myGraphics.Clear(Color.White);
            if (cd.ShowDialog() == DialogResult.OK)
            {
                TRPen.Color = cd.Color;
                TRButton.BackColor = cd.Color;
                TRButton.ForeColor = Color.FromArgb(cd.Color.ToArgb() ^ 0xffffff);
            }
        }

        private void BLButton_Click(object sender, EventArgs e)
        {
            myGraphics = CreateGraphics();
            myGraphics.Clear(Color.White);
            if (cd.ShowDialog() == DialogResult.OK)
            {
                BLPen.Color = cd.Color;
                BLButton.BackColor = cd.Color;
                BLButton.ForeColor = Color.FromArgb(cd.Color.ToArgb() ^ 0xffffff);
            }
        }

        private void BRButton_Click(object sender, EventArgs e)
        {
            myGraphics = CreateGraphics();
            myGraphics.Clear(Color.White);
            if (cd.ShowDialog() == DialogResult.OK)
            {
                BRPen.Color = cd.Color;
                BRButton.BackColor = cd.Color;
                BRButton.ForeColor = Color.FromArgb(cd.Color.ToArgb() ^ 0xffffff);
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            myGraphics = CreateGraphics();
            myGraphics.Clear(Color.White);
            myGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = this.ClientRectangle;
            int cx = rect.Width;
            int cy = rect.Height;
            float scale = (float)cy / (float)cx;
            for (int x = 0; x < cx; x += Convert.ToInt32(sizeUpDown.Value))
            {
                myGraphics.DrawLine(TLPen, 0, x * scale, cx - x, 0);
                myGraphics.DrawLine(TRPen, cx - x, 0 * scale, cx, (cx - x) * scale);
                myGraphics.DrawLine(BLPen, 0, (cx - x) * scale, cx - x, cx * scale);
                myGraphics.DrawLine(BRPen, cx - x, cx * scale, cx, x * scale);
            }
        }
    }
}
