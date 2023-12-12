using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                Console.WriteLine(pos);

                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(0, 0));
                tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preto), new Posicao(1, 3));
                tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(7,3));

                Tela.imprimirTabuleiro(tabuleiro);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine("Erro: "+e.Message);
            }
            Console.ReadLine();
        }

    }
}
