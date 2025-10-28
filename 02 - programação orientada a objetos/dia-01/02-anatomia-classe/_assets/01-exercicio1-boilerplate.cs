using System;

using System.Collections.Generic;

// ----------------------------

// Classe que representa um registro de extrato

// ----------------------------

namespace Boilerplate

{

    public class Movimentacao

    {

        public string CpfPessoa;        // CPF da pessoa (para referência)

        public DateTime DataInclusao;   // Data da transação

        public double ValorTransacao;

        // Construtor

        public Movimentacao(string cpf, DateTime data, double valor)

        {

            CpfPessoa = cpf;

            DataInclusao = data;

            ValorTransacao = valor;

        }

    }

    // ----------------------------

    // Classe que representa o extrato

    // ----------------------------

    public class ExtratoBancario

    {

        public string CpfPessoa;       // CPF da pessoa

        public string NomePessoa;      // Nome da pessoa

        public double ValorInicial;    // Saldo inicial

        protected List<Movimentacao> Movimentacoes;

        // Construtor

        public ExtratoBancario(string cpf, string nome, double valorInicial, List<Movimentacao> movimentacoes)

        {

            CpfPessoa = cpf;

            NomePessoa = nome;

            ValorInicial = valorInicial;

            Movimentacoes = movimentacoes ?? new List<Movimentacao>();

        }

        // ----------------------------

        // Método para calcular saldo final

        // ----------------------------

        public double CalcularSaldo()

        {

            double valor;

            valor = ValorInicial;

            for (int i = 0; i < Movimentacoes.Count; i++)

            {

                valor += Movimentacoes[i].ValorTransacao;

            }

            // TODO: Implementar cálculo do saldo final

            return valor;

        }

        // ----------------------------

        // Método para obter saldos diários

        // ----------------------------

        public List<string> ObterSaldosDiarios()

        {

            double SaldoAtual = ValorInicial;

            Dictionary<DateTime, double> valoresPorDia = new Dictionary<DateTime, double>();

            for (int i = 0; i < Movimentacoes.Count; i++)

            {

                if (valoresPorDia.ContainsKey(Movimentacoes[i].DataInclusao.Date))

                {

                    valoresPorDia[Movimentacoes[i].DataInclusao.Date] += Movimentacoes[i].ValorTransacao;

                }

                else

                {

                    valoresPorDia[Movimentacoes[i].DataInclusao.Date] = Movimentacoes[i].ValorTransacao;

                }

                SaldoAtual += Movimentacoes[i].ValorTransacao;

            }

            // TODO: Implementar cálculo de saldo diário

            return new List<string>();

        }

    }

    // ----------------------------

    // Classe App com método Main

    // ----------------------------

    public class App

    {

        public static void Main()

        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Sistema de Extrato Bancário ===\n");

            // TODO: Instanciar ExtratoBancario e Movimentacoes conforme o exercício

            // Exemplo de comentário:

            List<Movimentacao> movimentacoes = new List<Movimentacao> { };

            string cpf = "84612789091";

            Movimentacao mov1 = new Movimentacao(cpf, DateTime.Now, 19.2);

            Movimentacao mov2 = new Movimentacao(cpf, DateTime.Now.AddDays(2), -10.2);

            Movimentacao mov3 = new Movimentacao(cpf, DateTime.Now.AddDays(3), 23.9);

            Movimentacao mov4 = new Movimentacao(cpf, DateTime.Now.AddDays(4), 11.2);

            Movimentacao mov5 = new Movimentacao(cpf, DateTime.Now.AddDays(5), 19.2);

            Movimentacao mov52 = new Movimentacao(cpf, DateTime.Now.AddDays(5), -5.5);

            movimentacoes.Add(mov1);

            movimentacoes.Add(mov2);

            movimentacoes.Add(mov3);

            movimentacoes.Add(mov4);

            movimentacoes.Add(mov5);

            movimentacoes.Add(mov52);





            ExtratoBancario extrat1 = new ExtratoBancario(cpf, "luana", 1000, movimentacoes);

            // var extrato = new ExtratoBancario("CPF", "Nome", 1000, movimentacoes);

            // TODO: Chamar CalcularSaldo e ObterSaldosDiarios, imprimir resultados

            Console.WriteLine("\nFim do programa. Implemente as funcionalidades solicitadas no exercício.");

        }

    }

}

