using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Enums;

namespace JogoXadrez.Domain.Entidades.Xadrez
{
    public class Dama : Peca
    {
        public Dama(Tabuleiro.Tabuleiro tabuleiro, CorEnum cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.MoverPosicaoAcima();
            }

            // abaixo
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.MoverPosicaoAbaixo();
            }

            // direita
            posicao.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.MoverPosicaoDireita();
            }

            // esquerda
            posicao.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.MoverPosicaoEsquerda();
            }

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

        public override string ToString()
        {
            return "D";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }
    }
}