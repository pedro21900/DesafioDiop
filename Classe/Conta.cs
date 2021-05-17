using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiop.Classe
{
    class Conta
    {
        private string Nome;
        private DesafioDiop.Enum.TipoConta tipoConta;
        private double Saldo;
        private double Credito;
        private double iniCredito;
        // Métodos
        public Conta(DesafioDiop.Enum.TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.tipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.iniCredito = credito;
            this.Nome = nome;
        }
        public void Sacar(double valorSaque)
        {
            //Verifica se existe saldo
            if (this.Saldo - valorSaque < Credito * -1)
            {
                Console.WriteLine("Saldo insuficiente");
                return;
            }      
            else if (this.Saldo - valorSaque < 0)
            {
                this.Credito = (this.Saldo - valorSaque)+this.iniCredito;
                this.Saldo = 0;
                Console.WriteLine($"Realizado com Sucesso!! || Valor atual R$ {this.Saldo} & Credito atual R$ {this.Credito}");
                Console.WriteLine();
                return;
            }
                this.Saldo -= valorSaque;             
                Console.WriteLine($"Realizado com Sucesso!! || Valor atual R$ {this.Saldo} & Credito atual R$ {this.Credito}");
                Console.WriteLine();


        }
        public void Depositar(double valorDeposito)
        {
             if (this.Saldo== 0)
            {
                if (this.Credito != this.iniCredito) {
                    double aux = this.iniCredito - this.Credito;
                    if(aux< valorDeposito)
                    {
                        valorDeposito -= aux;
                        this.Credito = this.iniCredito;
                    }
                    else
                    {
                        this.Credito += valorDeposito;
                        valorDeposito = 0;

                    }
                }                
                this.Saldo += valorDeposito;
                Console.WriteLine($"Realizado com Sucesso!! || Valor atual R$ {this.Saldo} & Credito atual R$ {this.Credito}");
                Console.WriteLine();
                return;
            }
            this.Saldo += valorDeposito;
            Console.WriteLine($"Realizado com Sucesso!! || Valor atual R$ {this.Saldo} & Credito atual R$ {this.Credito}");
            Console.WriteLine();
        }
        public void Transferir(Conta conta,double valorTransferencia)
        {
            Sacar(valorTransferencia);
            conta.Depositar(valorTransferencia);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }
    }
}
