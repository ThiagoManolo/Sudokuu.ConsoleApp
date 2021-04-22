using System;


namespace Calculadora2
{
    class ProgramaOrientadoObjetos
    {      
        static void Main(string[] args)
        {

            Calculadora minhaCalculadora = new Calculadora();

            while (true)
            {
                string opcao = Menu();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    break;

                else if (opcao == "1")
                    RealizarCalculos(minhaCalculadora);

                else if (opcao == "2")
                    VisualizarHistoricoCalculos(minhaCalculadora);

                Console.Clear();
            }
        }

        
        private static void VisualizarHistoricoCalculos(Calculadora minhaCalculadora)
        {
            Console.Clear();

            Console.WriteLine("Visualizando o histórico de calculos...\n");

            string[] calculosRealizados = minhaCalculadora.CalculosRealizados();

            foreach (string calculoRealizado in calculosRealizados)
                Console.WriteLine(calculoRealizado);

            Console.ReadLine();
        }

        
        private static void RealizarCalculos(Calculadora minhaCalculadora)
        {
            double resultado;
            string mensagem;
            bool conseguiuCalcular;
            do
            {
                Console.Clear();

                Console.Write("Digite o primeiro valor:");
                minhaCalculadora.primeiroValor = Console.ReadLine();

                Console.Write("Digite o segundo valor:");
                minhaCalculadora.segundoValor = Console.ReadLine();

                Console.Write("Digite o operador [+ - * / ]: ");
                minhaCalculadora.operador = Console.ReadLine();

                conseguiuCalcular = minhaCalculadora.TentaCalcular(out resultado, out mensagem);

                if (conseguiuCalcular == false)
                {
                    Console.WriteLine(mensagem);
                    Console.ReadLine();
                }

            } while (conseguiuCalcular == false);

            Console.WriteLine($"O resultado é: {resultado}");

            Console.ReadLine();
        }

        
        private static string Menu()
        {
            Console.WriteLine("Calculadora 2.0\n");

            Console.WriteLine("Digite 1 para realizar calculos");

            Console.WriteLine("Digite 2 para visualizar o histórico dos calculos");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }

}