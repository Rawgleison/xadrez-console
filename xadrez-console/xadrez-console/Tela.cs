using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int l = 0; l < tab.Linhas; l++)
            {
                Console.Write((tab.Linhas - l) + " ");
                for (int c = 0; c < tab.Colunas; c++)
                {
                    Peca p = tab.peca(l, c);
                    imprimirPeca(p);
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("-");
            }
            else if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = oldColor;
            }
            Console.Write(" ");
        }

        internal static void imprimirTabuleiro(Tabuleiro tab, bool[,] posPossiveis)
        {
            for (int l = 0; l < tab.Linhas; l++)
            {
                Console.Write((tab.Linhas - l) + " ");
                for (int c = 0; c < tab.Colunas; c++)
                {
                    Peca p = tab.peca(l, c);
                    ConsoleColor fundoOriginal = Console.BackgroundColor;
                    if (posPossiveis[l, c])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    imprimirPeca(p);
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capituradas");
            Console.Write("Brancas: ");
            imprimirList(partida.getPegasCapituradas(Cor.Branca));

            Console.Write("Pretas: ");
            ConsoleColor oldCor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirList(partida.getPegasCapituradas(Cor.Preto));
            Console.ForegroundColor = oldCor;

            Console.WriteLine($"Turno: {partida.turno}");
            Console.WriteLine($"Peça a ser jogada: {partida.jogadorAtual}");
            if (partida.emXeque)
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PARTIDA EM XEQUE");
                Console.ForegroundColor = oldColor;
            }

        }

        private static void imprimirList(List<Peca> pecas)
        {
            Console.Write("[");
            pecas.ForEach(p =>
            {
                Console.Write(p + " ");
            });
            Console.WriteLine("]");
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string posXadrez = Console.ReadLine();
            char coluna = posXadrez[0];
            int linha = int.Parse("" + posXadrez[1]);
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
