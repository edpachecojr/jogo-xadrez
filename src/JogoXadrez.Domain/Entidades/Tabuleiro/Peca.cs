using System;
using JogoXadrez.Domain.Enums;

namespace JogoXadrez.Domain.Entidades.Tabuleiro
{
    public abstract class Peca
    {
        public Posicao Posicao { get; private set; }
        public CorEnum Cor { get; protected set; }
        public int QuantidadeMovimentos { get; private set; }
        public Tabuleiro Tabuleiro { get; private set; }

        public Peca(Tabuleiro tabuleiro, CorEnum cor)
        {
            this.Posicao = null;
            this.Tabuleiro = tabuleiro;
            this.Cor = cor;
            this.QuantidadeMovimentos = 0;
        }

        public void AlteraPosicao(Posicao posicao)
        {
            this.Posicao = posicao;
        }

        public void SetPosicaoNull()
        {
            Posicao = null;
        }

        public void IncrementarQuantidadeMovimentos()
        {
            this.QuantidadeMovimentos++;
        }
        public void DecrementarQuantidadeMovimentos()
        {
            this.QuantidadeMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] matriz = MovimentosPossiveis();
            for (int i = 0; i < this.Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < this.Tabuleiro.Colunas; j++)
                {
                    if (matriz[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PodeMoverPara(Posicao posicao)
        {
            return this.MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}