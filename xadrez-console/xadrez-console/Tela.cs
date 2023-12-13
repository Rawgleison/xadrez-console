using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int l = 0; l < tab.linhas; l++)
            {
                Console.Write((8 - l) + " ");
                for (int c = 0; c < tab.colunas; c++)
                {
                    if (tab.peca(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(l, c));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
                Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Branca)
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
