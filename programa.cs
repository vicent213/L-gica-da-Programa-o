using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHerança
{
    class App
    {
        public static void Main()
        {
            List<ContaBase> contas = new List<ContaBase>();
            Poupanca p = new Poupanca("sarah","20");
            ContaConjunta CC = new ContaConjunta ("sarah","")
            contas.Add(new ContaBase.ContaCorrente());        
                     
            contas[0].Depositar(1000);
        }

    }
    public class ContaBase
    {
        

        private string titular;
        private string numeroConta;
        protected decimal saldo;

        public ContaBase(string titular, string numeroConta)
        {
            this.titular = titular;
            this.numeroConta = numeroConta;
            this.saldo = 0;
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                saldo += valor;
            }
            else
            {
                Console.WriteLine("Valor dado é menor do que zero! Operação não foi feita.");
                return;
            }
        }
        public virtual void Sacar(decimal valor)
        {
            if (valor > 0 && saldo >= valor)
            {
                saldo -= valor;
            }
            else
            {
                Console.WriteLine("Valor dado é menor do que zero! Operação não foi feita.");
                return;
            }
        }
        public virtual void Resumo()
        {
            Console.WriteLine($"Número da conta: {numeroConta}\nNome titular: {titular}\n Saldo: {saldo:F2}\n");
        }
    }
    

    public class ContaCorrente : ContaBase
    {
        private const decimal tarifaSaque = 1;

        public ContaCorrente(string titular, string numeroConta) : base(titular, numeroConta) { }

        public override void Sacar(decimal valor)
        {
            if (valor > 0 && saldo >= valor + tarifaSaque)
            {
                saldo -= valor + tarifaSaque;
            }
            else
            {
                Console.WriteLine("Valor dado é menor do que zero! Operação não foi feita.");
                return;
            }
        }
    }

    public class Poupanca : ContaBase
    {
        private const decimal taxaRendimentoAnual = 0.08m;

        public Poupanca(string titular, string numeroConta) : base(titular, numeroConta) { }
        private void RenderJuros(int dias)
        {
            decimal rendimento = saldo * (taxaRendimentoAnual * dias / 365);
            base.Depositar(rendimento);
        }
    }


    public class ContaConjunta : ContaCorrente
    {
        private string segundoTitular;

        public ContaConjunta(string titular, string numeroConta, string segundoTitular) : base(titular, numeroConta)
        {
            this.segundoTitular = segundoTitular;
        }

        public override void Resumo()
        {
            Console.WriteLine($"Número da conta: {numeroConta}\nNome titular: {titular}\nNome segundo titular: {segundoTitular}\n {saldo:F2}\n");
        }
    }



}
