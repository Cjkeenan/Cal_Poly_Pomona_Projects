using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem_2
{
    public partial class P2 : Form
    {
        public P2()
        {
            InitializeComponent();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePathTextbox.Text = ofd.FileName;
            }
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            try
            {
                string source = File.ReadAllText(@filePathTextbox.Text.ToString());
                string TERM = searchTermTextbox.Text.ToString();

                string partAPattern = "\\b\\w*(" + TERM + ")\\w*\\b";
                int counter = 0;
                MatchCollection matchWord = Regex.Matches(source, partAPattern);
                partAListBox.Items.Clear();
                foreach (Match m in matchWord)
                {
                    counter++;
                }
                partAListBox.Items.Add(String.Format("\"{0}\" appears {1} times in the selected file.", TERM, counter));

                string partBPattern = "\\b\\w*(" + TERM + ")\\w*\\b";
                MatchCollection matchLetter = Regex.Matches(source, partBPattern);
                partBListBox.Items.Clear();
                foreach (Match m in matchLetter)
                {
                    partBListBox.Items.Add(m.ToString());
                }

                string partCPattern = "[^\\.?!\n]*(" + TERM + ")[^\\.?!\n]*";
                MatchCollection matchSentence = Regex.Matches(source, partCPattern);
                partCListBox.Items.Clear();
                foreach (Match m in matchSentence)
                {
                    partCListBox.Items.Add(String.Format("Word: \"{0},\" Sentence: {1}", TERM, m.ToString()));
                }
            }
            catch (IOException)
            {
            }
        }
    }
}
