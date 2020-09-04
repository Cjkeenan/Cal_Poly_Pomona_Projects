namespace Problem_1
{
    partial class Form1
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
            this.color1Button = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontButton = new System.Windows.Forms.Button();
            this.sizeButton = new System.Windows.Forms.Button();
            this.italisizeButton = new System.Windows.Forms.Button();
            this.underlineButton = new System.Windows.Forms.Button();
            this.color2Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // color1Button
            // 
            this.color1Button.Location = new System.Drawing.Point(12, 12);
            this.color1Button.Name = "color1Button";
            this.color1Button.Size = new System.Drawing.Size(80, 34);
            this.color1Button.TabIndex = 0;
            this.color1Button.Text = "Color 1";
            this.color1Button.UseVisualStyleBackColor = true;
            this.color1Button.Click += new System.EventHandler(this.color1Button_Click);
            // 
            // testButton
            // 
            this.testButton.AutoSize = true;
            this.testButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.testButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.testButton.Location = new System.Drawing.Point(0, 226);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(282, 27);
            this.testButton.TabIndex = 1;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(98, 12);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(80, 34);
            this.fontButton.TabIndex = 2;
            this.fontButton.Text = "Font";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // sizeButton
            // 
            this.sizeButton.Location = new System.Drawing.Point(184, 12);
            this.sizeButton.Name = "sizeButton";
            this.sizeButton.Size = new System.Drawing.Size(80, 34);
            this.sizeButton.TabIndex = 3;
            this.sizeButton.Text = "Size";
            this.sizeButton.UseVisualStyleBackColor = true;
            this.sizeButton.Click += new System.EventHandler(this.sizeButton_Click);
            // 
            // italisizeButton
            // 
            this.italisizeButton.Location = new System.Drawing.Point(184, 52);
            this.italisizeButton.Name = "italisizeButton";
            this.italisizeButton.Size = new System.Drawing.Size(80, 34);
            this.italisizeButton.TabIndex = 6;
            this.italisizeButton.Text = "Italics";
            this.italisizeButton.UseVisualStyleBackColor = true;
            this.italisizeButton.Click += new System.EventHandler(this.italisizeButton_Click);
            // 
            // underlineButton
            // 
            this.underlineButton.Location = new System.Drawing.Point(98, 52);
            this.underlineButton.Name = "underlineButton";
            this.underlineButton.Size = new System.Drawing.Size(80, 34);
            this.underlineButton.TabIndex = 5;
            this.underlineButton.Text = "Underline";
            this.underlineButton.UseVisualStyleBackColor = true;
            this.underlineButton.Click += new System.EventHandler(this.underlineButton_Click);
            // 
            // color2Button
            // 
            this.color2Button.Location = new System.Drawing.Point(12, 52);
            this.color2Button.Name = "color2Button";
            this.color2Button.Size = new System.Drawing.Size(80, 34);
            this.color2Button.TabIndex = 4;
            this.color2Button.Text = "Color 2";
            this.color2Button.UseVisualStyleBackColor = true;
            this.color2Button.Click += new System.EventHandler(this.color2Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.italisizeButton);
            this.Controls.Add(this.underlineButton);
            this.Controls.Add(this.color2Button);
            this.Controls.Add(this.sizeButton);
            this.Controls.Add(this.fontButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.color1Button);
            this.Name = "Form1";
            this.Text = "Problem 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button color1Button;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.Button sizeButton;
        private System.Windows.Forms.Button italisizeButton;
        private System.Windows.Forms.Button underlineButton;
        private System.Windows.Forms.Button color2Button;
    }
}

