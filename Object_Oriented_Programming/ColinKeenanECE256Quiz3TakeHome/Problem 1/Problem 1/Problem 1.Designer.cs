namespace Problem_1
{
   partial class Problem_1
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
            this.displayLabel = new System.Windows.Forms.Label();
            this.textOptionsTabControl = new System.Windows.Forms.TabControl();
            this.colorTabPage = new System.Windows.Forms.TabPage();
            this.customColorButton = new System.Windows.Forms.Button();
            this.blueRadioButton = new System.Windows.Forms.RadioButton();
            this.greenRadioButton = new System.Windows.Forms.RadioButton();
            this.redRadioButton = new System.Windows.Forms.RadioButton();
            this.blackRadioButton = new System.Windows.Forms.RadioButton();
            this.sizeTabPage = new System.Windows.Forms.TabPage();
            this.size24RadioButton = new System.Windows.Forms.RadioButton();
            this.size36RadioButton = new System.Windows.Forms.RadioButton();
            this.size20RadioButton = new System.Windows.Forms.RadioButton();
            this.size16RadioButton = new System.Windows.Forms.RadioButton();
            this.size12RadioButton = new System.Windows.Forms.RadioButton();
            this.messageTabPage = new System.Windows.Forms.TabPage();
            this.applyMessageButton = new System.Windows.Forms.Button();
            this.customMessageTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.seeYaRadioButton = new System.Windows.Forms.RadioButton();
            this.thankYouRadioButton = new System.Windows.Forms.RadioButton();
            this.goodbyeRadioButton = new System.Windows.Forms.RadioButton();
            this.helloRadioButton = new System.Windows.Forms.RadioButton();
            this.fontTabPage = new System.Windows.Forms.TabPage();
            this.fontButton = new System.Windows.Forms.Button();
            this.specialFunctiontabPage = new System.Windows.Forms.TabPage();
            this.resetCaseButton = new System.Windows.Forms.Button();
            this.countCharactersButton = new System.Windows.Forms.Button();
            this.lowerCaseButton = new System.Windows.Forms.Button();
            this.upperCaseButton = new System.Windows.Forms.Button();
            this.reverseWordButton = new System.Windows.Forms.Button();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.messageLabel = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.textOptionsTabControl.SuspendLayout();
            this.colorTabPage.SuspendLayout();
            this.sizeTabPage.SuspendLayout();
            this.messageTabPage.SuspendLayout();
            this.fontTabPage.SuspendLayout();
            this.specialFunctiontabPage.SuspendLayout();
            this.aboutTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.displayLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayLabel.Location = new System.Drawing.Point(0, 272);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(51, 21);
            this.displayLabel.TabIndex = 7;
            this.displayLabel.Text = "Hello!";
            this.displayLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textOptionsTabControl
            // 
            this.textOptionsTabControl.Controls.Add(this.colorTabPage);
            this.textOptionsTabControl.Controls.Add(this.sizeTabPage);
            this.textOptionsTabControl.Controls.Add(this.messageTabPage);
            this.textOptionsTabControl.Controls.Add(this.fontTabPage);
            this.textOptionsTabControl.Controls.Add(this.specialFunctiontabPage);
            this.textOptionsTabControl.Controls.Add(this.aboutTabPage);
            this.textOptionsTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.textOptionsTabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.textOptionsTabControl.Name = "textOptionsTabControl";
            this.textOptionsTabControl.SelectedIndex = 0;
            this.textOptionsTabControl.Size = new System.Drawing.Size(349, 170);
            this.textOptionsTabControl.TabIndex = 6;
            // 
            // colorTabPage
            // 
            this.colorTabPage.Controls.Add(this.customColorButton);
            this.colorTabPage.Controls.Add(this.blueRadioButton);
            this.colorTabPage.Controls.Add(this.greenRadioButton);
            this.colorTabPage.Controls.Add(this.redRadioButton);
            this.colorTabPage.Controls.Add(this.blackRadioButton);
            this.colorTabPage.Location = new System.Drawing.Point(4, 24);
            this.colorTabPage.Name = "colorTabPage";
            this.colorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.colorTabPage.Size = new System.Drawing.Size(341, 142);
            this.colorTabPage.TabIndex = 0;
            this.colorTabPage.Text = "Color";
            // 
            // customColorButton
            // 
            this.customColorButton.Location = new System.Drawing.Point(169, 50);
            this.customColorButton.Name = "customColorButton";
            this.customColorButton.Size = new System.Drawing.Size(118, 36);
            this.customColorButton.TabIndex = 8;
            this.customColorButton.Text = "Custom Color";
            this.customColorButton.UseVisualStyleBackColor = true;
            this.customColorButton.Click += new System.EventHandler(this.customColorButton_Click);
            // 
            // blueRadioButton
            // 
            this.blueRadioButton.AutoSize = true;
            this.blueRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blueRadioButton.Location = new System.Drawing.Point(6, 81);
            this.blueRadioButton.Name = "blueRadioButton";
            this.blueRadioButton.Size = new System.Drawing.Size(48, 19);
            this.blueRadioButton.TabIndex = 3;
            this.blueRadioButton.Text = "Blue";
            this.blueRadioButton.CheckedChanged += new System.EventHandler(this.blueRadioButton_CheckedChanged);
            // 
            // greenRadioButton
            // 
            this.greenRadioButton.AutoSize = true;
            this.greenRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greenRadioButton.Location = new System.Drawing.Point(6, 56);
            this.greenRadioButton.Name = "greenRadioButton";
            this.greenRadioButton.Size = new System.Drawing.Size(56, 19);
            this.greenRadioButton.TabIndex = 2;
            this.greenRadioButton.Text = "Green";
            this.greenRadioButton.CheckedChanged += new System.EventHandler(this.greenRadioButton_CheckedChanged);
            // 
            // redRadioButton
            // 
            this.redRadioButton.AutoSize = true;
            this.redRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redRadioButton.Location = new System.Drawing.Point(6, 31);
            this.redRadioButton.Name = "redRadioButton";
            this.redRadioButton.Size = new System.Drawing.Size(45, 19);
            this.redRadioButton.TabIndex = 1;
            this.redRadioButton.Text = "Red";
            this.redRadioButton.CheckedChanged += new System.EventHandler(this.redRadioButton_CheckedChanged);
            // 
            // blackRadioButton
            // 
            this.blackRadioButton.AutoSize = true;
            this.blackRadioButton.Checked = true;
            this.blackRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackRadioButton.Location = new System.Drawing.Point(6, 6);
            this.blackRadioButton.Name = "blackRadioButton";
            this.blackRadioButton.Size = new System.Drawing.Size(53, 19);
            this.blackRadioButton.TabIndex = 0;
            this.blackRadioButton.TabStop = true;
            this.blackRadioButton.Text = "Black";
            this.blackRadioButton.CheckedChanged += new System.EventHandler(this.blackRadioButton_CheckedChanged);
            // 
            // sizeTabPage
            // 
            this.sizeTabPage.Controls.Add(this.size24RadioButton);
            this.sizeTabPage.Controls.Add(this.size36RadioButton);
            this.sizeTabPage.Controls.Add(this.size20RadioButton);
            this.sizeTabPage.Controls.Add(this.size16RadioButton);
            this.sizeTabPage.Controls.Add(this.size12RadioButton);
            this.sizeTabPage.Location = new System.Drawing.Point(4, 24);
            this.sizeTabPage.Name = "sizeTabPage";
            this.sizeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sizeTabPage.Size = new System.Drawing.Size(341, 142);
            this.sizeTabPage.TabIndex = 1;
            this.sizeTabPage.Text = "Size";
            // 
            // size24RadioButton
            // 
            this.size24RadioButton.AutoSize = true;
            this.size24RadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size24RadioButton.Location = new System.Drawing.Point(6, 81);
            this.size24RadioButton.Name = "size24RadioButton";
            this.size24RadioButton.Size = new System.Drawing.Size(68, 19);
            this.size24RadioButton.TabIndex = 4;
            this.size24RadioButton.Text = "24 point";
            this.size24RadioButton.CheckedChanged += new System.EventHandler(this.size24RadioButton_CheckedChanged);
            // 
            // size36RadioButton
            // 
            this.size36RadioButton.AutoSize = true;
            this.size36RadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size36RadioButton.Location = new System.Drawing.Point(6, 106);
            this.size36RadioButton.Name = "size36RadioButton";
            this.size36RadioButton.Size = new System.Drawing.Size(68, 19);
            this.size36RadioButton.TabIndex = 3;
            this.size36RadioButton.Text = "36 point";
            this.size36RadioButton.CheckedChanged += new System.EventHandler(this.size36RadioButton_CheckedChanged);
            // 
            // size20RadioButton
            // 
            this.size20RadioButton.AutoSize = true;
            this.size20RadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size20RadioButton.Location = new System.Drawing.Point(6, 56);
            this.size20RadioButton.Name = "size20RadioButton";
            this.size20RadioButton.Size = new System.Drawing.Size(68, 19);
            this.size20RadioButton.TabIndex = 2;
            this.size20RadioButton.Text = "20 point";
            this.size20RadioButton.CheckedChanged += new System.EventHandler(this.size20RadioButton_CheckedChanged);
            // 
            // size16RadioButton
            // 
            this.size16RadioButton.AutoSize = true;
            this.size16RadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size16RadioButton.Location = new System.Drawing.Point(6, 31);
            this.size16RadioButton.Name = "size16RadioButton";
            this.size16RadioButton.Size = new System.Drawing.Size(68, 19);
            this.size16RadioButton.TabIndex = 1;
            this.size16RadioButton.Text = "16 point";
            this.size16RadioButton.CheckedChanged += new System.EventHandler(this.size16RadioButton_CheckedChanged);
            // 
            // size12RadioButton
            // 
            this.size12RadioButton.AutoSize = true;
            this.size12RadioButton.Checked = true;
            this.size12RadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size12RadioButton.Location = new System.Drawing.Point(6, 6);
            this.size12RadioButton.Name = "size12RadioButton";
            this.size12RadioButton.Size = new System.Drawing.Size(68, 19);
            this.size12RadioButton.TabIndex = 0;
            this.size12RadioButton.TabStop = true;
            this.size12RadioButton.Text = "12 point";
            this.size12RadioButton.CheckedChanged += new System.EventHandler(this.size12RadioButton_CheckedChanged);
            // 
            // messageTabPage
            // 
            this.messageTabPage.Controls.Add(this.applyMessageButton);
            this.messageTabPage.Controls.Add(this.customMessageTextBox);
            this.messageTabPage.Controls.Add(this.label1);
            this.messageTabPage.Controls.Add(this.seeYaRadioButton);
            this.messageTabPage.Controls.Add(this.thankYouRadioButton);
            this.messageTabPage.Controls.Add(this.goodbyeRadioButton);
            this.messageTabPage.Controls.Add(this.helloRadioButton);
            this.messageTabPage.Location = new System.Drawing.Point(4, 24);
            this.messageTabPage.Name = "messageTabPage";
            this.messageTabPage.Size = new System.Drawing.Size(341, 142);
            this.messageTabPage.TabIndex = 2;
            this.messageTabPage.Text = "Message";
            // 
            // applyMessageButton
            // 
            this.applyMessageButton.Location = new System.Drawing.Point(202, 100);
            this.applyMessageButton.Name = "applyMessageButton";
            this.applyMessageButton.Size = new System.Drawing.Size(75, 28);
            this.applyMessageButton.TabIndex = 8;
            this.applyMessageButton.Text = "Apply";
            this.applyMessageButton.UseVisualStyleBackColor = true;
            this.applyMessageButton.Click += new System.EventHandler(this.applyMessageButton_Click);
            // 
            // customMessageTextBox
            // 
            this.customMessageTextBox.Location = new System.Drawing.Point(172, 31);
            this.customMessageTextBox.Multiline = true;
            this.customMessageTextBox.Name = "customMessageTextBox";
            this.customMessageTextBox.Size = new System.Drawing.Size(141, 63);
            this.customMessageTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Custom Message";
            // 
            // seeYaRadioButton
            // 
            this.seeYaRadioButton.AutoSize = true;
            this.seeYaRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seeYaRadioButton.Location = new System.Drawing.Point(6, 81);
            this.seeYaRadioButton.Name = "seeYaRadioButton";
            this.seeYaRadioButton.Size = new System.Drawing.Size(61, 19);
            this.seeYaRadioButton.TabIndex = 5;
            this.seeYaRadioButton.Text = "See Ya!";
            this.seeYaRadioButton.CheckedChanged += new System.EventHandler(this.seeYaRadioButton_CheckedChanged);
            // 
            // thankYouRadioButton
            // 
            this.thankYouRadioButton.AutoSize = true;
            this.thankYouRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thankYouRadioButton.Location = new System.Drawing.Point(6, 56);
            this.thankYouRadioButton.Name = "thankYouRadioButton";
            this.thankYouRadioButton.Size = new System.Drawing.Size(84, 19);
            this.thankYouRadioButton.TabIndex = 4;
            this.thankYouRadioButton.Text = "Thank You!";
            this.thankYouRadioButton.CheckedChanged += new System.EventHandler(this.thankYouRadioButton_CheckedChanged);
            // 
            // goodbyeRadioButton
            // 
            this.goodbyeRadioButton.AutoSize = true;
            this.goodbyeRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goodbyeRadioButton.Location = new System.Drawing.Point(6, 31);
            this.goodbyeRadioButton.Name = "goodbyeRadioButton";
            this.goodbyeRadioButton.Size = new System.Drawing.Size(76, 19);
            this.goodbyeRadioButton.TabIndex = 3;
            this.goodbyeRadioButton.Text = "Goodbye!";
            this.goodbyeRadioButton.CheckedChanged += new System.EventHandler(this.goodbyeRadioButton_CheckedChanged);
            // 
            // helloRadioButton
            // 
            this.helloRadioButton.AutoSize = true;
            this.helloRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloRadioButton.Location = new System.Drawing.Point(6, 6);
            this.helloRadioButton.Name = "helloRadioButton";
            this.helloRadioButton.Size = new System.Drawing.Size(56, 19);
            this.helloRadioButton.TabIndex = 2;
            this.helloRadioButton.Text = "Hello!";
            this.helloRadioButton.CheckedChanged += new System.EventHandler(this.helloRadioButton_CheckedChanged);
            // 
            // fontTabPage
            // 
            this.fontTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.fontTabPage.Controls.Add(this.fontButton);
            this.fontTabPage.Location = new System.Drawing.Point(4, 24);
            this.fontTabPage.Name = "fontTabPage";
            this.fontTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fontTabPage.Size = new System.Drawing.Size(341, 142);
            this.fontTabPage.TabIndex = 4;
            this.fontTabPage.Text = "Font";
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(54, 50);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(222, 34);
            this.fontButton.TabIndex = 2;
            this.fontButton.Text = "Click to Choose Font";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // specialFunctiontabPage
            // 
            this.specialFunctiontabPage.Controls.Add(this.resetCaseButton);
            this.specialFunctiontabPage.Controls.Add(this.countCharactersButton);
            this.specialFunctiontabPage.Controls.Add(this.lowerCaseButton);
            this.specialFunctiontabPage.Controls.Add(this.upperCaseButton);
            this.specialFunctiontabPage.Controls.Add(this.reverseWordButton);
            this.specialFunctiontabPage.Location = new System.Drawing.Point(4, 24);
            this.specialFunctiontabPage.Name = "specialFunctiontabPage";
            this.specialFunctiontabPage.Padding = new System.Windows.Forms.Padding(3);
            this.specialFunctiontabPage.Size = new System.Drawing.Size(341, 142);
            this.specialFunctiontabPage.TabIndex = 5;
            this.specialFunctiontabPage.Text = "Special Functions";
            this.specialFunctiontabPage.UseVisualStyleBackColor = true;
            // 
            // resetCaseButton
            // 
            this.resetCaseButton.Location = new System.Drawing.Point(116, 98);
            this.resetCaseButton.Name = "resetCaseButton";
            this.resetCaseButton.Size = new System.Drawing.Size(110, 33);
            this.resetCaseButton.TabIndex = 4;
            this.resetCaseButton.Text = "Reset Case";
            this.resetCaseButton.UseVisualStyleBackColor = true;
            this.resetCaseButton.Click += new System.EventHandler(this.resetCaseButton_Click);
            // 
            // countCharactersButton
            // 
            this.countCharactersButton.Location = new System.Drawing.Point(176, 6);
            this.countCharactersButton.Name = "countCharactersButton";
            this.countCharactersButton.Size = new System.Drawing.Size(159, 41);
            this.countCharactersButton.TabIndex = 3;
            this.countCharactersButton.Text = "Count Characters";
            this.countCharactersButton.UseVisualStyleBackColor = true;
            this.countCharactersButton.Click += new System.EventHandler(this.countCharactersButton_Click);
            // 
            // lowerCaseButton
            // 
            this.lowerCaseButton.Location = new System.Drawing.Point(176, 53);
            this.lowerCaseButton.Name = "lowerCaseButton";
            this.lowerCaseButton.Size = new System.Drawing.Size(159, 41);
            this.lowerCaseButton.TabIndex = 2;
            this.lowerCaseButton.Text = "To Lower Case";
            this.lowerCaseButton.UseVisualStyleBackColor = true;
            this.lowerCaseButton.Click += new System.EventHandler(this.lowerCaseButton_Click);
            // 
            // upperCaseButton
            // 
            this.upperCaseButton.Location = new System.Drawing.Point(8, 53);
            this.upperCaseButton.Name = "upperCaseButton";
            this.upperCaseButton.Size = new System.Drawing.Size(159, 41);
            this.upperCaseButton.TabIndex = 1;
            this.upperCaseButton.Text = "To Upper Case";
            this.upperCaseButton.UseVisualStyleBackColor = true;
            this.upperCaseButton.Click += new System.EventHandler(this.upperCaseButton_Click);
            // 
            // reverseWordButton
            // 
            this.reverseWordButton.Location = new System.Drawing.Point(8, 6);
            this.reverseWordButton.Name = "reverseWordButton";
            this.reverseWordButton.Size = new System.Drawing.Size(159, 41);
            this.reverseWordButton.TabIndex = 0;
            this.reverseWordButton.Text = "Reverse Word";
            this.reverseWordButton.UseVisualStyleBackColor = true;
            this.reverseWordButton.Click += new System.EventHandler(this.reverseWordButton_Click);
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Controls.Add(this.messageLabel);
            this.aboutTabPage.Location = new System.Drawing.Point(4, 24);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Size = new System.Drawing.Size(341, 142);
            this.aboutTabPage.TabIndex = 3;
            this.aboutTabPage.Text = "About";
            // 
            // messageLabel
            // 
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(6, 6);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(227, 46);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Tabs are used to organize controls and conserve screen space.";
            // 
            // Problem_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 293);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.textOptionsTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Problem_1";
            this.Text = "Problem 1";
            this.textOptionsTabControl.ResumeLayout(false);
            this.colorTabPage.ResumeLayout(false);
            this.colorTabPage.PerformLayout();
            this.sizeTabPage.ResumeLayout(false);
            this.sizeTabPage.PerformLayout();
            this.messageTabPage.ResumeLayout(false);
            this.messageTabPage.PerformLayout();
            this.fontTabPage.ResumeLayout(false);
            this.specialFunctiontabPage.ResumeLayout(false);
            this.aboutTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      internal System.Windows.Forms.Label displayLabel;
      internal System.Windows.Forms.TabControl textOptionsTabControl;
      internal System.Windows.Forms.TabPage colorTabPage;
      internal System.Windows.Forms.RadioButton greenRadioButton;
      internal System.Windows.Forms.RadioButton redRadioButton;
      internal System.Windows.Forms.RadioButton blackRadioButton;
      internal System.Windows.Forms.TabPage sizeTabPage;
      internal System.Windows.Forms.RadioButton size20RadioButton;
      internal System.Windows.Forms.RadioButton size16RadioButton;
      internal System.Windows.Forms.RadioButton size12RadioButton;
      internal System.Windows.Forms.TabPage messageTabPage;
      internal System.Windows.Forms.TabPage aboutTabPage;
      internal System.Windows.Forms.Label messageLabel;
      internal System.Windows.Forms.RadioButton goodbyeRadioButton;
      internal System.Windows.Forms.RadioButton helloRadioButton;
        private System.Windows.Forms.TabPage fontTabPage;
        internal System.Windows.Forms.RadioButton blueRadioButton;
        internal System.Windows.Forms.RadioButton size24RadioButton;
        internal System.Windows.Forms.RadioButton size36RadioButton;
        internal System.Windows.Forms.RadioButton seeYaRadioButton;
        internal System.Windows.Forms.RadioButton thankYouRadioButton;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.TabPage specialFunctiontabPage;
        private System.Windows.Forms.Button lowerCaseButton;
        private System.Windows.Forms.Button upperCaseButton;
        private System.Windows.Forms.Button reverseWordButton;
        private System.Windows.Forms.Button countCharactersButton;
        private System.Windows.Forms.Button resetCaseButton;
        private System.Windows.Forms.Button customColorButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customMessageTextBox;
        private System.Windows.Forms.Button applyMessageButton;
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
