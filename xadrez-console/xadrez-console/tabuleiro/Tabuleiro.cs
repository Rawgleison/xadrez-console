using System.Collections.Generic;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                return null;
            }
            return pecas[pos.linha, pos.coluna];
        }



        public void colocarPeca(Peca p, Posicao pos)
        {
            validarPosicao(pos);
            if(peca(pos) != null)
            {
                throw new TabuleiroException("Peça já existe nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (!existePeca(pos))
            {
                return null;
            }

            Peca peca = this.peca(pos);
            peca.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return peca;
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public bool posicaoValida(Posicao pos)
        {
            return (pos.linha >= 0 && pos.linha < Linhas && pos.coluna >= 0 && pos.coluna < Colunas);
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }

        public List<Posicao> getListPosicoes()
        {
            List<Posicao> posList = new List<Posicao>();
            for (int l = 0; l < Linhas; l++)
            {
                for (int c = 0; c < Colunas; c++)
                {
                    posList.Add(new Posicao(l, c));
                }
            }
            return posList;
        }
    }
}
