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

        private void OKButton_Click(object sender, EventArgs e)
        {

            if (UserInput.Text.Length == 0)
            {
                string message = "You did not enter anything into the text box.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                string message = UserInput.Text;
                string caption = "Entered Text";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            UserInput.Clear();
        }
    }
}
