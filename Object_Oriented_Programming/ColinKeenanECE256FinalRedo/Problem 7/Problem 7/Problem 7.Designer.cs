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
    partial class P7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Pen TLPen;
            System.Drawing.Pen TRPen;
            System.Drawing.Pen BLPen;
            System.Drawing.Pen BRPen;
            TLPen = new System.Drawing.Pen(System.Drawing.Color.Black);
            TRPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            BLPen = new System.Drawing.Pen(System.Drawing.Color.Green);
            BRPen = new System.Drawing.Pen(System.Drawing.Color.Blue);

            System.Drawing.Graphics formGraphics = CreateGraphics();
            //formGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = this.ClientRectangle;
            int cx = rect.Width;
            int cy = rect.Height;
            float scale = (float)cy / (float)cx;
            for (int x = 0; x < cx; x += 7)
            {
                formGraphics.DrawLine(TLPen, 0, x * scale, cx - x, 0);
                formGraphics.DrawLine(TRPen, cx - x, 0 * scale, cx, (cx - x) * scale);
                formGraphics.DrawLine(BLPen, 0, (cx - x) * scale, cx - x, cx * scale);
                formGraphics.DrawLine(BRPen, cx - x, cx * scale, cx, x * scale);
            }
            formGraphics.Dispose();
            TLPen.Dispose();
            TRPen.Dispose();
            BLPen.Dispose();
            BRPen.Dispose();
        }
    }
}

