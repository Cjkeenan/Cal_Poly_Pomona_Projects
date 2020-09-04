using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_3
{
    public partial class P3 : Form
    {
        public P3()
        {
            InitializeComponent();
        }
        private void Calculate_Click(object sender, EventArgs e)
        {
            double P, r, I, x; // principal, monthly rate, and installment
            int n; // number of years

            P = Convert.ToDouble(PrincipalInput.Text);        //principal

            r = Convert.ToDouble(InterestRatePctInput.Text);        //monthly rate
            r = r / 1200;

            n = Convert.ToInt32(TermInput.Text);        //years for loan

            x = Math.Pow(1 + r, 12 * n);
            I = P * x * r / (x - 1);

            MonthlyInstallmentAnswer.Text = Convert.ToString(String.Format("{0:C}",I));
            TotalPaymentAnswer.Text = Convert.ToString(String.Format("{0:C}", I * n * 12));
        }

        private void PrincipalLabel_Click(object sender, EventArgs e)
        {
            PrincipalInput.Clear();
        }

        private void InterestRateLabel_Click(object sender, EventArgs e)
        {
            InterestRatePctInput.Clear();
        }

        private void TermLabel_Click(object sender, EventArgs e)
        {
            TermInput.Clear();
        }
    }
}
