using System;
using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; set; }
        public Cor jogadorAtual { get; set; }
        public bool finalizada { get; set; }
        private List<Peca> pecasEmJogo { get; set; }
        private List<Peca> pecasCapituradas { get; set; }
        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            finalizada = false;
            pecasEmJogo = new List<Peca>();
            pecasCapituradas = new List<Peca>();
            colocarPecas();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            if (!tabuleiro.existePeca(pos))
            {
                throw new TabuleiroException("Não existe peça na casa de origem.");
            }

            if(p.cor != jogadorAtual)
            {
                throw new TabuleiroException("A peça scolhida não é a cor do jogador atual.");
            }

            if (!p.existeMovimentosPossiveis())
            {
                throw new TabuleiroException("A peça escolhida está trancada!");
            }

        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tabuleiro.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Jogada inválida.");
            }
        }

        public void movimentarPeca(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            Peca pecaCapiturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
            if(pecaCapiturada != null)
            {
                pecasCapituradas.Add(pecaCapiturada);
            }
        }

        public void realizarJogada(Posicao origem, Posicao destino)
        {
            movimentarPeca(origem, destino);
            turno++;
            mudaJogador();
        }

        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preto;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public void colocarPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecasEmJogo.Add(peca);
        }

        public List<Peca> getPegasCapituradas(Cor cor)
        {
            return pecasCapituradas.FindAll(p => p.cor == cor);
        }

        public void colocarPecas()
        {
            colocarPeca('a', 8,new Torre(tabuleiro, Cor.Preto));
            colocarPeca('d', 8,new Rei(tabuleiro, Cor.Preto));
            colocarPeca('h', 8,new Torre(tabuleiro, Cor.Preto));

            colocarPeca('a', 1,new Torre(tabuleiro, Cor.Branca));
            colocarPeca('e', 1,new Rei(tabuleiro, Cor.Branca));
            colocarPeca('h', 1,new Torre(tabuleiro, Cor.Branca));
        }
    }
}
