// Fig. 15.36: UsingTabsForm.cs
// Using TabControl to display various font settings.
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Problem_1
{
   // Form uses Tabs and RadioButtons to display various font settings
   public partial class Problem_1 : Form
   {
        // constructor
        public Problem_1()
        {
            InitializeComponent();
        } // end constructor

        // event handler for Black RadioButton
        private void blackRadioButton_CheckedChanged(
            object sender, EventArgs e )
        {
            displayLabel.ForeColor = Color.Black; // change color to black 
        } // end method blackRadioButton_CheckedChanged

        // event handler for Red RadioButton
        private void redRadioButton_CheckedChanged(
            object sender, EventArgs e )
        {
            displayLabel.ForeColor = Color.Red; // change color to red
        } // end method redRadioButton_CheckedChanged

        // event handler for Green RadioButton
        private void greenRadioButton_CheckedChanged(
            object sender, EventArgs e )
        {
            displayLabel.ForeColor = Color.Green; // change color to green
        } // end method greenRadioButton_CheckedChanged
        private void blueRadioButton_CheckedChanged(
        object sender, EventArgs e)
        {
            displayLabel.ForeColor = Color.Blue; // change color to green
        } // end method greenRadioButton_CheckedChanged

        // event handler for 12 point RadioButton
        private void size12RadioButton_CheckedChanged(
            object sender, EventArgs e )
        {
            // change font size to 12
            displayLabel.Font = new Font( displayLabel.Font.Name, 12 );
        } // end method size12RadioButton_CheckedChanged

        // event handler for 16 point RadioButton
        private void size16RadioButton_CheckedChanged(
            object sender, EventArgs e )
        {
            // change font size to 16
            displayLabel.Font = new Font( displayLabel.Font.Name, 16 );
        } // end method size16RadioButton_CheckedChanged

        // event handler for 20 point RadioButton
        private void size20RadioButton_CheckedChanged(
            object sender, EventArgs e )
        {
            // change font size to 20
            displayLabel.Font = new Font( displayLabel.Font.Name, 20 );
        } // end method size20RadioButton_CheckedChanged

        private void size24RadioButton_CheckedChanged(
            object sender, EventArgs e)
        {
            // change font size to 24
            displayLabel.Font = new Font(displayLabel.Font.Name, 24);
        } // end method size24RadioButton_CheckedChanged

        private void size36RadioButton_CheckedChanged(
            object sender, EventArgs e)
        {
            // change font size to 36
            displayLabel.Font = new Font(displayLabel.Font.Name, 36);
        } // end method size36RadioButton_CheckedChanged

        // event handler for  Hello! RadioButton
        private void helloRadioButton_CheckedChanged(
            object sender, EventArgs e )
        {
            displayLabel.Text = "Hello!"; // change text to Hello!
        } // end method helloRadioButton_CheckedChanged

        // event handler for Goodbye! RadioButton
        private void goodbyeRadioButton_CheckedChanged(
            object sender, EventArgs e )
        {
            displayLabel.Text = "Goodbye!"; // change text to Goodbye!
        } // end method goodbyeRadioButton_CheckedChanged

        private void seeYaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.Text = "See Ya!";
        }

        private void thankYouRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.Text = "Thank You!";
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                displayLabel.Font = fontDialog1.Font;
            }
        }

        private void upperCaseButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = displayLabel.Text.ToUpper();
        }

        private void lowerCaseButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = displayLabel.Text.ToLower();
        }

        private void resetCaseButton_Click(object sender, EventArgs e)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            displayLabel.Text = displayLabel.Text.ToLower();
            displayLabel.Text = myTI.ToTitleCase(displayLabel.Text);
        }

        private void countCharactersButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach(char a in displayLabel.Text)
            {
                count++;
            }
            string message = String.Format("\"{0}\" has {1} characters.", displayLabel.Text ,count);
            string caption = "Character Counter";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
        }

        private void customColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                displayLabel.ForeColor = colorDialog1.Color;
            }
        }

        private void applyMessageButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = customMessageTextBox.Text;
        }

        private void reverseWordButton_Click(object sender, EventArgs e)
        {
            string string1 = "";
            for (int i = displayLabel.Text.Length - 1; i >= 0; --i)
            {
                string1 += displayLabel.Text[i];
            }
            displayLabel.Text = string1;
        }
    }
}