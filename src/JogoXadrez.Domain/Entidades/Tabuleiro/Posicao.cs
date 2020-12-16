namespace JogoXadrez.Domain.Entidades.Tabuleiro
{
    public class Posicao
    {
        public int Linha { get; private set; }
        public int Coluna { get; private set; }

        public Posicao(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }

        public override string ToString()
        {
            return $"{Linha}, {Coluna}";
        }

        public void DefinirValores(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }

        public void MoverPosicaoAcima()
        {
            this.Linha--;
        }
        public void MoverPosicaoAbaixo()
        {
            this.Linha--;
        }
        public void MoverPosicaoDireita()
        {
            this.Coluna++;
        }
        public void MoverPosicaoEsquerda()
        {
            this.Coluna--;
        }
    }
}