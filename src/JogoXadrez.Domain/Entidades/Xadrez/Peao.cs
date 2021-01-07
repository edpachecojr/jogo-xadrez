using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Enums;

namespace JogoXadrez.Domain.Entidades.Xadrez
{
    public class Peao : Peca
    {
        public Peao(Tabuleiro.Tabuleiro tabuleiro, CorEnum cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            if (this.Cor == CorEnum.Branca)
            {
                posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Livre(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Livre(posicao) && this.QuantidadeMovimentos == 0)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Livre(posicao) && this.ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Livre(posicao) && this.ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
            }
            else
            {
                posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Livre(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Livre(posicao) && this.QuantidadeMovimentos == 0)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Livre(posicao) && this.ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Livre(posicao) && this.ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.GetPeca(posicao);
            return peca != null && peca.Cor != this.Cor;
        }

        private bool Livre(Posicao posicao)
        {
            return this.Tabuleiro.GetPeca(posicao) == null;
        }
    }
}