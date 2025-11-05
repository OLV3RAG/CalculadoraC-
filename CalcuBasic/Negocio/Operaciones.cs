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
        public int CalcularSum(Valores valores)
        {
            valores.Resultado = (int)(decimal)(valores.Num1 + valores.Num2);
            return valores.Resultado;
        }

        public int CalcularRes(Valores valores)
        {
            valores.Resultado = (int)(decimal)(valores.Num1 - valores.Num2);
            return valores.Resultado;
        }

        public int CalcularMult(Valores valores)
        {
            valores.Resultado = (int)(decimal)(valores.Num1 * valores.Num2);
            return valores.Resultado;
        }

        public int CalcularDiv(Valores valores)
        {
            valores.Resultado = (int)(decimal)(valores.Num1 / valores.Num2);
            return valores.Resultado;
        }

        public int CalcularPerc(Valores valores)
        {
            if (valores.Num2 == 0)
                throw new DivideByZeroException("No se puede dividir entre cero.");
            valores.Resultado = (int)(decimal)(valores.Num1 * valores.Num2) / 100;
            return valores.Resultado;
        }
    }
}
