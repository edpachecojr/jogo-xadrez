using System.Collections.Generic;
using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Entidades.Xadrez;
using JogoXadrez.Domain.Enums;
using JogoXadrez.Domain.Excecoes;

namespace JogoXadrez.Domain.Servicos
{
    public class PartidaDeXadrez
    {
        private Tabuleiro _tabuleiro;
        private int _turno;
        private CorEnum _jogadorAtual;
        private bool _terminada;
        public HashSet<Peca> Pecas { get; private set; }
        public HashSet<Peca> Capturadas { get; private set; }
        public bool PartidaEmXeque { get; private set; }

        public PartidaDeXadrez()
        {
            this._tabuleiro = new Tabuleiro(8, 8);
            this._turno = 1;
            this._jogadorAtual = CorEnum.Branca;
            this._terminada = false;
            PartidaEmXeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = this._tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = this._tabuleiro.RetirarPeca(destino);
            this._tabuleiro.AdicionarPeca(peca, destino);
            if (pecaCapturada != null)
            {
                this.Capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = this._tabuleiro.RetirarPeca(destino);
            peca.DecrementarQuantidadeMovimentos();
            if (pecaCapturada != null)
            {
                this._tabuleiro.AdicionarPeca(pecaCapturada, destino);
                this.Capturadas.Remove(pecaCapturada);
            }
            this._tabuleiro.AdicionarPeca(peca, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {

            Peca pecaCapturada = this.ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            CorEnum adversario = Adversario(JogadorAtual);
            if (EstaEmXeque(adversario))
            {
                this.PartidaEmXeque = true;
            }
            else
            {
                this.PartidaEmXeque = false;
            }

            if (this.VerificaXequeMate(adversario))
            {
                this._terminada = true;
            }
            else
            {
                this._turno++;
                this.MudaJogador();

            }
        }

        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (this.Tabuleiro.GetPeca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (this._jogadorAtual != this.Tabuleiro.GetPeca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!this.Tabuleiro.GetPeca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não é movimentos possíveis para a peça escolhida!");
            }
        }
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!this.Tabuleiro.GetPeca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
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

        public HashSet<Peca> PecasCapturadas(CorEnum cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in this.Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(CorEnum cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in this.Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(this.PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            this._tabuleiro.AdicionarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {

            this.ColocarNovaPeca('a', 1, new Torre(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('b', 1, new Cavalo(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('c', 1, new Bispo(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('d', 1, new Dama(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('e', 1, new Rei(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('f', 1, new Bispo(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('g', 1, new Cavalo(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('h', 1, new Torre(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('a', 2, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('b', 2, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('c', 2, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('d', 2, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('e', 2, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('f', 2, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('g', 2, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('h', 2, new Peao(this._tabuleiro, CorEnum.Branca));

            this.ColocarNovaPeca('a', 8, new Torre(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('b', 8, new Cavalo(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('c', 8, new Bispo(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('d', 8, new Dama(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('e', 8, new Rei(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('f', 8, new Bispo(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('g', 8, new Cavalo(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('h', 8, new Torre(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('a', 7, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('b', 7, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('c', 7, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('d', 7, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('e', 7, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('f', 7, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('g', 7, new Peao(this._tabuleiro, CorEnum.Branca));
            this.ColocarNovaPeca('h', 7, new Peao(this._tabuleiro, CorEnum.Branca));
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

        private CorEnum Adversario(CorEnum cor)
        {
            return cor == CorEnum.Branca ? CorEnum.Preta : CorEnum.Branca;
        }

        private Peca GetRei(CorEnum cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(CorEnum cor)
        {
            Peca rei = GetRei(cor);
            if (rei == null)
            {
                throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro!");
            }

            foreach (Peca x in PecasEmJogo(Adversario(cor)))
            {
                bool[,] matriz = x.MovimentosPossiveis();
                if (matriz[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }

            return false;
        }
        public bool VerificaXequeMate(CorEnum cor)
        {
            if (!this.EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in this.PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < this._tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < this._tabuleiro.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = this.ExecutaMovimento(origem, destino);
                            bool testeXeque = this.EstaEmXeque(cor);
                            this.DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }

}