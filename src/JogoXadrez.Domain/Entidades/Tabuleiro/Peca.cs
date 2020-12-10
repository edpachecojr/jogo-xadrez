namespace JogoXadrez.Domain.Entidades.Tabuleiro
{
    public class Peca
    {
        public Posicao Posicao { get; private set; }
        public CorEnum Cor { get; protected set; }
        public int QuantidadeMovimentos { get; private set; }
        public Tabuleiro Tabuleiro { get; private set; }

        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor)
        {
            this.Posicao = posicao;
            this.Tabuleiro = tabuleiro;
            this.Cor = cor;
            this.QuantidadeMovimentos = 0;
        }
    }
}