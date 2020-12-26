using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Enums;

namespace JogoXadrez.Domain.Entidades.Xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro.Tabuleiro tabuleiro, CorEnum cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 2);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 2);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 2);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 2);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            return mat;
        }

        public override string ToString()
        {
            return "C";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }
    }
}