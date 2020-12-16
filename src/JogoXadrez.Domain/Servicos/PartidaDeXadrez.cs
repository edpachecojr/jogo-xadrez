using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Entidades.Xadrez;
using JogoXadrez.Domain.Enums;

namespace JogoXadrez.Domain.Servicos
{
    public class PartidaDeXadrez
    {
        private Tabuleiro _tabuleiro;
        private int _turno;
        private CorEnum _jogadorAtual;
        private bool _terminada;

        public PartidaDeXadrez()
        {
            this._tabuleiro = new Tabuleiro(8, 8);
            this._turno = 1;
            this._jogadorAtual = CorEnum.Branca;
            this._terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = this._tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = this._tabuleiro.RetirarPeca(destino);
            this._tabuleiro.AdicionarPeca(peca, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            this.ExecutaMovimento(origem, destino);
            this._turno++;
            this.MudaJogador();
        }

        private void MudaJogador()
        {
            if (this._jogadorAtual == CorEnum.Branca)
            {
                this._jogadorAtual = CorEnum.Preta;
            }
            else
            {
                this._jogadorAtual = CorEnum.Branca;
            }
        }

        private void ColocarPecas()
        {
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Rei(this._tabuleiro, CorEnum.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Torre(this._tabuleiro, CorEnum.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            this._tabuleiro.AdicionarPeca(new Rei(this._tabuleiro, CorEnum.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }

        public Tabuleiro Tabuleiro
        {
            get { return this._tabuleiro; }
        }

        public bool Terminada
        {
            get { return this._terminada; }
        }
        public int Turno
        {
            get { return this._turno; }
        }
        public CorEnum JogadorAtual
        {
            get { return this._jogadorAtual; }
        }
    }
}