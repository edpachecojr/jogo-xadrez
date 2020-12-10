namespace JogoXadrez.Domain.Entidades.Tabuleiro
{
    public class Tabuleiro
    {
        public int linhas { get; private set; }
        public int colunas { get; private set; }
        public Peca[,] pecas { get; private set; }

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }
    }
}