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
    public partial class Form1 : Form
    {
        //Variable
        double num1 = 0.0d;
        double num2 = 0.0d;
        string operation = string.Empty;


        public Form1()
        {
            InitializeComponent();

        }

        //Tạo đối tượng
        DelegateAndEvent my = new DelegateAndEvent();

        #region  Event click

        private void number_Click(object sender, EventArgs e)
        {
            if (txtCalculate.Text == "0")
                txtCalculate.Text = string.Empty;
            Button button = (Button)sender;
            txtCalculate.Text += button.Text;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = "0";
            txtDisplay.Text = string.Empty;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtCalculate.Text.Length >= 1)
            {
                txtCalculate.Text = txtCalculate.Text.Remove(txtCalculate.Text.Length - 1);
                if (string.IsNullOrEmpty(txtCalculate.Text)) //Trường hợp ko còn kí tự nào.
                    txtCalculate.Text = "0";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!txtCalculate.Text.Contains("."))
                txtCalculate.Text += ".";
        }

        private void operations_Click(object sender, EventArgs e)
        {
            my.ProcessWhenClickEvent += ProcessWhenClickHandler;
            my.OnProcessWhenClickEvent();

            Button button = (Button)sender;
            operation = button.Text;

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            num2 = double.Parse(txtCalculate.Text);

            if (!string.IsNullOrEmpty(operation))
            {
                my.CalculationEvent += CalculationHandler;
                my.OnCalculation(num1, num2, operation);
                txtDisplay.Text = num1.ToString() + operation + num2.ToString();

            }
            //my.ProcessWhenClickEvent += null;//ProcessWhenClickHandler;


        }

        #endregion

        #region  Phương thức xử lý sự kiện
        private void CalculationHandler(double a, double b, string op)
        {
            double result = 0.0d;
            switch (op)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "x":
                    result = a * b;
                    break;
                case "/":
                    if (b == 0)
                    {
                        MessageBox.Show("Không thể chia cho số 0.");
                        return;
                    }
                    result = a / b;
                    break;

                default:
                    break;
            }
            txtCalculate.Text = result.ToString();
        }

        //Phương thức xử lý sự kiện
        public void ProcessWhenClickHandler(object sender, EventArgs e)
        {
            num1 = double.Parse(txtCalculate.Text);
            txtCalculate.Text = "0";
        }


        #endregion


    }
}

