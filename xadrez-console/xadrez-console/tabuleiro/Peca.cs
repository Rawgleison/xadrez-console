namespace tabuleiro
{
    class Peca
    {
        public Cor cor { get; protected set; }
        public Posicao posicao { get; set; }
        public int qtdMovimentos { get; set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.cor = cor;
            this.posicao = null;
            this.qtdMovimentos = 0;
            this.tabuleiro = tabuleiro;
        }
    }
}
