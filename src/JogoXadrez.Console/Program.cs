using System;
using JogoXadrez.ConsoleApp.Servicos;
using JogoXadrez.Domain.Entidades.Tabuleiro;
using JogoXadrez.Domain.Entidades.Xadrez;
using JogoXadrez.Domain.Enums;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);
            tabuleiro.AdicionarPeca(new Torre(tabuleiro, CorEnum.Preta), new Posicao(0, 0));
            tabuleiro.AdicionarPeca(new Torre(tabuleiro, CorEnum.Preta), new Posicao(1, 3));
            tabuleiro.AdicionarPeca(new Rei(tabuleiro, CorEnum.Preta), new Posicao(2, 4));

            TelaService.ImprimirTabuleiro(tabuleiro);
            Console.ReadLine();
        }
    }
}
