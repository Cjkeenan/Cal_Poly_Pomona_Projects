using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_4
{
    public partial class P4 : Form
    {
        public P4()
        {
            InitializeComponent();
        }
        public void CreateSquare(int[,] magic, int size)
        {
            //Remove previously created controls and free resources
            foreach (Control item in this.Controls)
            {
                this.Controls.Remove(item);
                item.Dispose();
            }
            sizeLabel.Dispose();

            //Create TableLayoutPanel
            var panel = new TableLayoutPanel();
            panel.RowCount = size;
            panel.ColumnCount = size;
            panel.BackColor = Color.Black;

            //Set the equal size for columns and rows
            for (int i = 0; i < size; i++)
            {
                var percent = 100f / (float)size;
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
            }

            //Add buttons, if you have your desired output in an array
            //you can set the text of buttons from your array
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    var button = new Button();
                    button.BackColor = Color.Lime;
                    button.Font = new Font(button.Font.FontFamily, 20, FontStyle.Bold);
                    button.FlatStyle = FlatStyle.Flat;

                    //you can set the text of buttons from your array
                    //For example button.Text = array[i,j].ToString();
                    //old way: button.Text = string.Format("{0}", (i) * size + j + 1);
                    button.Text = magic[i, j].ToString();
                    button.Name = string.Format("{0}Button", button.Text);
                    button.Dock = DockStyle.Fill;
                   
                    panel.Controls.Add(button, j, i);
                }
            }
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(sizeTextBox.Text); 
            int[,] magicSquare = new int[num, num];
            Magic_Square_Odd m1 = new Magic_Square_Odd();
            m1.SolveMagicSquare(magicSquare, num);

            
            CreateSquare(magicSquare, num);
            
        }
    }
}
