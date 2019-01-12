using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBanco
{
    internal class Cidade
    {
        public string Nome { get; private set; }
        public string UF { get; private set; }

        //isso é um contrutor
        public Cidade(string nome, string uf)
        {
            Nome = nome;
            UF = uf;
        }
    }
}
