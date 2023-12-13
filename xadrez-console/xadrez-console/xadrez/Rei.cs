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
            int linha = this.posicao.linha;
            int col = this.posicao.coluna;
            List<Posicao> posList = this.Tabuleiro.getListPosicoes();

            var posListPerm = posList.FindAll(p => (Math.Abs(p.linha - linha) < 2) && (Math.Abs(p.coluna - col) < 2));

            posListPerm.ForEach(p =>
            {
                if(this.Tabuleiro.posicaoValida(p) && podeMover(p))
                {
                    mat[p.linha, p.coluna] = true;
                }
            });
            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
