using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Enums;

namespace JogoXadrez.Domain.Entidades.Xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro.Tabuleiro tabuleiro, CorEnum cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            // NO
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.GetPeca(posicao) != null && this.Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
            }

            // NE
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.GetPeca(posicao) != null && this.Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            }

            // SE
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.GetPeca(posicao) != null && this.Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }

            // SO
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.GetPeca(posicao) != null && this.Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }

            return mat;
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}