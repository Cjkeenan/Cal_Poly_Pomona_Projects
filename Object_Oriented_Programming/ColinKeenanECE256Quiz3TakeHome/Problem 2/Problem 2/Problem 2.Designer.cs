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
            this.label1 = new System.Windows.Forms.Label();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.searchTermTextbox = new System.Windows.Forms.TextBox();
            this.okayButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.partATab = new System.Windows.Forms.TabPage();
            this.partAListBox = new System.Windows.Forms.ListBox();
            this.partBTab = new System.Windows.Forms.TabPage();
            this.partBListBox = new System.Windows.Forms.ListBox();
            this.partCTab = new System.Windows.Forms.TabPage();
            this.partCListBox = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.partATab.SuspendLayout();
            this.partBTab.SuspendLayout();
            this.partCTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePathTextbox
            // 
            this.filePathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextbox.Location = new System.Drawing.Point(15, 13);
            this.filePathTextbox.Name = "filePathTextbox";
            this.filePathTextbox.Size = new System.Drawing.Size(437, 22);
            this.filePathTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Search Term:";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFileButton.Location = new System.Drawing.Point(458, 10);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(105, 30);
            this.selectFileButton.TabIndex = 2;
            this.selectFileButton.Text = "Select File:";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // searchTermTextbox
            // 
            this.searchTermTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTermTextbox.Location = new System.Drawing.Point(15, 72);
            this.searchTermTextbox.Name = "searchTermTextbox";
            this.searchTermTextbox.Size = new System.Drawing.Size(437, 22);
            this.searchTermTextbox.TabIndex = 4;
            // 
            // okayButton
            // 
            this.okayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okayButton.Location = new System.Drawing.Point(458, 68);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(105, 31);
            this.okayButton.TabIndex = 5;
            this.okayButton.Text = "OK";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.partATab);
            this.tabControl1.Controls.Add(this.partBTab);
            this.tabControl1.Controls.Add(this.partCTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 157);
            this.tabControl1.TabIndex = 6;
            // 
            // partATab
            // 
            this.partATab.Controls.Add(this.partAListBox);
            this.partATab.Location = new System.Drawing.Point(4, 25);
            this.partATab.Name = "partATab";
            this.partATab.Padding = new System.Windows.Forms.Padding(3);
            this.partATab.Size = new System.Drawing.Size(543, 128);
            this.partATab.TabIndex = 0;
            this.partATab.Text = "Part A";
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
            this.partAListBox.ItemHeight = 16;
            this.partAListBox.Location = new System.Drawing.Point(0, 0);
            this.partAListBox.Name = "partAListBox";
            this.partAListBox.Size = new System.Drawing.Size(543, 128);
            this.partAListBox.TabIndex = 0;
            // 
            // partBTab
            // 
            this.partBTab.Controls.Add(this.partBListBox);
            this.partBTab.Location = new System.Drawing.Point(4, 25);
            this.partBTab.Name = "partBTab";
            this.partBTab.Padding = new System.Windows.Forms.Padding(3);
            this.partBTab.Size = new System.Drawing.Size(543, 128);
            this.partBTab.TabIndex = 1;
            this.partBTab.Text = "Part B";
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
            this.partBListBox.ItemHeight = 16;
            this.partBListBox.Location = new System.Drawing.Point(0, 0);
            this.partBListBox.Name = "partBListBox";
            this.partBListBox.Size = new System.Drawing.Size(543, 128);
            this.partBListBox.TabIndex = 1;
            // 
            // partCTab
            // 
            this.partCTab.Controls.Add(this.partCListBox);
            this.partCTab.Location = new System.Drawing.Point(4, 25);
            this.partCTab.Name = "partCTab";
            this.partCTab.Padding = new System.Windows.Forms.Padding(3);
            this.partCTab.Size = new System.Drawing.Size(543, 128);
            this.partCTab.TabIndex = 2;
            this.partCTab.Text = "Part C";
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
            this.partCListBox.ItemHeight = 16;
            this.partCListBox.Location = new System.Drawing.Point(0, 0);
            this.partCListBox.Name = "partCListBox";
            this.partCListBox.Size = new System.Drawing.Size(543, 128);
            this.partCListBox.TabIndex = 1;
            // 
            // P2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 269);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.searchTermTextbox);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePathTextbox);
            this.Name = "P2";
            this.Text = "Problem 2";
            this.tabControl1.ResumeLayout(false);
            this.partATab.ResumeLayout(false);
            this.partBTab.ResumeLayout(false);
            this.partCTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.TextBox searchTermTextbox;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage partATab;
        private System.Windows.Forms.ListBox partAListBox;
        private System.Windows.Forms.TabPage partBTab;
        private System.Windows.Forms.TabPage partCTab;
        private System.Windows.Forms.ListBox partBListBox;
        private System.Windows.Forms.ListBox partCListBox;
    }
}

