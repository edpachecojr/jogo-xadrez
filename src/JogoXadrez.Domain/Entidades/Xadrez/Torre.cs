using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Enums;

namespace JogoXadrez.Domain.Entidades.Xadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro.Tabuleiro tabuleiro, CorEnum cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] MatrizMovimentosPossiveis = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                MatrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            }

            // abaixo
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                MatrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            }

            // direita
            posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                MatrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            }

            // esquerda
            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                MatrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            }

            return MatrizMovimentosPossiveis;
        }
    }
}