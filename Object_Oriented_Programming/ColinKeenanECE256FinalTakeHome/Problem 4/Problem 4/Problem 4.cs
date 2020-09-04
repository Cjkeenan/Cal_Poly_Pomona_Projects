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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        int x1 = 62;
        int y1 = 262;
        int h1 = 25;
        int w1 = 25;

        Pen gridPen = new Pen(Color.Black, 5);
        Pen pondPen = new Pen(Color.Blue, 5);
        Pen ballPen = new Pen(Color.Red, 5);

        SolidBrush ballBrush = new SolidBrush(Color.Red);
        SolidBrush pondBrush = new SolidBrush(Color.Blue);
        SolidBrush trailBrush = new SolidBrush(Color.Green);

        private Random rnd = new Random();

        public void start_Click(object sender, EventArgs e)
        {
            Graphics myGraphics1 = base.CreateGraphics();
            myGraphics1.Clear(Color.White);

            int n = 5;

            //set initial values of x and y coordinates
            int X1 = 50;
            int X2 = 50;
            int Y1 = 50;

            for (int i = 0; i < n; i++)
            {
                //draw rectangle at x1 coordinate
                myGraphics1.DrawRectangle(gridPen, X1, 50, 50, 50);
                X1 += 50;
                for (int j = 0; j < n; j++)
                {
                    myGraphics1.DrawRectangle(gridPen, X2, Y1, 50, 50);
                    Y1 += 50;
                }
                X2 += 50;

                //this resets the y value for the second for loop rectangle
                Y1 = Y1 - (n * 50);
            }

            //add a text label for start
            Label start = new Label();
            start.Text = "Start";
            start.Location = new Point(10, 275);
            start.Size = new Size(30, 15);
            start.BackColor = Color.White;
            this.Controls.Add(start);
            start.BringToFront();

            //adds a text label for end
            Label end = new Label();
            end.Text = "End";
            end.Location = new Point(310, 75);
            end.Size = new Size(30, 15);
            end.BackColor = Color.White;
            this.Controls.Add(end);
            end.BringToFront();

            Label pond = new Label();
            pond.Text = "Pond";
            pond.Location = new Point(160, 170);
            pond.Size = new Size(40, 15);
            pond.BackColor = pondBrush.Color;
            this.Controls.Add(pond);
            pond.BringToFront();

            //adds text box for 
            TextBox lol = new TextBox();
            lol.Text = "Click here then Press the Arror Keys";
            lol.Location = new Point(100, 13);
            lol.Size = new Size(180, 17);
            //adds a click event to to the textbox
            lol.Click += new System.EventHandler(buttonClear_Text);
            //adds a key up event to the textbox
            lol.KeyUp += new KeyEventHandler(lol_KeyUp);
            this.Controls.Add(lol);
            lol.BringToFront();

            //draws and fills the POND
            myGraphics1.DrawEllipse(pondPen, 100, 100, 150, 150);
            myGraphics1.FillEllipse(pondBrush, 100, 100, 150, 150);

            //adds the circle to the start box
            myGraphics1.DrawEllipse(ballPen, 62, 262, 25, 25);
            myGraphics1.FillEllipse(ballBrush, 62, 262, 25, 25);


            void lol_KeyUp(object senderr, KeyEventArgs p)
            {
                //erases the "square" that the circle WAS in
                myGraphics1.FillRectangle(trailBrush, x1 - 5, y1 - 5, w1 + 15, h1 + 15);
                //this is used to see which side the ball was on before it enters the pond
                int x2 = x1;
                int y2 = y1;
                
                //Looks at that key value to see where the ball will move
                if (p.KeyValue == 37)
                {
                    x1 -= 50;
                    lol.Text = "Left was pressed";
                }
                else if (p.KeyValue == 38)
                {
                    y1 -= 50;
                    lol.Text = "Up was pressed";
                }
                else if (p.KeyValue == 39)
                {
                    x1 += 50;
                    lol.Text = "Right was pressed";
                }
                else if (p.KeyValue == 40)
                {
                    y1 += 50;
                    lol.Text = "Down was pressed";

                }
                
                //keeps the ball in to the grid
                if (x1 < 50)
                {
                    MessageBox.Show(String.Format("{0} balls like playing games, please remain on grid.", ballPen.Color), "Ball out of grid");
                    x1 += 50;
                }
                else if(x1 > 300)
                {
                    MessageBox.Show(String.Format("{0} balls like playing games, please remain on grid.", ballPen.Color), "Ball out of grid");
                    x1 -= 50;
                }
                else if (y1 < 50)
                {
                    MessageBox.Show(String.Format("{0} balls like playing games, please remain on grid.", ballPen.Color), "Ball out of grid");
                    y1 += 50;
                }
                else if (y1 > 300)
                {
                    MessageBox.Show(String.Format("{0} balls like playing games, please remain on grid.", ballPen.Color), "Ball out of grid");
                    y1 -= 50;
                }

                //left side of pond
                if (x1 > 100 && y1 > 100 && y1 < 250 && x2 < 100)
                {
                    MessageBox.Show(String.Format("{0} balls do not like swimming.", ballPen.Color), "Ball out of pond"); x1 -= 50;
                }
                //right side of pond
                if(x1 < 250 && y1 > 100 && y1 < 250  && x2 > 250)
                {
                    MessageBox.Show(String.Format("{0} balls do not like swimming.", ballPen.Color), "Ball out of pond"); x1 += 50;
                }

                //top of pond
                if (x1 > 100 && y1 > 100 && x1 < 250 && y2 < 100)
                {
                    MessageBox.Show(String.Format("{0} balls do not like swimming.", ballPen.Color), "Ball out of pond");
                    y1 -= 50;
                }

                //bottom of pond
                if (x1 > 100 && y1 < 250 && x1 < 250 && y2 > 250)
                {
                    MessageBox.Show(String.Format("{0} balls do not like swimming.", ballPen.Color), "Ball out of pond");
                    y1 += 50;
                }

                //draws the elipse after it has checked the exceptions
                myGraphics1.DrawEllipse(ballPen, x1, y1, w1, h1);
                myGraphics1.FillEllipse(ballBrush, x1, y1, w1, h1);

                //Gives a congratulations to the end box.
                if(x1 > 250 && y1 < 100)
                {
                    MessageBox.Show("Game Complete!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Exits the code after the okay is pressed
                    System.Environment.Exit(1);
                }
            }

            void buttonClear_Text(object senderrr, EventArgs p)
            {
                lol.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                fillRandomColors();
            }
            else
            {
                resetColors();
            }
        }

        private void fillRandomColors()
        {
            Color randomBallColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            ballPen.Color = randomBallColor;
            ballBrush.Color = randomBallColor;

            Color randomGridColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            gridPen.Color = randomGridColor;

            Color randomTrailColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            trailBrush.Color = randomTrailColor;

            Color randomPondColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            pondPen.Color = randomPondColor;
            pondBrush.Color = randomPondColor;
        }

        private void resetColors()
        {
            gridPen = new Pen(Color.Black, 5);
            pondPen = new Pen(Color.Blue, 5);
            ballPen = new Pen(Color.Red, 5);

            ballBrush = new SolidBrush(Color.Red);
            pondBrush = new SolidBrush(Color.Blue);
            trailBrush = new SolidBrush(Color.Green);
        }
    }
}
