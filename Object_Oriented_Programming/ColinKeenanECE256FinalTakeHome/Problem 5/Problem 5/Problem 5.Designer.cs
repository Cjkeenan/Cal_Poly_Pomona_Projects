using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Problem_5
{
    partial class P5
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
            this.applyButton = new System.Windows.Forms.Button();
            this.numberOfCirclesSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.colorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCirclesSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.applyButton.Location = new System.Drawing.Point(0, 293);
            this.applyButton.Margin = new System.Windows.Forms.Padding(4);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(379, 28);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // numberOfCirclesSizeUpDown
            // 
            this.numberOfCirclesSizeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberOfCirclesSizeUpDown.Location = new System.Drawing.Point(134, 17);
            this.numberOfCirclesSizeUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.numberOfCirclesSizeUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numberOfCirclesSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfCirclesSizeUpDown.Name = "numberOfCirclesSizeUpDown";
            this.numberOfCirclesSizeUpDown.Size = new System.Drawing.Size(119, 22);
            this.numberOfCirclesSizeUpDown.TabIndex = 7;
            this.numberOfCirclesSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // colorButton
            // 
            this.colorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorButton.Location = new System.Drawing.Point(275, 13);
            this.colorButton.Margin = new System.Windows.Forms.Padding(4);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(91, 28);
            this.colorButton.TabIndex = 8;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Number of Circles:";
            // 
            // P7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.numberOfCirclesSizeUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.applyButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "P7";
            this.Text = "Colin\'s Beautiful Circles";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCirclesSizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button applyButton;
        private NumericUpDown numberOfCirclesSizeUpDown;
        private Button colorButton;
        private Label label1;
    }
}

