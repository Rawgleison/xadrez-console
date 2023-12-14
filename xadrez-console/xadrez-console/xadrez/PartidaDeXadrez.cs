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
        public bool emXeque { get; private set; }
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

        public Peca movimentarPeca(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            Peca pecaCapiturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
            if(pecaCapiturada != null)
            {
                pecasCapituradas.Add(pecaCapiturada);
            }

            return pecaCapiturada;
        }

        public void retornarPeca(Posicao origem, Posicao destino, Peca pecaCapiturada)
        {
            Peca peca = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, origem);
            if(pecaCapiturada != null)
            {
                tabuleiro.colocarPeca(pecaCapiturada, destino);
                pecasCapituradas.Remove(pecaCapiturada);
            }
        }

        public void realizarJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCap = movimentarPeca(origem, destino);
            if (estaEmXeque(jogadorAtual))
            {
                retornarPeca(origem, destino, pecaCap);
                throw new TabuleiroException("Você não pode ser colocar em xeque.");
            }
            turno++;
            mudaJogador();

            emXeque = estaEmXeque(jogadorAtual);
        }


        private void mudaJogador()
        {
            jogadorAtual = adversario(jogadorAtual);
        }

        public void colocarPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecasEmJogo.Add(peca);
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            var pecas = getPecasEmJogo(adversario(cor));
            foreach (Peca peca in pecas)
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (peca.MovimentosPossiveis()[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }

            return false;
        }

        public Cor adversario(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preto;
            }
            else
            {
                return Cor.Branca;
            }
        }

        public Peca Rei(Cor cor)
        {
            var pecas = getPecasEmJogo(cor);
            foreach (Peca peca in pecas)
            {
                if(peca is Rei)
                {
                    return peca;
                }
            }
            throw new TabuleiroException("Nenhum rei enontrado para a cor" + cor);
        }

        public List<Peca> getPecasEmJogo(Cor cor)
        {
            return pecasEmJogo.FindAll(p => p.cor == cor);
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
