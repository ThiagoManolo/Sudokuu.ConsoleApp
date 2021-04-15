using System;
using System.IO;

namespace Sudoku.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string sudokuValido = @"1 3 2 5 7 9 4 6 8
                                    4 9 8 2 6 1 3 7 5
                                    7 5 6 3 8 4 2 1 9
                                    6 4 3 1 5 8 7 9 2
                                    5 2 1 7 9 3 8 4 6
                                    9 8 7 4 2 6 5 3 1
                                    2 1 4 9 3 5 6 8 7
                                    3 6 5 8 1 7 9 2 4
                                    8 7 9 6 4 2 1 5 3";


            string[,] linhasSudoku = ObterSudokuEmLinhas(sudokuValido);

            string[,] colunasSudoku = ObterSudokuEmColunas(linhasSudoku);

            string[,] blocosSudoku = ObterSudokuEmBlocos(linhasSudoku);
          
            bool sudokuEhValido = ValidarSudoku(linhasSudoku) && ValidarSudoku(colunasSudoku) && ValidarSudoku(blocosSudoku);          

            if (sudokuEhValido)
                Console.WriteLine("SIM");
            else
                Console.WriteLine("NÃO");
            Console.ReadLine();
        }


        private static bool ValidarSudoku(string[,] matrizSudoku)
        {
            int numeroDuplicados = 0;

            for (int k = 0; k < matrizSudoku.GetLength(0); k++)
            {
                for (int i = 0; i < matrizSudoku.GetLength(1); i++)
                {
                    for (int j = i + 1; j < matrizSudoku.GetLength(1); j++)
                    {
                        string numeroSelecionado = matrizSudoku[k, i];

                        string numeroComparado = matrizSudoku[k, j];

                        if (numeroSelecionado == numeroComparado)
                        {
                            numeroDuplicados++;
                        }
                    }
                }
            }
            return numeroDuplicados == 0;
        }


        private static string[,] ObterSudokuEmBlocos(string[,] linhasSudoku)
        {
            string[,] blocosSudoku = new string[9, 9];

            for (int posicaoXBloco = 0; posicaoXBloco < blocosSudoku.GetLength(0); posicaoXBloco++)
            {
                int posicaoYBloco = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int restoDivisao = posicaoXBloco % 3;

                        int posicaoXlinhas = i + (restoDivisao * 3);

                        int resultadoDivisao = posicaoXBloco / 3;

                        int posicaoYLinhas = j + (resultadoDivisao * 3);

                        string valor = linhasSudoku[posicaoXlinhas, posicaoYLinhas];

                        blocosSudoku[posicaoXBloco, posicaoYBloco] = valor;

                        posicaoYBloco++;
                    }
                }
            }

            return blocosSudoku;
        }

       
        private static string[,] ObterSudokuEmColunas(string[,] linhasSudoku)
        {
            string[,] colunasSudoku = new string[9, 9];

            for (int y = 0; y < colunasSudoku.GetLength(0); y++)
            {
                for (int x = 0; x < colunasSudoku.GetLength(1); x++)
                {
                    string valor = linhasSudoku[x, y];

                    colunasSudoku[x, y] = valor;
                }
            }

            return colunasSudoku;
        }

        private static string[,] ObterSudokuEmLinhas(string sudokuValido)
        {
            string[,] linhasSudoku = new string[9, 9];

            using (StringReader sudokuReader = new StringReader(sudokuValido))
            {
                string linhaSudoku = "";

                for (int x = 0; x < linhasSudoku.GetLength(0); x++)
                {
                    linhaSudoku = sudokuReader.ReadLine();

                    string[] valores = linhaSudoku.Trim().Split();

                    for (int y = 0; y < linhasSudoku.GetLength(1); y++)
                    {
                        linhasSudoku[x, y] = valores[y];
                    }
                }
            }

            return linhasSudoku;
        }

        private static void ImprimirMatriz(string[,] linhasSudoku)
        {
            for (int x = 0; x < linhasSudoku.GetLength(0); x++)
            {
                for (int y = 0; y < linhasSudoku.GetLength(1); y++)
                {
                    string valor = linhasSudoku[x, y];
                    System.Console.WriteLine($"x:{x} y:{y} = {valor}");
                }
            }

            Console.WriteLine($"Numero de itens: {linhasSudoku.Length}");
        }


    }
}
