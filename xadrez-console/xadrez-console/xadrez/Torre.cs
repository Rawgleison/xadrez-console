using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            List<Posicao> posicaos = new List<Posicao>();

            //Para Cima
            posicaos.AddRange(processamovimentos(1, 0, this.Tabuleiro.Colunas));
            //Para Baixo
            posicaos.AddRange(processamovimentos(-1, 0, this.Tabuleiro.Colunas));
            //Para Direita
            posicaos.AddRange(processamovimentos(0, 1, this.Tabuleiro.Colunas));
            //Para Esquerda
            posicaos.AddRange(processamovimentos(0, -1, this.Tabuleiro.Colunas));

            posicaos.ForEach(p => mat[p.linha, p.coluna] = true);

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
