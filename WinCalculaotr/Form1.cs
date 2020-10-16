using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalculaotr
{
    public partial class Form1 : Form
    {
        Button btn;
        string str = "";
        int leftvalue = 0;
        int rightvalue = 0;
        static int result = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "계산기";
        }


        private void button_Click(object sender, EventArgs e)
        {
               
            if (str.Contains("+"))      
            {
               
                Button btn = (Button)sender;
                lblCal.Text += (btn.Text);
                str += btn.Text;
            }
            else if(str.Contains("+") == false)
            {
                Button btn = (Button)sender;
                lblCal.Text += (btn.Text);
                str += btn.Text;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            lblCal.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblCal.Text += (btn.Text);
        }

        private void Operator(object sender, EventArgs e)
        {
            btn = (Button)sender;
            lblCal.Text += (btn.Text);
            str += btn.Text;

        }

        private void button15_Click(object sender, EventArgs e)     //결과값 계산
        {
            //각각의 연산에 대해 연산자 이전의 것과 후의 것을 연산
            if (btn.Text == "+")
            {
                if (result == 0)        //처음 계산할 때
                {
                    leftvalue = int.Parse(str.Substring(0, str.LastIndexOf("+")));
                    rightvalue = int.Parse(str.Substring(str.LastIndexOf("+") + 1));
                    result = (leftvalue + rightvalue);
                    lblCal.Text = (leftvalue + rightvalue).ToString();
                    str += result.ToString();


                }
                else
                {
                    leftvalue = result;
                    rightvalue = int.Parse(str.Substring(str.LastIndexOf("+") + 1));
                    result = (leftvalue + rightvalue);
                    lblCal.Text = (leftvalue + rightvalue).ToString();
                    str += result.ToString();
                }
                

            }
            else if (btn.Text == "-")
            {
                leftvalue = int.Parse(str.Substring(0, str.LastIndexOf("-")));
                rightvalue = int.Parse(str.Substring(str.LastIndexOf("-") + 1));

                lblCal.Text = (leftvalue + rightvalue).ToString();
            }

            else if (btn.Text == "*")
            {
                leftvalue = int.Parse(str.Substring(0, str.LastIndexOf("*")));
                rightvalue = int.Parse(str.Substring(str.LastIndexOf("*") + 1));

                lblCal.Text = (leftvalue + rightvalue).ToString();
            }

            else
            {
                leftvalue = int.Parse(str.Substring(0, str.LastIndexOf("%")));
                rightvalue = int.Parse(str.Substring(str.LastIndexOf("%") + 1));

                lblCal.Text = (leftvalue + rightvalue).ToString();

            }
        }
    }
}
