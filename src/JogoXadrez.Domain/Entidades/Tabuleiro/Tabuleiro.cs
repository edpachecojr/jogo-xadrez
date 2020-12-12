namespace JogoXadrez.Domain.Entidades.Tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; private set; }
        public int Colunas { get; private set; }
        public Peca[,] Pecas { get; private set; }

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            this.Pecas = new Peca[linhas, colunas];
        }

        public Peca getPeca(int linha, int coluna)
        {
            return this.Pecas[linha, coluna];
        }

        public void AdicionarPeca(Peca peca, Posicao posicao)
        {
            this.Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.AlteraPosicao(posicao);
        }
    }
}