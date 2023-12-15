using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            List<Posicao> posicaos = new List<Posicao>();

            //Para Cima
            posicaos.AddRange(processamovimentos(qtdLinha: cor == Cor.Branca ? -1:1, qtdColuna: 0, qtdCasas: 1, captura: false));
            //Para Cima duas casa
            if(QtdMovimentos == 0)
            {
              posicaos.AddRange(processamovimentos(qtdLinha: cor == Cor.Branca ? -2 : 2, qtdColuna: 0, qtdCasas: 1, captura: false));
            }
            //Para Cima-Dir
            var temp = processamovimentos(qtdLinha: cor == Cor.Branca ? -1 : 1, qtdColuna: 1, qtdCasas: 1);
            //Para Cima-Esq
            temp.AddRange(processamovimentos(qtdLinha: cor == Cor.Branca ? -1 : 1, qtdColuna: -1, qtdCasas: 1));

            //Só é possivel o movimento se tiver Peça adversária na casa 
            posicaos.AddRange(temp.FindAll(p =>
            {
                Peca peca = this.Tabuleiro.peca(p);
                return (peca != null) && (peca.cor != this.cor);
            }));

            posicaos.ForEach(p => mat[p.linha, p.coluna] = true);

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
