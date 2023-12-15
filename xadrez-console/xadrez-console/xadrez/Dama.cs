using System;
using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            List<Posicao> posicaos = new List<Posicao>();

            //Para Cima
            posicaos.AddRange(processamovimentos(1, 0, this.Tabuleiro.Linhas));
            //Para Cima-Esq
            posicaos.AddRange(processamovimentos(1, 1, this.Tabuleiro.Linhas));
            //Para Esquerda
            posicaos.AddRange(processamovimentos(0, 1, this.Tabuleiro.Linhas));
            //Para Baixo-Esq
            posicaos.AddRange(processamovimentos(-1, 1, this.Tabuleiro.Linhas));
            //Para Baixo
            posicaos.AddRange(processamovimentos(-1, 0, this.Tabuleiro.Linhas));
            //Para Baixo-Dir
            posicaos.AddRange(processamovimentos(-1, -1, this.Tabuleiro.Linhas));
            //Para Direita
            posicaos.AddRange(processamovimentos(0, -1, this.Tabuleiro.Linhas));
            //Para Cima-Dir
            posicaos.AddRange(processamovimentos(1, -1, this.Tabuleiro.Linhas));

            posicaos.ForEach(p => mat[p.linha, p.coluna] = true);

            return mat;
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
