using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            List<Posicao> posicaos = new List<Posicao>();

            //Para Cima-Dir
            posicaos.AddRange(processamovimentos(1, 1, this.Tabuleiro.Colunas));
            //Para Baixo-Dir
            posicaos.AddRange(processamovimentos(-1, 1, this.Tabuleiro.Colunas));
            //Para Baixo-Esq
            posicaos.AddRange(processamovimentos(-1,- 1, this.Tabuleiro.Colunas));
            //Para Cima-Esq
            posicaos.AddRange(processamovimentos(1, -1, this.Tabuleiro.Colunas));

            posicaos.ForEach(p => mat[p.linha, p.coluna] = true);

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
