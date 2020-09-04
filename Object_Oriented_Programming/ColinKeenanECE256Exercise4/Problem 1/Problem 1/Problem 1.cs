using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void color1Button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                testButton.ForeColor = colorDialog1.Color;
            }
        }

        private void color2Button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                testButton.BackColor = colorDialog1.Color;
            }
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                testButton.Font = fontDialog1.Font;
            }
        }

        private void sizeButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            testButton.Font = new Font (testButton.Font.Name, rand.Next(1, 75));
        }

        private void italisizeButton_Click(object sender, EventArgs e)
        {
            if (testButton.Font.Italic)
            {
                testButton.Font = new Font(testButton.Font, FontStyle.Regular);
            }
            else
            {
                testButton.Font = new Font(testButton.Font, FontStyle.Italic);
            }
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            if (testButton.Font.Underline)
            {
                testButton.Font = new Font(testButton.Font, FontStyle.Regular);
            }
            else
            {
                testButton.Font = new Font(testButton.Font, FontStyle.Underline);
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
                string message = String.Format("Options entered:\n{0}\n{1}\n{2}\nFont Size: {3}\nUnderline: {4}\nItalics: {5}", testButton.Font.FontFamily, testButton.ForeColor,
                                                testButton.BackColor, testButton.Font.Size, testButton.Font.Italic, testButton.Font.Underline);
                string caption = "Test Button Clicked";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
        }
    }
}
