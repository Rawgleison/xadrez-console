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
            bool[,] mat = new bool[this.Tabuleiro.Linhas,this.Tabuleiro.Colunas];


            //Para Cima
            for (int l = 1; l <= this.Tabuleiro.Linhas; l++)
            {
                Posicao p = new Posicao(this.posicao.linha + l, this.posicao.coluna);
                if (this.Tabuleiro.posicaoValida(p) && podeMover(p))
                {
                    mat[p.linha, p.coluna] = true;
                }

                if (this.Tabuleiro.peca(p) != null)
                {
                    break;
                }
            }
            //Para baixo
            for (int l = 1; l <= this.Tabuleiro.Linhas; l++)
            {
                Posicao p = new Posicao(this.posicao.linha - l, this.posicao.coluna);
                if (this.Tabuleiro.posicaoValida(p) && podeMover(p))
                {
                    mat[p.linha, p.coluna] = true;
                }

                if (this.Tabuleiro.peca(p) != null)
                {
                    break;
                }
            }
            //Para Direita
            for (int c = 1; c <= this.Tabuleiro.Colunas; c++)
            {
                Posicao p = new Posicao(this.posicao.linha, this.posicao.coluna + c);
                if (this.Tabuleiro.posicaoValida(p) && podeMover(p))
                {
                    mat[p.linha, p.coluna] = true;
                }

                if (this.Tabuleiro.peca(p) != null)
                {
                    break;
                }
            }
            //Para Esquerda
            for (int c = 1; c <= this.Tabuleiro.Colunas; c++)
            {
                Posicao p = new Posicao(this.posicao.linha, this.posicao.coluna - c);
                if (this.Tabuleiro.posicaoValida(p) && podeMover(p))
                {
                    mat[p.linha, p.coluna] = true;
                }

                if (this.Tabuleiro.peca(p) != null)
                {
                    break;
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
