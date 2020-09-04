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
            this.PrincipalInput = new System.Windows.Forms.TextBox();
            this.PrincipalLabel = new System.Windows.Forms.Label();
            this.InterestRateLabel = new System.Windows.Forms.Label();
            this.InterestRatePctInput = new System.Windows.Forms.TextBox();
            this.TermInput = new System.Windows.Forms.TextBox();
            this.TermLabel = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.MonthlyInstallmentLabel = new System.Windows.Forms.Label();
            this.TotalPaymentLabel = new System.Windows.Forms.Label();
            this.MonthlyInstallmentAnswer = new System.Windows.Forms.Label();
            this.TotalPaymentAnswer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrincipalInput
            // 
            this.PrincipalInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PrincipalInput.Location = new System.Drawing.Point(130, 10);
            this.PrincipalInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PrincipalInput.Name = "PrincipalInput";
            this.PrincipalInput.Size = new System.Drawing.Size(76, 20);
            this.PrincipalInput.TabIndex = 0;
            // 
            // PrincipalLabel
            // 
            this.PrincipalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PrincipalLabel.AutoSize = true;
            this.PrincipalLabel.Location = new System.Drawing.Point(40, 12);
            this.PrincipalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PrincipalLabel.Name = "PrincipalLabel";
            this.PrincipalLabel.Size = new System.Drawing.Size(89, 13);
            this.PrincipalLabel.TabIndex = 1;
            this.PrincipalLabel.Text = "Principal Amount:";
            this.PrincipalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PrincipalLabel.Click += new System.EventHandler(this.PrincipalLabel_Click);
            // 
            // InterestRateLabel
            // 
            this.InterestRateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.InterestRateLabel.AutoSize = true;
            this.InterestRateLabel.Location = new System.Drawing.Point(2, 42);
            this.InterestRateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InterestRateLabel.Name = "InterestRateLabel";
            this.InterestRateLabel.Size = new System.Drawing.Size(129, 13);
            this.InterestRateLabel.TabIndex = 2;
            this.InterestRateLabel.Text = "Interest Rate Percentage:";
            this.InterestRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InterestRateLabel.Click += new System.EventHandler(this.InterestRateLabel_Click);
            // 
            // InterestRatePctInput
            // 
            this.InterestRatePctInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.InterestRatePctInput.Location = new System.Drawing.Point(130, 40);
            this.InterestRatePctInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InterestRatePctInput.Name = "InterestRatePctInput";
            this.InterestRatePctInput.Size = new System.Drawing.Size(76, 20);
            this.InterestRatePctInput.TabIndex = 3;
            // 
            // TermInput
            // 
            this.TermInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TermInput.Location = new System.Drawing.Point(130, 71);
            this.TermInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TermInput.Name = "TermInput";
            this.TermInput.Size = new System.Drawing.Size(76, 20);
            this.TermInput.TabIndex = 5;
            // 
            // TermLabel
            // 
            this.TermLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TermLabel.AutoSize = true;
            this.TermLabel.Location = new System.Drawing.Point(9, 73);
            this.TermLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TermLabel.Name = "TermLabel";
            this.TermLabel.Size = new System.Drawing.Size(118, 13);
            this.TermLabel.TabIndex = 4;
            this.TermLabel.Text = "Length of Term (Years):";
            this.TermLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TermLabel.Click += new System.EventHandler(this.TermLabel_Click);
            // 
            // Calculate
            // 
            this.Calculate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Calculate.Location = new System.Drawing.Point(0, 187);
            this.Calculate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(212, 19);
            this.Calculate.TabIndex = 6;
            this.Calculate.Text = "Calculate";
            this.Calculate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // MonthlyInstallmentLabel
            // 
            this.MonthlyInstallmentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MonthlyInstallmentLabel.AutoSize = true;
            this.MonthlyInstallmentLabel.Location = new System.Drawing.Point(25, 115);
            this.MonthlyInstallmentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MonthlyInstallmentLabel.Name = "MonthlyInstallmentLabel";
            this.MonthlyInstallmentLabel.Size = new System.Drawing.Size(105, 13);
            this.MonthlyInstallmentLabel.TabIndex = 7;
            this.MonthlyInstallmentLabel.Text = "Monthly Installments:";
            // 
            // TotalPaymentLabel
            // 
            this.TotalPaymentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TotalPaymentLabel.AutoSize = true;
            this.TotalPaymentLabel.Location = new System.Drawing.Point(52, 129);
            this.TotalPaymentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalPaymentLabel.Name = "TotalPaymentLabel";
            this.TotalPaymentLabel.Size = new System.Drawing.Size(78, 13);
            this.TotalPaymentLabel.TabIndex = 8;
            this.TotalPaymentLabel.Text = "Total Payment:";
            // 
            // MonthlyInstallmentAnswer
            // 
            this.MonthlyInstallmentAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MonthlyInstallmentAnswer.AutoSize = true;
            this.MonthlyInstallmentAnswer.Location = new System.Drawing.Point(134, 115);
            this.MonthlyInstallmentAnswer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MonthlyInstallmentAnswer.Name = "MonthlyInstallmentAnswer";
            this.MonthlyInstallmentAnswer.Size = new System.Drawing.Size(0, 13);
            this.MonthlyInstallmentAnswer.TabIndex = 9;
            // 
            // TotalPaymentAnswer
            // 
            this.TotalPaymentAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TotalPaymentAnswer.AutoSize = true;
            this.TotalPaymentAnswer.Location = new System.Drawing.Point(134, 129);
            this.TotalPaymentAnswer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalPaymentAnswer.Name = "TotalPaymentAnswer";
            this.TotalPaymentAnswer.Size = new System.Drawing.Size(0, 13);
            this.TotalPaymentAnswer.TabIndex = 10;
            // 
            // P3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 206);
            this.Controls.Add(this.TotalPaymentAnswer);
            this.Controls.Add(this.MonthlyInstallmentAnswer);
            this.Controls.Add(this.TotalPaymentLabel);
            this.Controls.Add(this.MonthlyInstallmentLabel);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.TermInput);
            this.Controls.Add(this.TermLabel);
            this.Controls.Add(this.InterestRatePctInput);
            this.Controls.Add(this.InterestRateLabel);
            this.Controls.Add(this.PrincipalLabel);
            this.Controls.Add(this.PrincipalInput);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "P3";
            this.Text = "Problem 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PrincipalInput;
        private System.Windows.Forms.Label PrincipalLabel;
        private System.Windows.Forms.Label InterestRateLabel;
        private System.Windows.Forms.TextBox InterestRatePctInput;
        private System.Windows.Forms.TextBox TermInput;
        private System.Windows.Forms.Label TermLabel;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label MonthlyInstallmentLabel;
        private System.Windows.Forms.Label TotalPaymentLabel;
        private System.Windows.Forms.Label MonthlyInstallmentAnswer;
        private System.Windows.Forms.Label TotalPaymentAnswer;
    }
}

