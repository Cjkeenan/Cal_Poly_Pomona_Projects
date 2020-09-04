namespace LinkLabelTest
{
   partial class LinkLabelTestForm
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
            this.wordLinkLabel = new System.Windows.Forms.LinkLabel();
            this.deitelLinkLabel = new System.Windows.Forms.LinkLabel();
            this.cDriveLinkLabel = new System.Windows.Forms.LinkLabel();
            this.powerpointLinkLabel = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // wordLinkLabel
            // 
            this.wordLinkLabel.AutoSize = true;
            this.wordLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordLinkLabel.Location = new System.Drawing.Point(25, 132);
            this.wordLinkLabel.Name = "wordLinkLabel";
            this.wordLinkLabel.Size = new System.Drawing.Size(152, 15);
            this.wordLinkLabel.TabIndex = 11;
            this.wordLinkLabel.TabStop = true;
            this.wordLinkLabel.Text = "Click to generate Word Doc";
            this.wordLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.wordLinkLabel_LinkClicked);
            // 
            // deitelLinkLabel
            // 
            this.deitelLinkLabel.AutoSize = true;
            this.deitelLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deitelLinkLabel.Location = new System.Drawing.Point(25, 57);
            this.deitelLinkLabel.Name = "deitelLinkLabel";
            this.deitelLinkLabel.Size = new System.Drawing.Size(160, 15);
            this.deitelLinkLabel.TabIndex = 10;
            this.deitelLinkLabel.TabStop = true;
            this.deitelLinkLabel.Text = "Click to visit www.deitel.com";
            this.deitelLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.deitelLinkLabel_LinkClicked);
            // 
            // cDriveLinkLabel
            // 
            this.cDriveLinkLabel.AutoSize = true;
            this.cDriveLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cDriveLinkLabel.Location = new System.Drawing.Point(25, 27);
            this.cDriveLinkLabel.Name = "cDriveLinkLabel";
            this.cDriveLinkLabel.Size = new System.Drawing.Size(107, 15);
            this.cDriveLinkLabel.TabIndex = 9;
            this.cDriveLinkLabel.TabStop = true;
            this.cDriveLinkLabel.Text = "Click to browse C:\\";
            this.cDriveLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cDriveLinkLabel_LinkClicked);
            // 
            // powerpointLinkLabel
            // 
            this.powerpointLinkLabel.AutoSize = true;
            this.powerpointLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerpointLinkLabel.Location = new System.Drawing.Point(25, 105);
            this.powerpointLinkLabel.Name = "powerpointLinkLabel";
            this.powerpointLinkLabel.Size = new System.Drawing.Size(132, 15);
            this.powerpointLinkLabel.TabIndex = 12;
            this.powerpointLinkLabel.TabStop = true;
            this.powerpointLinkLabel.Text = "Click to run PowerPoint";
            this.powerpointLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.powerpointLinkLabel_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(25, 81);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 15);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click to run Word";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LinkLabelTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 156);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.powerpointLinkLabel);
            this.Controls.Add(this.wordLinkLabel);
            this.Controls.Add(this.deitelLinkLabel);
            this.Controls.Add(this.cDriveLinkLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LinkLabelTestForm";
            this.Text = "LinkLabelTest";
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      internal System.Windows.Forms.LinkLabel wordLinkLabel;
      internal System.Windows.Forms.LinkLabel deitelLinkLabel;
      internal System.Windows.Forms.LinkLabel cDriveLinkLabel;
        internal System.Windows.Forms.LinkLabel powerpointLinkLabel;
        internal System.Windows.Forms.LinkLabel linkLabel1;
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
