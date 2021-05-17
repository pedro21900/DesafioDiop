using DesafioDiop.Classe;
using System;
using System.Collections.Generic;

namespace DesafioDiop
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {

            string entrada = Painel();
            while (entrada != "S") { 
            switch (entrada)
            {
                case "1":
                    ListarContas();
                    break;

                case "2":
                    Adicionar();
                    break;

                case "3":
                    Transferir();
                    break;

                case "4":
                    Sacar();
                    break;

                case "5":
                    Depositar();
                    break;

                case "L":
                    Console.Clear();
                    break;

                case "S":
                    break;

                default:
                    throw new ArgumentOutOfRangeException();


            }

            entrada = Painel();
        }
        }
        public static void Adicionar()
        {
            Console.WriteLine("Tipo de conta \n");

                Console.WriteLine("1- Pessoa Física");
                Console.WriteLine("2 - Pessoa Jurídica");
           

            int Entradatipoconta= int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Insira o Saldo inicial Saldo");
            double saldo = double.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Insira o Crédito");
            double credito = double.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Insira o Nome");
            string nome = Console.ReadLine();
            Console.WriteLine("");

            Conta novaconta = new Conta(tipoConta: (DesafioDiop.Enum.TipoConta) Entradatipoconta,
                                        saldo: saldo,
                                        credito: credito,
                                        nome: nome);
            listaContas.Add(novaconta);

            Console.WriteLine();


        }
        public static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta");
            int Conta = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor do Saque");
            double saque = double.Parse(Console.ReadLine());

            listaContas[Conta].Sacar(saque);
        }
        public static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta");
            int Conta = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor do Deposito");
            double deposito = double.Parse(Console.ReadLine());

            listaContas[Conta].Depositar(deposito);
        }
        public static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de Origem");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de Destino");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor da transferencia");
            double transferencia = double.Parse(Console.ReadLine());

            listaContas[contaOrigem].Transferir(listaContas[contaDestino], transferencia);
        }
        public static void ListarContas()
        {
            Console.WriteLine("Contas Cadastradas");
            Console.WriteLine();
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Sem contas cadastradas");
                Console.WriteLine();
                return;
            }

            for (int i = 0; i <= listaContas.Count - 1; i++)
            {
                Console.WriteLine("#{0} - {1}", i, listaContas[i]);
                Console.WriteLine();
            }
        }
        public static string Painel()
        {
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Criar conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Despositar");
            Console.WriteLine("L - Limpar tela");
            Console.WriteLine("S - Sair");
            Console.WriteLine("");
            string saida = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return saida;

        }

    }
}
