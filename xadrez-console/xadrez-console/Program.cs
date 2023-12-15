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
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.finalizada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tabuleiro);
                        Console.WriteLine();
                        Tela.imprimirPartida(partida);
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posPossiveis = partida.tabuleiro.peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tabuleiro, posPossiveis);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizarJogada(origem, destino);
                    }catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write("Pressione Enter pra continuar...");
                        Console.ReadKey();
                    }
                }

                Console.Clear();
                Console.WriteLine("********** XEQUE MATE!!!!*************");
                Tela.imprimirTabuleiro(partida.tabuleiro);
                Console.WriteLine();
                Tela.imprimirPartida(partida);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            Console.ReadLine();
        }

    }
}
