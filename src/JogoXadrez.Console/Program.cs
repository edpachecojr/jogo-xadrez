using System;
using JogoXadrez.ConsoleApp.Servicos;
using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Entidades.Xadrez;
using JogoXadrez.Domain.Enums;
using JogoXadrez.Domain.Excecoes;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);
                tabuleiro.AdicionarPeca(new Torre(tabuleiro, CorEnum.Preta), new Posicao(0, 0));
                tabuleiro.AdicionarPeca(new Torre(tabuleiro, CorEnum.Preta), new Posicao(1, 3));
                tabuleiro.AdicionarPeca(new Rei(tabuleiro, CorEnum.Preta), new Posicao(2, 4));
                tabuleiro.AdicionarPeca(new Rei(tabuleiro, CorEnum.Branca), new Posicao(3, 5));
                tabuleiro.AdicionarPeca(new Torre(tabuleiro, CorEnum.Branca), new Posicao(3, 3));

                TelaService.ImprimirTabuleiro(tabuleiro);
                Console.ReadLine();

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
