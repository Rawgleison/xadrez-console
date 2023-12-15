using System;
using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            List<Posicao> posicaos = new List<Posicao>();

            //Para Cima
            posicaos.AddRange(processamovimentos(1, 0, 1));
            //Para Cima-Esq
            posicaos.AddRange(processamovimentos(1, 1, 1));
            //Para Esquerda
            posicaos.AddRange(processamovimentos(0, 1, 1));
            //Para Baixo-Esq
            posicaos.AddRange(processamovimentos(-1, 1, 1));
            //Para Baixo
            posicaos.AddRange(processamovimentos(-1, 0, 1));
            //Para Baixo-Dir
            posicaos.AddRange(processamovimentos(-1, -1, 1));
            //Para Direita
            posicaos.AddRange(processamovimentos(0, -1, 1));
            //Para Cima-Dir
            posicaos.AddRange(processamovimentos(1, -1, 1));

            posicaos.ForEach(p => mat[p.linha, p.coluna] = true);

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
