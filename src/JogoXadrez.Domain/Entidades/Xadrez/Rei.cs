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
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // ne
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // direita
            posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // se
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // abaixo
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // so
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // esquerda
            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                matrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // no
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
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