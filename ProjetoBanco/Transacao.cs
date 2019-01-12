using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBanco.Enums;

namespace ProjetoBanco
{
    internal class Transacao
    {
        public TipoTransacao TipoTransacao { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHora { get; private set; }

        public Transacao(string descricao, decimal valor, TipoTransacao tipoTransacao)
        {
            Descricao = descricao;
            Valor = valor;
            TipoTransacao = tipoTransacao;
            DataHora = DateTime.Now;
        }
    }
}
