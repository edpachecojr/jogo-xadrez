using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Enums;

namespace JogoXadrez.Domain.Entidades.Xadrez
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro.Tabuleiro tabuleiro, CorEnum cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizMovimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // ne
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // direita
            posicao.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // se
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // abaixo
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // so
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // esquerda
            posicao.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // no
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            return matrizMovimentosPossiveis;
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }


    }
}