using JogoXadrez.Domain.Excecoes;

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

        public Peca GetPeca(int linha, int coluna)
        {
            return this.Pecas[linha, coluna];
        }
        public Peca GetPeca(Posicao posicao)
        {
            return this.Pecas[posicao.Linha, posicao.Coluna];
        }

        public void AdicionarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            this.Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.AlteraPosicao(posicao);
        }

        public Peca RetirarPeca(Posicao posicao)
        {
            if (GetPeca(posicao) == null)
            {
                return null;
            }
            Peca aux = GetPeca(posicao);
            aux.SetPosicaoNull();
            Pecas[posicao.Linha, posicao.Coluna] = null;

            return aux;
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return this.GetPeca(posicao) != null;
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= this.Linhas || posicao.Coluna < 0 || posicao.Coluna >= this.Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}