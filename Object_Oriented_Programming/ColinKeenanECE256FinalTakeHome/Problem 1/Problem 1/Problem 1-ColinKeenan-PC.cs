﻿using System;
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string source = File.ReadAllText(@filePathTextbox.Text.ToString());

                string partAPattern = "\\w+";
                int counter = 0;
                MatchCollection indistinctWord = Regex.Matches(source, partAPattern);
                partAListBox.Items.Clear();
                foreach (Match m in indistinctWord)
                {
                    counter++;
                }
                partAListBox.Items.Add(String.Format("There are {0} indistinct words in the file.", counter));

                string partBPattern = "(\\w+\\b)(?!.*\\1\\b)";
                counter = 0;
                MatchCollection distinctWord = Regex.Matches(source, partBPattern);
                partBListBox.Items.Clear();
                foreach (Match m in distinctWord)
                {
                    counter++;
                }
                partBListBox.Items.Add(String.Format("There are {0} distinct words in the file.", counter));

                string partCPattern = partAPattern;
                MatchCollection wordFrequency = Regex.Matches(source, partCPattern);
                var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
                partCListBox.Items.Clear();
                foreach (Match m in wordFrequency)
                {
                    int currentCount = 0;
                    words.TryGetValue(m.Value, out currentCount);

                    currentCount++;
                    words[m.Value] = currentCount;
                }
                string frequentWord = wordFrequency[0].Value;
                int frequency = 0;
                foreach (KeyValuePair<string, int> kvp in words)
                {
                    if(kvp.Value > frequency)
                    {
                        frequentWord = kvp.Key;
                        frequency = kvp.Value;
                    }
                }
                partCListBox.Items.Add(String.Format("Word: \"{0},\" Frequency: {1}", frequentWord, frequency));

                string partDPattern = "(\\w+)\\s";
                MatchCollection wordLength = Regex.Matches(source, partDPattern);
                string currentLargestString = "";
                partDListBox.Items.Clear();
                foreach (Match m in wordLength)
                {
                    if (m.Groups[1].Value.Length > currentLargestString.Length)
                    {
                        currentLargestString = m.Groups[1].Value;
                    }
                }
                partDListBox.Items.Add(String.Format("Word: \"{0},\" Length: {1}", currentLargestString, currentLargestString.Length));
            }
            catch (IOException)
            {
            }
        }
    }
}
