namespace Problem_3
{
   partial class P3
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.imageComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageComboBox
            // 
            this.imageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageComboBox.FormattingEnabled = true;
            this.imageComboBox.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Triangle",
            "Pentagon",
            "Ellipse",
            "Pie",
            "Filled Circle",
            "Filled Square",
            "Filled Triangle",
            "Filled Pentagon",
            "Filled Ellipse",
            "Filled Pie"});
            this.imageComboBox.Location = new System.Drawing.Point(12, 37);
            this.imageComboBox.Name = "imageComboBox";
            this.imageComboBox.Size = new System.Drawing.Size(151, 28);
            this.imageComboBox.TabIndex = 3;
            this.imageComboBox.SelectedIndexChanged += new System.EventHandler(this.imageComboBox_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(308, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.fillToolStripMenuItem});
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.blackToolStripMenuItem.Text = "Black";
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem1,
            this.fillToolStripMenuItem1});
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.blueToolStripMenuItem.Text = "Blue";
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem2,
            this.fillToolStripMenuItem2});
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.redToolStripMenuItem.Text = "Red";
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem3,
            this.fillToolStripMenuItem3});
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.greenToolStripMenuItem.Text = "Green";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.fillToolStripMenuItem.Text = "Fill";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.fillToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem1
            // 
            this.lineToolStripMenuItem1.Name = "lineToolStripMenuItem1";
            this.lineToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.lineToolStripMenuItem1.Text = "Line";
            this.lineToolStripMenuItem1.Click += new System.EventHandler(this.lineToolStripMenuItem1_Click);
            // 
            // fillToolStripMenuItem1
            // 
            this.fillToolStripMenuItem1.Name = "fillToolStripMenuItem1";
            this.fillToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.fillToolStripMenuItem1.Text = "Fill";
            this.fillToolStripMenuItem1.Click += new System.EventHandler(this.fillToolStripMenuItem1_Click);
            // 
            // lineToolStripMenuItem2
            // 
            this.lineToolStripMenuItem2.Name = "lineToolStripMenuItem2";
            this.lineToolStripMenuItem2.Size = new System.Drawing.Size(181, 26);
            this.lineToolStripMenuItem2.Text = "Line";
            this.lineToolStripMenuItem2.Click += new System.EventHandler(this.lineToolStripMenuItem2_Click);
            // 
            // fillToolStripMenuItem2
            // 
            this.fillToolStripMenuItem2.Name = "fillToolStripMenuItem2";
            this.fillToolStripMenuItem2.Size = new System.Drawing.Size(181, 26);
            this.fillToolStripMenuItem2.Text = "Fill";
            this.fillToolStripMenuItem2.Click += new System.EventHandler(this.fillToolStripMenuItem2_Click);
            // 
            // lineToolStripMenuItem3
            // 
            this.lineToolStripMenuItem3.Name = "lineToolStripMenuItem3";
            this.lineToolStripMenuItem3.Size = new System.Drawing.Size(181, 26);
            this.lineToolStripMenuItem3.Text = "Line";
            this.lineToolStripMenuItem3.Click += new System.EventHandler(this.lineToolStripMenuItem3_Click);
            // 
            // fillToolStripMenuItem3
            // 
            this.fillToolStripMenuItem3.Name = "fillToolStripMenuItem3";
            this.fillToolStripMenuItem3.Size = new System.Drawing.Size(181, 26);
            this.fillToolStripMenuItem3.Text = "Fill";
            this.fillToolStripMenuItem3.Click += new System.EventHandler(this.fillToolStripMenuItem3_Click);
            // 
            // ComboBoxTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 249);
            this.Controls.Add(this.imageComboBox);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ComboBoxTestForm";
            this.Text = "Colin\'s Combo Box";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      internal System.Windows.Forms.ComboBox imageComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem3;
    }
}

/**************************************************************************
 * (C) Copyright 1992-2014 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
