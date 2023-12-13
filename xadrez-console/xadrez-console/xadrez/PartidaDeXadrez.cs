using System;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; set; }
        public Cor jogadorAtual { get; set; }
        public bool finalizada { get; set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            finalizada = false;
            colocarPecas();
        }

        public void movimentarPeca(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            Peca pecaCapiturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
        }

        public void colocarPecas()
        {
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new PosicaoXadrez('a', 8).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preto),   new PosicaoXadrez('d', 8).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new PosicaoXadrez('h', 8).toPosicao());

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branca),   new PosicaoXadrez('e', 1).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());
        }
    }
}
