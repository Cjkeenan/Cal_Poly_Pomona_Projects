using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_4
{
    public partial class P4 : Form
    {
        public P4()
        {
            InitializeComponent();
        }

        private void Calculate1_Click(object sender, EventArgs e)
        {
            Complex c1 = new Complex(
                System.Convert.ToDouble(rP1Input.Text),
                System.Convert.ToDouble(iP1Input.Text)
                );
            Complex c2 = new Complex(
                System.Convert.ToDouble(rP2Input.Text),
                System.Convert.ToDouble(iP2Input.Text)
                );
            Complex answer = new Complex();

            answer = c1.add(c2);
            SumAnswer.Text = answer.toString(true);

            answer = c1.subtract(c2);
            DiffAnswer.Text = answer.toString(true);

            answer = c1.mul(c2);
            ProductAnswer.Text = answer.toString(true);

            answer = c1.div(c2);
            QuotientAnswer.Text = answer.toString(true);

            PolarAnswer1.Text = c1.printPolar();
            PolarAnswer2.Text = c2.printPolar();
        }

        private void Calculate2_Click(object sender, EventArgs e)
        {
            Complex c3 = new Complex(
                System.Convert.ToDouble(rP3Input.Text),
                System.Convert.ToDouble(iP3Input.Text)
                );
            Complex answer = new Complex();

            answer = c3.pow(Convert.ToInt32(PowerInput.Text));

            PowerAnswer.Text = answer.toString(true);
        }
    }
}
