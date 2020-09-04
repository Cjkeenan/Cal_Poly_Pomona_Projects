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
            this.yinYangButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // yinYangButton
            // 
            this.yinYangButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.yinYangButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.yinYangButton.Location = new System.Drawing.Point(0, 210);
            this.yinYangButton.Name = "yinYangButton";
            this.yinYangButton.Size = new System.Drawing.Size(282, 43);
            this.yinYangButton.TabIndex = 0;
            this.yinYangButton.Text = "Generate Yin-Yang";
            this.yinYangButton.UseVisualStyleBackColor = true;
            this.yinYangButton.Click += new System.EventHandler(this.yinYangButton_Click);
            // 
            // P2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.yinYangButton);
            this.Name = "P2";
            this.Text = "Problem 2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button yinYangButton;
    }
}

