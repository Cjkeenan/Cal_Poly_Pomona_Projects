namespace Problem_2
{
    partial class P2
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
            this.filePathTextbox = new System.Windows.Forms.TextBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.partATab = new System.Windows.Forms.TabPage();
            this.partAListBox = new System.Windows.Forms.ListBox();
            this.partBTab = new System.Windows.Forms.TabPage();
            this.partBListBox = new System.Windows.Forms.ListBox();
            this.partCTab = new System.Windows.Forms.TabPage();
            this.partCListBox = new System.Windows.Forms.ListBox();
            this.partDTab = new System.Windows.Forms.TabPage();
            this.partDListBox = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.partATab.SuspendLayout();
            this.partBTab.SuspendLayout();
            this.partCTab.SuspendLayout();
            this.partDTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePathTextbox
            // 
            this.filePathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextbox.Location = new System.Drawing.Point(11, 11);
            this.filePathTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.filePathTextbox.Name = "filePathTextbox";
            this.filePathTextbox.Size = new System.Drawing.Size(329, 20);
            this.filePathTextbox.TabIndex = 0;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFileButton.Location = new System.Drawing.Point(344, 8);
            this.selectFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(79, 24);
            this.selectFileButton.TabIndex = 2;
            this.selectFileButton.Text = "Select File:";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(169, 35);
            this.searchButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(79, 25);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.partATab);
            this.tabControl1.Controls.Add(this.partBTab);
            this.tabControl1.Controls.Add(this.partCTab);
            this.tabControl1.Controls.Add(this.partDTab);
            this.tabControl1.Location = new System.Drawing.Point(9, 81);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 128);
            this.tabControl1.TabIndex = 6;
            // 
            // partATab
            // 
            this.partATab.Controls.Add(this.partAListBox);
            this.partATab.Location = new System.Drawing.Point(4, 22);
            this.partATab.Margin = new System.Windows.Forms.Padding(2);
            this.partATab.Name = "partATab";
            this.partATab.Padding = new System.Windows.Forms.Padding(2);
            this.partATab.Size = new System.Drawing.Size(405, 102);
            this.partATab.TabIndex = 0;
            this.partATab.Text = "Indistinct Words";
            this.partATab.UseVisualStyleBackColor = true;
            // 
            // partAListBox
            // 
            this.partAListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partAListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.partAListBox.FormattingEnabled = true;
            this.partAListBox.HorizontalScrollbar = true;
            this.partAListBox.Location = new System.Drawing.Point(0, 0);
            this.partAListBox.Margin = new System.Windows.Forms.Padding(2);
            this.partAListBox.Name = "partAListBox";
            this.partAListBox.Size = new System.Drawing.Size(407, 104);
            this.partAListBox.TabIndex = 0;
            // 
            // partBTab
            // 
            this.partBTab.Controls.Add(this.partBListBox);
            this.partBTab.Location = new System.Drawing.Point(4, 22);
            this.partBTab.Margin = new System.Windows.Forms.Padding(2);
            this.partBTab.Name = "partBTab";
            this.partBTab.Padding = new System.Windows.Forms.Padding(2);
            this.partBTab.Size = new System.Drawing.Size(405, 102);
            this.partBTab.TabIndex = 1;
            this.partBTab.Text = "Distinct Words";
            this.partBTab.UseVisualStyleBackColor = true;
            // 
            // partBListBox
            // 
            this.partBListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partBListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.partBListBox.FormattingEnabled = true;
            this.partBListBox.HorizontalScrollbar = true;
            this.partBListBox.Location = new System.Drawing.Point(0, 0);
            this.partBListBox.Margin = new System.Windows.Forms.Padding(2);
            this.partBListBox.Name = "partBListBox";
            this.partBListBox.Size = new System.Drawing.Size(407, 104);
            this.partBListBox.TabIndex = 1;
            // 
            // partCTab
            // 
            this.partCTab.Controls.Add(this.partCListBox);
            this.partCTab.Location = new System.Drawing.Point(4, 22);
            this.partCTab.Margin = new System.Windows.Forms.Padding(2);
            this.partCTab.Name = "partCTab";
            this.partCTab.Padding = new System.Windows.Forms.Padding(2);
            this.partCTab.Size = new System.Drawing.Size(405, 102);
            this.partCTab.TabIndex = 2;
            this.partCTab.Text = "Word Frequency";
            this.partCTab.UseVisualStyleBackColor = true;
            // 
            // partCListBox
            // 
            this.partCListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partCListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.partCListBox.FormattingEnabled = true;
            this.partCListBox.HorizontalScrollbar = true;
            this.partCListBox.Location = new System.Drawing.Point(0, 0);
            this.partCListBox.Margin = new System.Windows.Forms.Padding(2);
            this.partCListBox.Name = "partCListBox";
            this.partCListBox.Size = new System.Drawing.Size(407, 104);
            this.partCListBox.TabIndex = 1;
            // 
            // partDTab
            // 
            this.partDTab.Controls.Add(this.partDListBox);
            this.partDTab.Location = new System.Drawing.Point(4, 22);
            this.partDTab.Name = "partDTab";
            this.partDTab.Size = new System.Drawing.Size(405, 102);
            this.partDTab.TabIndex = 3;
            this.partDTab.Text = "Word Length";
            this.partDTab.UseVisualStyleBackColor = true;
            // 
            // partDListBox
            // 
            this.partDListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partDListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.partDListBox.FormattingEnabled = true;
            this.partDListBox.HorizontalScrollbar = true;
            this.partDListBox.Location = new System.Drawing.Point(-1, -1);
            this.partDListBox.Margin = new System.Windows.Forms.Padding(2);
            this.partDListBox.Name = "partDListBox";
            this.partDListBox.Size = new System.Drawing.Size(407, 104);
            this.partDListBox.TabIndex = 1;
            // 
            // P2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 219);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.filePathTextbox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "P2";
            this.Text = "Problem 2";
            this.tabControl1.ResumeLayout(false);
            this.partATab.ResumeLayout(false);
            this.partBTab.ResumeLayout(false);
            this.partCTab.ResumeLayout(false);
            this.partDTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextbox;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage partATab;
        private System.Windows.Forms.ListBox partAListBox;
        private System.Windows.Forms.TabPage partBTab;
        private System.Windows.Forms.TabPage partCTab;
        private System.Windows.Forms.ListBox partBListBox;
        private System.Windows.Forms.ListBox partCListBox;
        private System.Windows.Forms.TabPage partDTab;
        private System.Windows.Forms.ListBox partDListBox;
    }
}

