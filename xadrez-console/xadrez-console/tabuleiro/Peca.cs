using System.Collections.Generic;

namespace tabuleiro
{
    abstract class Peca
    {
        public Cor cor { get; protected set; }
        public Posicao posicao { get; set; }
        public int QtdMovimentos { get; set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.cor = cor;
            this.posicao = null;
            this.QtdMovimentos = 0;
            this.Tabuleiro = tabuleiro;
        }

        public bool podeMover(Posicao pos, bool captura = true)
        {
            Peca p = this.Tabuleiro.peca(pos);
            return (p == null) || ((p.cor != this.cor) && captura);
        }

        public bool podeMoverPara(Posicao destino)
        {
            return MovimentosPossiveis()[destino.linha, destino.coluna];
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int l = 0; l < this.Tabuleiro.Linhas; l++)
            {
                for (int c = 0; c < this.Tabuleiro.Colunas; c++)
                {
                    if (mat[l, c])
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        protected List<Posicao> processamovimentos(int qtdLinha, int qtdColuna, int qtdCasas, bool captura = true)
        {
            List<Posicao> posicaos = new List<Posicao>();
            for (int i = 1; i <= qtdCasas; i++)
            {
                Posicao p = new Posicao(this.posicao.linha + (i * qtdLinha), this.posicao.coluna + (i * qtdColuna));
                if (this.Tabuleiro.posicaoValida(p) && podeMover(p, captura))
                {
                    posicaos.Add(p);
                }

                if (this.Tabuleiro.peca(p) != null)
                {
                    break;
                }
            }
            return posicaos;
        }

        public abstract bool[,] MovimentosPossiveis();
    }

}
