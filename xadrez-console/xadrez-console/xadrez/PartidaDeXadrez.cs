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
            Peca peca = retirarPeca(origem);
            Peca pecaCapiturada = retirarPeca(destino);
            colocarPeca(peca, destino);
            if(pecaCapiturada != null)
            {
                pecasCapituradas.Add(pecaCapiturada);
            }

            return pecaCapiturada;
        }

        public void retornarPeca(Posicao origem, Posicao destino, Peca pecaCapiturada)
        {
            Peca peca = retirarPeca(destino);
            colocarPeca(peca, origem);
            if(pecaCapiturada != null)
            {
                colocarPeca(pecaCapiturada, destino);
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

            emXeque = estaEmXeque(adversario(jogadorAtual));

            if (emXeque)
            {
                finalizada = xequeMate(adversario(jogadorAtual));
            }

            turno++;
            mudaJogador();

        }

        public bool xequeMate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }

            var pecas = getPecasEmJogo(cor);
            foreach (Peca peca in pecas)
            {
                Posicao origem = peca.posicao;
                bool[,] mat = peca.MovimentosPossiveis();
                for (int l = 0; l < tabuleiro.Linhas; l++)
                {
                    for (int c = 0; c < tabuleiro.Colunas; c++)
                    {
                        if (mat[l, c])
                        {
                            Posicao destino = new Posicao(l, c);
                            Peca pecaCap = movimentarPeca(origem, destino);
                            bool xequeMate = estaEmXeque(cor);
                            retornarPeca(origem, destino, pecaCap);
                            if (!xequeMate)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }


        private void mudaJogador()
        {
            jogadorAtual = adversario(jogadorAtual);
        }

        public void colocarPeca(char coluna, int linha, Peca peca)
        {
            colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
        }

        public void colocarPeca(Peca peca, Posicao pos)
        {
            tabuleiro.colocarPeca(peca, pos);
            pecasEmJogo.Add(peca);
        }

        public Peca retirarPeca(Posicao pos)
        {
             Peca peca = tabuleiro.retirarPeca(pos);
            pecasEmJogo.Remove(peca);
            return peca;
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

        public List<Peca> getPecasCapituradas(Cor cor)
        {
            return pecasCapituradas.FindAll(p => p.cor == cor);
        }

        public void colocarPecas()
        {
            colocarPeca('a', 7, new Peao(tabuleiro, Cor.Preto));
            colocarPeca('b', 7, new Peao(tabuleiro, Cor.Preto));
            colocarPeca('c', 7, new Peao(tabuleiro, Cor.Preto));
            colocarPeca('d', 7, new Peao(tabuleiro, Cor.Preto));
            colocarPeca('e', 7, new Peao(tabuleiro, Cor.Preto));
            colocarPeca('f', 7, new Peao(tabuleiro, Cor.Preto));
            colocarPeca('g', 7, new Peao(tabuleiro, Cor.Preto));
            colocarPeca('h', 7, new Peao(tabuleiro, Cor.Preto));

            colocarPeca('d', 8, new Rei(tabuleiro, Cor.Preto));
            colocarPeca('e', 8, new Dama(tabuleiro, Cor.Preto));
            colocarPeca('f', 8, new Bispo(tabuleiro, Cor.Preto));
            colocarPeca('c', 8, new Bispo(tabuleiro, Cor.Preto));
            colocarPeca('g', 8, new Cavalo(tabuleiro, Cor.Preto));
            colocarPeca('b', 8, new Cavalo(tabuleiro, Cor.Preto));
            colocarPeca('h', 8, new Torre(tabuleiro, Cor.Preto));
            colocarPeca('a', 8, new Torre(tabuleiro, Cor.Preto));

            colocarPeca('a', 2, new Peao(tabuleiro, Cor.Branca));
            colocarPeca('b', 2, new Peao(tabuleiro, Cor.Branca));
            colocarPeca('c', 2, new Peao(tabuleiro, Cor.Branca));
            colocarPeca('d', 2, new Peao(tabuleiro, Cor.Branca));
            colocarPeca('e', 2, new Peao(tabuleiro, Cor.Branca));
            colocarPeca('f', 2, new Peao(tabuleiro, Cor.Branca));
            colocarPeca('g', 2, new Peao(tabuleiro, Cor.Branca));
            colocarPeca('h', 2, new Peao(tabuleiro, Cor.Branca));


            colocarPeca('d', 1, new Rei(tabuleiro, Cor.Branca));
            colocarPeca('e', 1, new Dama(tabuleiro, Cor.Branca));
            colocarPeca('f', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarPeca('c', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarPeca('g', 1, new Cavalo(tabuleiro, Cor.Branca));
            colocarPeca('b', 1, new Cavalo(tabuleiro, Cor.Branca));
            colocarPeca('h', 1, new Torre(tabuleiro, Cor.Branca));
            colocarPeca('a', 1, new Torre(tabuleiro, Cor.Branca));
        }
    }
}
