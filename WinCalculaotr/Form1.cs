using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalculaotr
{
    public partial class Form1 : Form
    {
        Button btnN;        //숫자 버튼
        Button btnO;        //연산자 버튼
        string str;
        int leftvalue = 0;
        int rightvalue = 0;
        static int result = 0;
        bool bFlag = false;     //입력창을 초기화 하기 위한 용도
        bool cFlag = false;     //입력값을 초기화하기 위한 용도
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void button_Click(object sender, EventArgs e)
        { 
            if (cFlag)
            {
                str = "";
                lblCal2.Text = "";
            }
            cFlag = false;

            if (bFlag)   
            { 
                lblCal.Text = "";
            }
            bFlag = false;

            btnN = (Button)sender;
            str += btnN.Text;
            lblCal.Text += btnN.Text;

            if (lblCal2.Text.Length > 0)
            {
                leftvalue = int.Parse(str.Substring(0, str.LastIndexOf(btnO.Text)));
                rightvalue = int.Parse(str.Substring(str.LastIndexOf(btnO.Text) + 1));
                result = Math(leftvalue, rightvalue, btnO.Text);
            }
           
        }

        private void button14_Click(object sender, EventArgs e)     //지우는 버튼 CE
        {
            str = "";
            lblCal.Text = str;
            lblCal2.Text = str;
        }

       
        private void Operator(object sender, EventArgs e)   //연산자 함수
        {
            btnO = (Button)sender;
            str += btnO.Text;
            lblCal2.Text = str;
            //다항 연산자만 할 수 있으믄 된다
            
            lblCal.Text = result.ToString();
            bFlag = true;
            cFlag = false;

        }

        private int Math(int a, int b, string Yeonsan)      //실제 연산을 하는 함수
        {
            switch (Yeonsan)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "%":
                    return a % b;
            }
            return 0;
        }

        private void Function(string Yeonsan)       //결과 계산 함수
        {
            
            leftvalue = int.Parse(str.Substring(0, str.LastIndexOf(Yeonsan)));
            rightvalue = int.Parse(str.Substring(str.LastIndexOf(Yeonsan)+1)); 
            result = Math(leftvalue, rightvalue, Yeonsan);
            lblCal.Text = (result).ToString();
            str = result.ToString();
        }



        private void button15_Click(object sender, EventArgs e)     //결과값 계산        이후 연산자를 누르면 계속 진행, 숫자키ㅗ드르르 누르면 초기화
        {

            try
            {
                lblCal2.Text = str + "=";

                if (btnO.Text == "+")
                {
                    Function("+");
                }
                else if (btnO.Text == "-")
                {
                    Function("-");
                }

                else if (btnO.Text == "*")
                {
                    Function("*");
                }

                else
                {
                    Function("%");
                }

                bFlag = true;
                cFlag = true;
            }
            catch (Exception)
            {

            }


        }
    }
}
