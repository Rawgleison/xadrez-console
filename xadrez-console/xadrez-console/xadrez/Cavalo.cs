using System;
using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            List<Posicao> posicaos = new List<Posicao>();

            //Para Cima-Dir
            posicaos.AddRange(processamovimentos(qtdLinha: 2, qtdColuna: 1, 1));
            //Para Dir-Cima
            posicaos.AddRange(processamovimentos(qtdLinha: 1, qtdColuna: 2, 1));
            //Para Dir-Baixo
            posicaos.AddRange(processamovimentos(qtdLinha: -1, qtdColuna: 2, 1));
            //Para Baixo-Dir
            posicaos.AddRange(processamovimentos(qtdLinha: -2, qtdColuna: 1, 1));
            //Para Baixo-Esq
            posicaos.AddRange(processamovimentos(qtdLinha: -2, qtdColuna: -1, 1));
            //Para Esq-Baixo
            posicaos.AddRange(processamovimentos(qtdLinha: -1, qtdColuna: -2, 1));
            //Para Esq-Cima
            posicaos.AddRange(processamovimentos(qtdLinha: 1, qtdColuna: -2, 1));
            //Para Cima-Esq
            posicaos.AddRange(processamovimentos(qtdLinha: 2, qtdColuna: -1, 1));

            posicaos.ForEach(p => mat[p.linha, p.coluna] = true);

            return mat;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
