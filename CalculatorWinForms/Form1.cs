using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinForms
{
    public partial class Form1 : Form
    {
        public char operator1 = '0';
        public double first_number = 0;
        public double second_number = 0;
        public double result = 0;
        public double lower_than_ten = 0.1;
        public int coma = 0;

        public double CheckNumberBehindComa(double k)
        {
            string x = Convert.ToString(k);
          

            for (int i = 0; i < x.Length; i++)
            {
                if(x[i] == ',')
                {
                    string z = x.Substring(i + 1, x.Length - (i + 1));
                    return Convert.ToDouble(z);
                }
            }
            return 0;
        }

        public Form1()
        {
            //this.FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            InitializeComponent();
            label1.Text = "0";

        }

        private void flowRightToLeftBtn_CheckedChanged(
        System.Object sender,
        System.EventArgs e)
        {
            this.FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 9;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 9;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if (first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 9;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 9;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 9;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 9;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
            else
            {
                if (second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 9;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = 9;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if (second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 9;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 + 9;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        second_number = second_number - lower_than_ten * 9;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 - 9;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            if(coma != 1)
            {
                coma = 1;
                if (operator1 == '0')
                   {
                    label1.Text = Convert.ToString(first_number) + ',';
                }
                else
                {
                    label1.Text = Convert.ToString(second_number) + ',';
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //float helper;

            switch(operator1)
            {
                case '+':  result = first_number + second_number;
                    label1.Text = Convert.ToString(result);
                    label2.Text = "";
                    first_number = 0;
                    second_number = 0;
                    operator1 = '0';
                    break;
                case '-': result = first_number - second_number;
                    label1.Text = Convert.ToString(result);
                    label2.Text = "";
                    first_number = 0;
                    second_number = 0;
                    operator1 = '0';
                    break;
                case 'x':
                    result = first_number * second_number;
                    label1.Text = Convert.ToString(result);
                    label2.Text = "";
                    first_number = 0;
                    second_number = 0;
                    operator1 = '0';
                    break;
                case '/':if (second_number == 0) label1.Text = "#ERR DIV0";
                    else
                    {
                        result = first_number / second_number;
                        label1.Text = Convert.ToString(result);
                        label2.Text = "";
                        first_number = 0;
                        second_number = 0;
                        operator1 = '0';
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if(result != 0)
            {
                if (CheckNumberBehindComa(result) > 0)
                {
                    string y = Convert.ToString(CheckNumberBehindComa(result));
                    double tmp = 1;

                    for (int i = 0; i < y.Length; i++)
                    {
                        tmp *= 10;
                    }

                    result = result - (1 / tmp * ((y[y.Length - 1]) - '0'));
                    label1.Text = Convert.ToString(result);
                    lower_than_ten *= 10;
                    if (lower_than_ten == 0.1) coma = 0;
                }
                else
                {
                    string i = Convert.ToString(result);
                    char a = i[i.Length - 1];
                    int b = a - '0';
                    result = (result - b) / 10;
                    label1.Text = Convert.ToString(result);
                }
            }
            else if (operator1 == '0')
            {
                if (CheckNumberBehindComa(first_number) > 0)
                {
                    string y = Convert.ToString(CheckNumberBehindComa(first_number));
                    double tmp = 1;

                    for (int i = 0; i < y.Length; i++)
                    {
                        tmp *= 10;
                    }

                    first_number = first_number - (1 / tmp * ((y[y.Length - 1]) - '0'));
                    label1.Text = Convert.ToString(first_number);
                    lower_than_ten *= 10;
                    if (lower_than_ten == 0.1) coma = 0;
                }
                else
                {
                    string i = Convert.ToString(first_number);
                    char a = i[i.Length - 1];
                    int b = a - '0';
                    first_number = (first_number - b) / 10;
                    label1.Text = Convert.ToString(first_number);
                   
                }
           }
            else
            {
                if (CheckNumberBehindComa(second_number) > 0)
                {
                    string y = Convert.ToString(CheckNumberBehindComa(second_number));
                    double tmp = 1;

                    for (int i = 0; i < y.Length; i++)
                    {
                        tmp *= 10;
                    }

                    second_number = second_number - (1 / tmp * ((y[y.Length - 1]) - '0'));
                    label1.Text = Convert.ToString(second_number);
                    lower_than_ten *= 10;
                    if (lower_than_ten == 0.1) coma = 0;
                }
                else
                {
                    string i = Convert.ToString(second_number);
                    char a = i[i.Length - 1];
                    int b = a - '0';
                    second_number = (second_number - b) / 10;
                    label1.Text = Convert.ToString(second_number);
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            lower_than_ten = 0.1;
            coma = 0;
            if(result != 0)
            {
                first_number = result;
                operator1 = '/';
                label2.Text = Convert.ToString(first_number) + " " + operator1 + " ";
                label1.Text = " ";

            }
            else
            {
                operator1 = '/';
                label2.Text = Convert.ToString(first_number) + " " + operator1 + " ";
                label1.Text = " ";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "";
            first_number = 0;
            second_number = 0;
            result = 0;
            operator1 = '0';
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if(first_number != 0 && operator1 == '0' && second_number == 0)
            {
                double first_number1 = Convert.ToDouble(this.first_number);
                double helper2 = Math.Sqrt(first_number);
                label1.Text = Convert.ToString(helper2);
                first_number = (long)helper2;
            }
            else
            {
                double second_number2 = Convert.ToDouble(this.second_number);
                double helper2 = Math.Sqrt(second_number);
                label1.Text = Convert.ToString(helper2);
                second_number = (long)helper2;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 2;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 2;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if (first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 2;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 2;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 2;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 2;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
            else
            {
                if (second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 3;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = 2;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if (second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 2;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 + 2;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = second_number - lower_than_ten * 2;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 - 2;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            result = 0;
            if(operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 1;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 1;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if(first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 1;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 1;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 1;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 1;
                        label1.Text = Convert.ToString(first_number);
                    }
                } 
            }
            else
            {
                if(second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 1;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = 1;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if(second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 1;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 + 1;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else
                {
                    if(coma == 1)
                    {
                        second_number = second_number - lower_than_ten * 1;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    second_number = second_number * 10 - 1;
                    label1.Text = Convert.ToString(second_number);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 3;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 3;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if(first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 3;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 3;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 3;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 3;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
            else
            {
                if (second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 3;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = 3;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if (second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 3;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 + 3;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        second_number = second_number - lower_than_ten * 3;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 - 3;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 4;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 4;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if (first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 4;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 4;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 4;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 4;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
            else
            {
                if (second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 4;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = 4;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if (second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 4;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 + 4;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        second_number = second_number - lower_than_ten * 4;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 - 4;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 5;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 5;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if (first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 5;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 5;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 5;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 5;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
            else
            {
                if (second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 5;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = 5;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if (second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 5;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 + 5;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        second_number = second_number - lower_than_ten * 5;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 - 5;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 6;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 6;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if (first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 6;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 6;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 6;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 6;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
            else
            {
                if (second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 6;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = 6;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if (second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 6;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 + 6;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        second_number = second_number - lower_than_ten * 6;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 - 6;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //FXCop, Code Analyzer for Azure, String.Format
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 7;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 7;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if ( first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 7;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 7;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 7;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 7;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
            else
            {
                if (second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 7;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    {
                        second_number = 7;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if (second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 7;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 + 7;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        second_number = second_number - lower_than_ten * 7;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 - 7;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 8;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = 8;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if (first_number > 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 8;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 + 8;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        first_number = first_number - lower_than_ten * 8;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10 - 8;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
            }
            else
            {
                if (second_number == 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 8;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = 8;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
                else if (second_number > 0)
                {
                    if (coma == 1)
                    {
                        second_number = second_number + lower_than_ten * 8;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    second_number = second_number * 10 + 8;
                    label1.Text = Convert.ToString(second_number);
                }
                else
                {
                    if (coma == 1)
                    {
                        second_number = second_number - lower_than_ten * 8;
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(second_number);
                    }
                    else
                    {
                        second_number = second_number * 10 - 8;
                        label1.Text = Convert.ToString(second_number);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = 0;
            if (operator1 == '0')
            {
                if (first_number == 0)
                {
                    if (coma == 1)
                    {
                        first_number = first_number + lower_than_ten * 0;
                        lower_than_ten /= 10;
                        //label1.Text = Convert.ToString(Math.Round(first_number,2));
                    }
                    else
                    {
                        first_number = 0;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else if (first_number > 0)
                {
                    if (coma == 1)
                    {
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
                else
                {
                    if (coma == 1)
                    {
                        lower_than_ten /= 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                    else
                    {
                        first_number = first_number * 10;
                        label1.Text = Convert.ToString(first_number);
                    }
                }
           
            }
            else
            {
                if (second_number == 0)
                {
                    second_number = 0;
                    label1.Text = Convert.ToString(second_number);
                }
                else
                {
                    second_number = second_number * 10 + 0;
                    label1.Text = Convert.ToString(second_number);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(operator1 == '0')
            {
                first_number = -first_number;
                label1.Text = Convert.ToString(first_number);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            lower_than_ten = 0.1;
            coma = 0;
            if (result != 0)
            {
                first_number = result;
                operator1 = 'x';
                label2.Text = Convert.ToString(first_number) + " " + operator1 + " ";
                label1.Text = " ";
            }
            else
            {
                operator1 = 'x';
                label2.Text = Convert.ToString(first_number) + " " + operator1 + " ";
                label1.Text = " ";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lower_than_ten = 0.1;
            coma = 0;
            if (result != 0)
            {
                first_number = result;
                operator1 = '-';
                label2.Text = Convert.ToString(first_number) + " " + operator1 + " ";
                label1.Text = " ";
            }
            else
            {
                operator1 = '-';
                label2.Text = Convert.ToString(first_number) + " " + operator1 + " ";
                label1.Text = " ";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lower_than_ten = 0.1;
            coma = 0;
            if (result != 0)
            {
                first_number = result;
                operator1 = '+';
                label2.Text = Convert.ToString(first_number) + " " + operator1 + " ";
                label1.Text = " ";
            }
            else
            {
                    operator1 = '+';
                label2.Text = Convert.ToString(first_number) + " " + operator1 + " ";
                label1.Text = " ";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button13_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.D1)
           {
                button13.Focus();
                button13.PerformClick();
            }
        }
    }
}
