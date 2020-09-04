// Fig. 15.7: MenuTestForm.cs
// Using Menus to change font colors and styles.
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Problem_2
{
   // our Form contains a Menu that changes the font color
   // and style of the text displayed in Label
   public partial class P2 : Form
   {
      // constructor
      public P2()
      {
         InitializeComponent();
      } // end constructor

      // display MessageBox when About ToolStripMenuItem is selected
      private void aboutToolStripMenuItem_Click(
         object sender, EventArgs e )
      {
         MessageBox.Show( "This is an example\nof using menus.", "About",
            MessageBoxButtons.OK, MessageBoxIcon.Information );
      } // end method aboutToolStripMenuItem_Click

      // exit program when Exit ToolStripMenuItem is selected
      private void exitToolStripMenuItem_Click( 
         object sender, EventArgs e )
      {
         Application.Exit();
      } // end method exitToolStripMenuItem_Click

      // reset checkmarks for Color ToolStripMenuItems
      private void ClearColor()
      {
         // clear all checkmarks
         blackToolStripMenuItem.Checked = false;
         blueToolStripMenuItem.Checked = false;
         redToolStripMenuItem.Checked = false;
         greenToolStripMenuItem.Checked = false;
      } // end method ClearColor

      // reset checkmarks for Font ToolStripMenuItems
      private void ClearFont()
      {
         // clear all checkmarks
         timesToolStripMenuItem.Checked = false;
         courierToolStripMenuItem.Checked = false;
         comicToolStripMenuItem.Checked = false;
      } // end method ClearFont

      // update Menu state and set Font to Times New Roman
      private void timesToolStripMenuItem_Click(
         object sender, EventArgs e )
      {
         // reset checkmarks for Font ToolStripMenuItems
         ClearFont();

         // set Times New Roman font
         timesToolStripMenuItem.Checked = true;
         displayLabel.Font = new Font( "Times New Roman", 14,
            displayLabel.Font.Style );
      } // end method timesToolStripMenuItem_Click

      // update Menu state and set Font to Courier
      private void courierToolStripMenuItem_Click(
         object sender, EventArgs e )
      {
         // reset checkmarks for Font ToolStripMenuItems
         ClearFont();

         // set Courier font
         courierToolStripMenuItem.Checked = true;
         displayLabel.Font = new Font( "Courier", 14,
            displayLabel.Font.Style );
      } // end method courierToolStripMenuItem_Click

      // update Menu state and set Font to Comic Sans MS
      private void comicToolStripMenuItem_Click(
         object sender, EventArgs e )
      {
         // reset checkmarks for Font ToolStripMenuItems
         ClearFont();

         // set Comic Sans font
         comicToolStripMenuItem.Checked = true;
         displayLabel.Font = new Font( "Comic Sans MS", 14,
            displayLabel.Font.Style );
      } // end method comicToolStripMenuItem_Click

      // toggle checkmark and toggle bold style
      private void boldToolStripMenuItem_Click( 
         object sender, EventArgs e )
      {
         // toggle checkmark
         boldToolStripMenuItem.Checked = !boldToolStripMenuItem.Checked;

         // use Xor to toggle bold, keep all other styles
         displayLabel.Font = new Font( displayLabel.Font,
            displayLabel.Font.Style ^ FontStyle.Bold );
      } // end method boldToolStripMenuItem_Click

      // toggle checkmark and toggle italic style
      private void italicToolStripMenuItem_Click(
         object sender, EventArgs e )
      {
         // toggle checkmark
         italicToolStripMenuItem.Checked = 
            !italicToolStripMenuItem.Checked;

         // use Xor to toggle italic, keep all other styles
         displayLabel.Font = new Font( displayLabel.Font,
            displayLabel.Font.Style ^ FontStyle.Italic );
      } // end method italicToolStripMenuItem_Click

        private void arielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Font ToolStripMenuItems
            ClearFont();

            arielToolStripMenuItem.Checked = true;
            displayLabel.Font = new Font("Ariel", 14,
               displayLabel.Font.Style);
        }

        private void calibriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Font ToolStripMenuItems
            ClearFont();

            calibriToolStripMenuItem.Checked = true;
            displayLabel.Font = new Font("Calibri", 14,
               displayLabel.Font.Style);
        }

        private void cambriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Font ToolStripMenuItems
            ClearFont();

            cambriaToolStripMenuItem.Checked = true;
            displayLabel.Font = new Font("Cambria", 14,
               displayLabel.Font.Style);
        }

        private void constantiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Font ToolStripMenuItems
            ClearFont();

            constantiaToolStripMenuItem.Checked = true;
            displayLabel.Font = new Font("Constantia", 14,
               displayLabel.Font.Style);
        }

        private void courierNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Font ToolStripMenuItems
            ClearFont();

            courierNewToolStripMenuItem.Checked = true;
            displayLabel.Font = new Font("Courier New", 14,
               displayLabel.Font.Style);
        }

        private void segoeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Font ToolStripMenuItems
            ClearFont();

            segoeToolStripMenuItem.Checked = true;
            displayLabel.Font = new Font("Segoe UI", 14,
               displayLabel.Font.Style);
        }

        private void webdingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Font ToolStripMenuItems
            ClearFont();

            webdingsToolStripMenuItem.Checked = true;
            displayLabel.Font = new Font("Webdings", 14,
               displayLabel.Font.Style);
        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Black
            displayLabel.ForeColor = Color.Black;
            textToolStripMenuItem1.Checked = true;
        }

        private void backgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Black
            displayLabel.BackColor = Color.Black;
            backgroundToolStripMenuItem1.Checked = true;
        }
        private void textToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Blue
            displayLabel.ForeColor = Color.Blue;
            textToolStripMenuItem2.Checked = true;
        }

        private void backgroundToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Blue
            displayLabel.BackColor = Color.Blue;
            backgroundToolStripMenuItem2.Checked = true;
        }
        private void textToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Red
            displayLabel.ForeColor = Color.Red;
            textToolStripMenuItem3.Checked = true;
        }

        private void backgroundToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Red
            displayLabel.BackColor = Color.Red;
            backgroundToolStripMenuItem3.Checked = true;
        }
        private void textToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Green
            displayLabel.ForeColor = Color.Green;
            textToolStripMenuItem3.Checked = true;
        }

        private void backgroundToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Green
            displayLabel.BackColor = Color.Green;
            backgroundToolStripMenuItem4.Checked = true;
        }
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Yellow
            displayLabel.ForeColor = Color.Yellow;
            textToolStripMenuItem.Checked = true;
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Yellow
            displayLabel.BackColor = Color.Yellow;
            backgroundToolStripMenuItem.Checked = true;
        }
        private void textToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Purple
            displayLabel.ForeColor = Color.Purple;
            textToolStripMenuItem5.Checked = true;
        }

        private void backgroundToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Purple
            displayLabel.BackColor = Color.Purple;
            backgroundToolStripMenuItem5.Checked = true;
        }
        private void textToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Pink
            displayLabel.ForeColor = Color.Pink;
            textToolStripMenuItem6.Checked = true;
        }

        private void backgroundToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Pink
            displayLabel.BackColor = Color.Pink;
            backgroundToolStripMenuItem6.Checked = true;
        }
        private void textToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Aqua
            displayLabel.ForeColor = Color.Aqua;
            textToolStripMenuItem7.Checked = true;
        }

        private void backgroundToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            // reset checkmarks for Color ToolStripMenuItems
            ClearColor();

            // set color to Aqua
            displayLabel.BackColor = Color.Aqua;
            backgroundToolStripMenuItem7.Checked = true;
        }
    } // end class MenuTestForm
} // end namespace MenuTest