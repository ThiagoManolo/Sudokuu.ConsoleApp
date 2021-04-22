using System;

namespace Calculadora2
{
    public class Calculadora
    {
        public string primeiroValor;
        public string segundoValor;
        public string operador;
        public string[] calculosRealizados = new string[100];

        public bool TentaCalcular(out double resultado, out string mensagem)
        {
            double primeiroNumero, segundoNumero;
            mensagem = "";
            resultado = 0;

            //validações
            if (double.TryParse(primeiroValor, out primeiroNumero) == false)
            {
                mensagem = "Primeiro número inválido";
                return false;
            }
            if (double.TryParse(segundoValor, out segundoNumero) == false)
            {
                mensagem = "Segundo número inválido";
                return false;
            }
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                mensagem = "Operador inválido";
                return false;
            }
            if (operador == "/" && segundoNumero == 0)
            {
                mensagem = "Divisão por zero";
                return false;
            }

            Calculo novoCalculo = new Calculo();
            novoCalculo.primeiroNumero = primeiroNumero;
            novoCalculo.segundoNumero = segundoNumero;
            novoCalculo.operador = operador;
            novoCalculo.Calcular();
            resultado = novoCalculo.resultado;

            calculosRealizados[ObterPosicaoVazia()] = novoCalculo.ObtemDescricao();

            return true;
        }

        public int ObterPosicaoVazia()
        {
            int posicaoVazia = 0;

            for (int i = 0; i < calculosRealizados.Length; i++)
            {
                if (calculosRealizados[i] == null)
                {
                    posicaoVazia = i; break;
                }
            }
            return posicaoVazia;
        }

        public int QuantidadeCalculosRealizados()
        {
            int qtdCalculos = 0;

            for (int i = 0; i < calculosRealizados.Length; i++)
            {
                if (calculosRealizados[i] != null)
                {
                    qtdCalculos++;
                }
            }
            return qtdCalculos;
        }

        public string[] CalculosRealizados()
        {
            int qtd = QuantidadeCalculosRealizados();

            string[] calculosRealizadosAux = new string[qtd];

            for (int i = 0; i < qtd; i++)
            {
                calculosRealizadosAux[i] = calculosRealizados[i];
            }

            return calculosRealizadosAux;
        }
    }
}