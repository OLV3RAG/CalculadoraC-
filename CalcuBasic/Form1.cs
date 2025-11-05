using CalcuBasic.Entidades;
using CalcuBasic.Negocio;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace CalcuBasic
{
    public partial class Form1 : Form
    {
        bool operacion = true;
        public Form1()
        {
            InitializeComponent();
        }

        Operaciones operaciones = new Operaciones();
        Valores valores = new Valores();
        char operador;

        private void AjustarTamanoTexto()
        {
            int longitud = txtResultado.Text.Length;

            if (longitud < 10)
                txtResultado.Font = new Font("Segoe UI", 28, FontStyle.Regular);
            else if (longitud < 15)
                txtResultado.Font = new Font("Segoe UI", 22, FontStyle.Regular);
            else if (longitud < 20)
                txtResultado.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            else
                txtResultado.Font = new Font("Segoe UI", 14, FontStyle.Regular);
        }

        private void AgregarTexto(string texto)
        {
            string actual = txtResultado.Text;

            if (actual == "0" || actual == "Error")
                actual = "";

            if ("+-x/".Contains(texto))
            {
                if (actual.Length > 0 && "+-x/".Contains(actual[actual.Length - 1].ToString()))
                    return;
            }

            if (texto == "(" && actual.Length > 0)
            {
                char ultimo = actual[actual.Length - 1];
                if (char.IsDigit(ultimo) || ultimo == ')')
                    actual += "x";
            }
            else if (char.IsDigit(texto[0]) && actual.Length > 0)
            {
                char ultimo = actual[actual.Length - 1];
                if (ultimo == ')')
                    actual += "x";
            }

            actual += texto;

            if (actual.All(c => char.IsDigit(c) || c == '.'))
            {
                if (decimal.TryParse(actual, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal numero))
                    actual = numero.ToString("N0", CultureInfo.InvariantCulture);
            }

            txtResultado.Text = actual;
            AjustarTamanoTexto();
        }

        private void btnParentI_Click(object sender, EventArgs e)
        {
            AgregarTexto("(");
        }

        private void btnParentII_Click(object sender, EventArgs e)
        {
            AgregarTexto(")");
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            operador = '%';
            valores.Num1 = Convert.ToDouble(txtResultado.Text);
            txtResultado.Text = "%";
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
            AjustarTamanoTexto();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "7";
            AjustarTamanoTexto();
    
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "8";
            AjustarTamanoTexto();
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "9";
            AjustarTamanoTexto();
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "4";
            AjustarTamanoTexto();
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "5";
            AjustarTamanoTexto();
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "6";
            AjustarTamanoTexto();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "1";
            AjustarTamanoTexto();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "2";
            AjustarTamanoTexto();
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0") txtResultado.Text = "";
            txtResultado.Text = txtResultado.Text + "3";
            AjustarTamanoTexto();
        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            txtResultado.Text = txtResultado.Text + "0";
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            txtResultado.Text = txtResultado.Text + ".";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (operacion == true)
            {
            operador = '/';
            valores.Num1 = Convert.ToDouble(txtResultado.Text);
            }
            else
            {
                valores.Resultado = operaciones.CalcularDiv(valores);
            }
            txtResultado.Text = "/";
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {

       if (operacion == true)
            {
            operador = 'x';
            valores.Num1 = Convert.ToDouble(txtResultado.Text);
            }
       else
            {
                valores.Resultado = operaciones.CalcularMult(valores);
            }
                txtResultado.Text = "x";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            
       if (operacion == true)
            {
            operador = '-';
            valores.Num1 = Convert.ToDouble(txtResultado.Text);
            }
       else
            {
                valores.Resultado = operaciones.CalcularRes(valores);
            }
            txtResultado.Text = "-";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            operador = '+';
            if (operacion == true)
            {
            valores.Num1 = Convert.ToDouble(txtResultado.Text);

            }
           else
            {
                valores.Resultado = operaciones.CalcularSum(valores);
            }
             txtResultado.Text = "+";
        }

        private void btnEq_Click(object sender, EventArgs e)
        {

            string[] splitResultado = txtResultado.Text.Split(operador);
            string num = splitResultado[1];
            valores.Num2 = Convert.ToDouble(num);

            switch (operador)
            {
                case '+':
                    valores.Resultado = operaciones.CalcularSum(valores);
                    txtResultado.Text = $"{valores.Num1 + valores.Num2}";
                    AjustarTamanoTexto();
                    break;

                case '-':
                   valores.Resultado = operaciones.CalcularRes(valores);
                    txtResultado.Text = $"{valores.Num1 - valores.Num2}";
                    AjustarTamanoTexto();
                    break;

                case 'x':
                    valores.Resultado = operaciones.CalcularMult(valores);
                    txtResultado.Text = $"{valores.Num1 * valores.Num2}";
                    AjustarTamanoTexto();
                    break;

                case '/':
                   valores.Resultado = operaciones.CalcularSum(valores);
                    txtResultado.Text = $"{valores.Num1 / valores.Num2}";
                    AjustarTamanoTexto();
                    break;

                case '%':
                    valores.Resultado = operaciones.CalcularPerc(valores);
                    txtResultado.Text = $"{(valores.Num1 * valores.Num2) / 100}";
                    AjustarTamanoTexto();
                    break;
            }
 



        }
    }
}  

    



