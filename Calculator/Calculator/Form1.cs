using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        double resultValue = 0.0;
        String operationalPerformed = "";
        bool isOperationPerformed = false;

        public CalculatorForm()
        {
            InitializeComponent();
         
        }
        private void btn_click(object sender, EventArgs e)
        {
            if ((txt.Text == "0") || (isOperationPerformed))
            {
                txt.Clear();
            }
            Button button = (Button)sender;
            isOperationPerformed = false;
            if (button.Text == ".")
            {
                if (!txt.Text.Contains("."))
                {
                    txt.Text = txt.Text + button.Text;
                }
            }
            else
            {
                txt.Text = txt.Text + button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                btnequ.PerformClick();
                operationalPerformed = button.Text;
                lbl.Text = resultValue + " " + operationalPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationalPerformed = button.Text;
                resultValue = Double.Parse(txt.Text);
                lbl.Text = resultValue + " " + operationalPerformed;
                isOperationPerformed = true;
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txt.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txt.Text = "0";
            resultValue = 0;
            lbl.Text = "";
        }

        private void btnequ_Click(object sender, EventArgs e)
        {
            switch (operationalPerformed)
            {
                case "+":
                    txt.Text = (resultValue + Double.Parse(txt.Text)).ToString();
                    break;
                case "-":
                    txt.Text = (resultValue - Double.Parse(txt.Text)).ToString();
                    break;
                case "*":
                    txt.Text = (resultValue * Double.Parse(txt.Text)).ToString();
                    break;
                case "/":
                    txt.Text = (resultValue / Double.Parse(txt.Text)).ToString();
                    break;
                default:
                break;
            }
            resultValue = Double.Parse(txt.Text);
            lbl.Text = "";
        }

       
     
    }
}
