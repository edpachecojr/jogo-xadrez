using System;

namespace JogoXadrez.Domain.Excecoes
{
    public class TabuleiroException : Exception
    {
        public TabuleiroException(string mensagem) : base(mensagem)
        {

        }
    }
}