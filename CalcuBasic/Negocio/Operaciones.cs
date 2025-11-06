using CalcuBasic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcuBasic.Negocio
{
    public class Operaciones
    {
        public double CalcularSum(Valores valores)
        {
            valores.Resultado = valores.Num1 + valores.Num2;
            return valores.Resultado;
        }

        public double CalcularRes(Valores valores)
        {
            valores.Resultado = (valores.Num1 - valores.Num2);
            return valores.Resultado;
        }

        public double CalcularMult(Valores valores)
        {
            valores.Resultado = (valores.Num1 * valores.Num2);
            return valores.Resultado;
        }

        public double CalcularDiv(Valores valores)
        {
            valores.Resultado = (valores.Num1 / valores.Num2);
            return valores.Resultado;
        }

        public double CalcularPerc(Valores valores)
        {
            if (valores.Num2 == 0)
                throw new DivideByZeroException("No se puede dividir entre cero.");
            valores.Resultado = (valores.Num1 * valores.Num2) / 100;
            return valores.Resultado;
        }
    }
}
