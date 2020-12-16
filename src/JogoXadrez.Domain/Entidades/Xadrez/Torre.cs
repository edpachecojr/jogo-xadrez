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
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
            while (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                MatrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
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
                MatrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
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
                MatrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
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
                MatrizMovimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.MoverPosicaoEsquerda();
            }

            return MatrizMovimentosPossiveis;
        }
    }
}