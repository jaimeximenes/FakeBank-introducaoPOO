using System;

namespace Fake.Bank
{
    public class Conta
    {
        private TipoConta Tipoconta {get; set;}
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double SaldoEspecial { get; set; }
        public Conta(TipoConta tipoConta,string nome, double saldo, double saldoEspecial)
        {
            this.Tipoconta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.SaldoEspecial = saldoEspecial;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.SaldoEspecial * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual e de: {0}",this.Saldo);
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta: {0}",this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno ="";
            retorno += "Tipo conta" + this.Tipoconta +"|";
            retorno += "Nome" + this.Nome +"|";
            retorno += "Saldo" + this.Saldo +"|";
            retorno += "saldo especial" + this.SaldoEspecial +"|";

            return retorno;
        }
    }
}