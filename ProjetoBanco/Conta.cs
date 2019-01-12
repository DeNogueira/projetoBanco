using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBanco.Enums;

namespace ProjetoBanco
{
    internal class Conta
    {
        //propriedades
        public TipoConta TipoConta { get; private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public Banco Banco { get; private set; }
        public List<Transacao> Transacoes { get; private set; }

        //construtor
        public Conta(TipoConta tipoConta, int agencia, int numero, Banco banco)
        {
            TipoConta = tipoConta;
            Agencia = agencia;
            Numero = numero;
            Banco = banco;
            Transacoes = new List<Transacao>(); //para nao ficar nulo
        }

        //métodos
        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor solicitado é inválido!");

            if (valor > Saldo)
                throw new Exception("Saldo insuficiente para realizar o saque!");

            /*Saldo -= valor;
            var transacao = new Transacao("Retirada", valor, TipoTransacao.Debito);
            Transacoes.Add(transacao);*/

            Debitar("Retirada", valor);

            Console.WriteLine("Saque realizado com sucesso!");
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor é inválido!");

            /*Saldo += valor;
            var transacao = new Transacao("Deposito", valor, TipoTransacao.Credito);
            Transacoes.Add(transacao);*/

            //substitui as 3 linhas de cima para poder usar os enums criados, melhora o codigo
            Creditar("Deposito", valor);
                
            //cw tab tab
            Console.WriteLine("Depósito realizado com sucesso!");
        }

        public void Transferir(int agencia, int numeroConta, decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor solicitado é inválido!");

            if (valor > Saldo)
                throw new Exception("Saldo insuficiente para realizar a transferência!");

            var contaDestino = Banco.ObterConta(agencia, numeroConta);

            //creditar, é na conta de destino
            contaDestino.Creditar("Transferencia", valor);
            //debitar, é na conta de origem
            Debitar("Trnsferencia", valor);

            Console.WriteLine("Transferencia realizada com sucesso!");
        }

        public void TirarExtrato()
        {
            //Transcacoes.Any() - verifica se tem alguma coisa
            if(Transacoes.Count > 0)
            {
                //for (int i = 0; i < Transacoes.Count; i++)
                //{
                //    var transacao = Transacoes[i];
                //}

                foreach (var transacao in Transacoes)//loop na lista
                {
                    var cor = transacao.TipoTransacao == TipoTransacao.Debito ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.ForegroundColor = cor;

                    var descricao = transacao.Descricao.PadRight(20, '-') + transacao.Valor.ToString("C");
                    Console.WriteLine(descricao);
                    //ou assim: Console.WriteLine($"{transacao.Descricao.PadRight(20, '-')}{transacao.Valor.ToString("C")}");

                    //transacao.Valor.ToString("C"); - mostra cifrao.
                    //PadRight concatena, a direita, até 20 caracteres com '-', se a palavra tem x caracteres ele subtrai de 20 e completa com '-' até dar 20 caracteres.
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(string.Empty);
                var saldoDescricao = "Saldo".PadRight(20, '-') + Saldo.ToString("C");
                Console.WriteLine(saldoDescricao);
            }
        }

        //métodos para creditar e debitar, usados para fazer as operações nas contas.
        //cono esta private, somente sacar, depositar e transferir consegue utiliza-lo.
        //o ObterConta, como é do tipo conta, tmbem consegue utiliza-los
        private void Creditar (string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Credito);
            Transacoes.Add(transacao);
            Saldo = Saldo + valor;
        }

        private void Debitar (string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Debito);
            Transacoes.Add(transacao);
            Saldo = Saldo - valor;
        }
    }
}
