// Fig. 15.23: ComboBoxTestForm.cs
// Using ComboBox to select a shape to draw.
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Problem_3
{
   // Form uses a ComboBox to select different shapes to draw
   public partial class P3 : Form
   {
        Color SelectedFillColor = Color.WhiteSmoke;
        Color SelectedLineColor = Color.Black;
        // constructor
        public P3()
      {
         InitializeComponent();
      } // end constructor
        private void ClearColor()
        {
            // clear all checkmarks
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
        } // end method ClearColor
          // get index of selected shape, draw shape
        private void imageComboBox_SelectedIndexChanged(
         object sender, EventArgs e )
      {
         // create graphics object, Pen and SolidBrush
         Graphics myGraphics = base.CreateGraphics();

         // create Pen using color DarkRed
         Pen myPen = new Pen( SelectedLineColor );

         // create SolidBrush using color DarkRed
         SolidBrush mySolidBrush = new SolidBrush( SelectedFillColor);

         // clear drawing area setting it to color white
         myGraphics.Clear( Color.White );

         // find index, draw proper shape
         switch ( imageComboBox.SelectedIndex )
         {
            case 0: // case Circle is selected
                myGraphics.DrawEllipse( myPen, 50, 75, 150, 150 );
                break;
            case 1: // case Square is selected
                myGraphics.DrawRectangle( myPen, 50, 75, 150, 150 );
                break;
            case 2: // case Triangle is selected
                Point[] tPoints = { new Point(50, 75), new Point(150, 75), new Point(100, 175) };
                myGraphics.DrawPolygon( myPen, tPoints);
                break;
            case 3: // case Pentagon is selected
                Point[] pPoints = { new Point(115, 65), new Point(44, 117), new Point(71, 201),
                                    new Point(159, 201), new Point(186, 117)};
                myGraphics.DrawPolygon(myPen, pPoints);
                break;
            case 4: // case Ellipse is selected
                myGraphics.DrawEllipse( myPen, 50, 75, 150, 115 );
                break;
            case 5: // case Pie is selected
                 myGraphics.DrawPie( myPen, 50, 75, 150, 150, 0, 45 );
                break;
            case 6: // case Filled Circle is selected
                 myGraphics.FillEllipse( mySolidBrush, 50, 75, 150, 150 );
                 break;
            case 7: // case Filled Square is selected
                myGraphics.FillRectangle( mySolidBrush, 50, 75, 150, 150 );
                break;
            case 8: // case Filled Triangle is selected
                Point[] tfPoints = { new Point(50, 75), new Point(150, 75), new Point(100, 175) };
                myGraphics.FillPolygon( mySolidBrush, tfPoints);
                break;
            case 9: // case Filled Pentagon is selected
                Point[] pfPoints = { new Point(115, 65), new Point(44, 117), new Point(71, 201),
                                     new Point(159, 201), new Point(186, 117)};
                myGraphics.FillPolygon(mySolidBrush, pfPoints);
                break;
            case 10: // case Filled Ellipse is selected
                myGraphics.FillEllipse( mySolidBrush, 50, 75, 150, 115 );
                break;
            case 11: // case Filled Pie is selected
                myGraphics.FillPie( mySolidBrush, 50, 75, 150, 150, 0, 
                  45 );
                break;
         } // end switch

         myGraphics.Dispose(); // release the Graphics object
      } // end method imageComboBox_SelectedIndexChanged

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Black
            SelectedLineColor = Color.Black;
            lineToolStripMenuItem.Checked = true;
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Black
            SelectedFillColor = Color.Black;
            lineToolStripMenuItem.Checked = true;
        }

        private void lineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Blue
            SelectedLineColor = Color.Blue;
            lineToolStripMenuItem1.Checked = true;
        }

        private void fillToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Blue
            SelectedFillColor = Color.Blue;
            fillToolStripMenuItem1.Checked = true;
        }

        private void lineToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Red
            SelectedLineColor = Color.Red;
            lineToolStripMenuItem2.Checked = true;
        }

        private void fillToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Red
            SelectedFillColor = Color.Red;
            fillToolStripMenuItem2.Checked = true;
        }

        private void lineToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Green
            SelectedLineColor = Color.Green;
            lineToolStripMenuItem3.Checked = true;
        }

        private void fillToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Black
            SelectedFillColor = Color.Green;
            fillToolStripMenuItem3.Checked = true;
        }
    } // end class ComboBoxTestForm
} // end namespace ComboBoxTest
