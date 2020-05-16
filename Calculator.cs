using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorSimple
{
    public partial class Calculator : Form
    {

        char decimalSeparator;
        double numOne = 0;
        double numTwo = 0;
        string operation;
        bool scifiMode = false;
        const int widthSmall = 352;
        const int widthLarge = 622;

        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.BackColor = Color.Blue;
            this.Width = widthSmall;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;


            Button button = null;
            string buttonName = null;
            for(int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                button.BackColor = Color.CadetBlue;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                if(Display.Text == string.Empty)
                {
                    Display.Text += "0.";
                }
                else
                {
                    Display.Text += ".";
                }
            }
        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 0)
            {
                s = s.Substring(0, s.Length - 1);
            }
            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(Display.Text);
            number *= -1; //number = number * (-1)
            Display.Text = Convert.ToString(number);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            numOne = Convert.ToDouble(Display.Text);
            Display.Text = string.Empty;
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            //Button button = (Button)sender;
            numOne = Convert.ToDouble(Display.Text);
            Display.Text = string.Empty;
            operation = ((Button)sender).Text;

            if(operation == "Sqrt")
            {
                Display.Text = Math.Sqrt(numOne).ToString();
                return;
            }
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            double result = 0;
            numTwo = Convert.ToDouble(Display.Text);
            if (operation == "+")
            {
                result = numOne + numTwo;
            }
            else if (operation == "-")
            {
                result = numOne - numTwo;
            }
            else if (operation == "x")
            {
                result = numOne * numTwo;
            }
            else if (operation == "/")
            {
                result = numOne / numTwo;
            }
            else if(operation == "^")
            {
                result = Math.Pow(numOne, numTwo);
            }

            Display.Text = result.ToString();
        }

        private void buttonSubstract_Click(object sender, EventArgs e)
        {
            numOne = Convert.ToDouble(Display.Text);
            Display.Text = string.Empty;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            double result = 0;
            Display.Text = result.ToString();
        }

        private void buttonSciFi_Click(object sender, EventArgs e)
        {
            if (scifiMode)
            {
                this.Width = widthSmall;
            }
            else
            {
                this.Width = widthLarge;
            }
            scifiMode = !scifiMode;
        }
    }
}