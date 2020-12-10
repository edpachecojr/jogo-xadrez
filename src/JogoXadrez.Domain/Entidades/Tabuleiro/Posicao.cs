namespace JogoXadrez.Domain.Entidades.Tabuleiro
{
    public class Posicao
    {
        public int linha { get; private set; }
        public int coluna { get; private set; }

        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public override string ToString()
        {
            return $"{linha}, {posicao}";
        }
    }
}