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
            this.OKButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.UserInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OKButton.Location = new System.Drawing.Point(0, 113);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(212, 19);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ClearButton.Location = new System.Drawing.Point(0, 94);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(212, 19);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // UserInput
            // 
            this.UserInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UserInput.Location = new System.Drawing.Point(9, 10);
            this.UserInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserInput.Multiline = true;
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(194, 71);
            this.UserInput.TabIndex = 2;
            // 
            // P2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 132);
            this.Controls.Add(this.UserInput);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.OKButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "P2";
            this.Text = "Problem 2 ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox UserInput;
    }
}

