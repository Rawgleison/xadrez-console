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

        public bool podeMover(Posicao pos)
        {
            Peca p = this.Tabuleiro.peca(pos);
            return (p == null) || (p.cor != this.cor);
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
        public abstract bool[,] MovimentosPossiveis();
    }

}
