using System;

namespace ProjetoBanco
{
    internal class Program
    {
        //instanciação
        private static readonly Banco banco = new Banco();
        private static readonly Conta contaDestino;

        //construtor para objeto
        static Program()
        {
            var cidade = new Cidade("Jundiaí", "SP");
            var endereco = new Endereco("Av. Angelo Corradini", "Vila Nambi", "13219-071", 400, cidade);
            var cliente = new Cliente("Denise", "12698417773", new DateTime(1994, 8, 5), endereco);
            contaDestino = banco.AbrirConta(cliente);
        }

        private static void Main(string[] args)
        {
            try
            {
                var cidade = new Cidade("Jundiaí", "SP");
                var endereco = new Endereco("Rua General Osorio", "Centro", "13219-000", 161, cidade);
                var cliente = new Cliente("Viceri", "12654789325", new DateTime(1988, 3, 13), endereco);

                //criar conta
                var contaViceri = banco.AbrirConta(cliente);

                //depositar e sacar
                contaViceri.Depositar(2500);
                contaViceri.Sacar(350);
                contaViceri.TirarExtrato();

                //transferir
                contaViceri.Transferir(1, 1, 1200);
                contaViceri.TirarExtrato();
                contaDestino.TirarExtrato();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ResetColor();
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Pressione qualquer tecla para sair ...");
            Console.ReadKey();
        }
    }
}
