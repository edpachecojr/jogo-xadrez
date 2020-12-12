using System;
using JogoXadrez.ConsoleApp.Servicos;
using JogoXadrez.Domain.Entidades.Tabuleiro;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);
            TelaService.ImprimirTabuleiro(tabuleiro);
            Console.ReadLine();
        }
    }
}
