using System;

namespace Calculadora2
{
    public class Calculo
    {
        public double primeiroNumero;
        public double segundoNumero;
        public string operador;
        public double resultado;

        public void Calcular()
        {
            if (operador == "+")
                resultado = primeiroNumero + segundoNumero;

            else if (operador == "-")
                resultado = primeiroNumero - segundoNumero;

            else if (operador == "*")
                resultado = primeiroNumero * segundoNumero;

            else if (operador == "/")
                resultado = primeiroNumero / segundoNumero;
        }
        public string ObtemDescricao()
        {
            return $"{primeiroNumero} {operador} {segundoNumero} = {resultado}";
        }
    }
}