using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Problem_7
{
    partial class P7
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
            this.TLButton = new System.Windows.Forms.Button();
            this.TRButton = new System.Windows.Forms.Button();
            this.BLButton = new System.Windows.Forms.Button();
            this.BRButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.sizeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TLButton
            // 
            this.TLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TLButton.Location = new System.Drawing.Point(107, 104);
            this.TLButton.Name = "TLButton";
            this.TLButton.Size = new System.Drawing.Size(31, 23);
            this.TLButton.TabIndex = 0;
            this.TLButton.Text = "TL";
            this.TLButton.UseVisualStyleBackColor = true;
            this.TLButton.Click += new System.EventHandler(this.TLButton_Click);
            // 
            // TRButton
            // 
            this.TRButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TRButton.Location = new System.Drawing.Point(144, 104);
            this.TRButton.Name = "TRButton";
            this.TRButton.Size = new System.Drawing.Size(31, 23);
            this.TRButton.TabIndex = 1;
            this.TRButton.Text = "TR";
            this.TRButton.UseVisualStyleBackColor = true;
            this.TRButton.Click += new System.EventHandler(this.TRButton_Click);
            // 
            // BLButton
            // 
            this.BLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BLButton.Location = new System.Drawing.Point(107, 133);
            this.BLButton.Name = "BLButton";
            this.BLButton.Size = new System.Drawing.Size(31, 23);
            this.BLButton.TabIndex = 2;
            this.BLButton.Text = "BL";
            this.BLButton.UseVisualStyleBackColor = true;
            this.BLButton.Click += new System.EventHandler(this.BLButton_Click);
            // 
            // BRButton
            // 
            this.BRButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BRButton.Location = new System.Drawing.Point(144, 133);
            this.BRButton.Name = "BRButton";
            this.BRButton.Size = new System.Drawing.Size(31, 23);
            this.BRButton.TabIndex = 3;
            this.BRButton.Text = "BR";
            this.BRButton.UseVisualStyleBackColor = true;
            this.BRButton.Click += new System.EventHandler(this.BRButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(107, 162);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(68, 23);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // sizeUpDown
            // 
            this.sizeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeUpDown.Location = new System.Drawing.Point(98, 78);
            this.sizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sizeUpDown.Name = "sizeUpDown";
            this.sizeUpDown.Size = new System.Drawing.Size(89, 20);
            this.sizeUpDown.TabIndex = 7;
            this.sizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // P7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sizeUpDown);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.BRButton);
            this.Controls.Add(this.BLButton);
            this.Controls.Add(this.TRButton);
            this.Controls.Add(this.TLButton);
            this.Name = "P7";
            this.Text = "Problem 8";
            ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private Button TLButton;
        private Button TRButton;
        private Button BLButton;
        private Button BRButton;
        private Button applyButton;
        private NumericUpDown sizeUpDown;
    }
}

