using System;
using System.Collections.Generic;
using System.Linq;

namespace TestePratico
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoas = new List<Pessoa>()
            {
                new Pessoa()
                {
                    Nome = "Matheus Andrade",
                    Cidade = "Goiania",
                    CPF = "123.456.789-00",
                    DataNascimento = new DateTime(2001, 04, 06),
                    Estado = "Goias"
                },
                new Pessoa()
                {
                    Nome = "João da Silva",
                    Cidade = "Goiania",
                    CPF = "151.544.444-88",
                    DataNascimento = new DateTime(1996, 2, 5),
                    Estado = "Goias"
                },
                new Pessoa()
                {
                    Nome = "Fulano Souza",
                    Cidade = "Anapolis",
                    DataNascimento = DateTime.Now,
                    Estado = "Goias"
                }
            };

            Console.WriteLine("Pessoas agrupadas por cidade:");

            MostrePessoasPorCidade(pessoas);
            
            Console.WriteLine($"Menor data de nascimento: {ObtenhaMenorDataNascimento(pessoas)}");
            Console.WriteLine($"Pessoa de CPF 151.544.444-88 que nasceu em 05/02/1996: {ObtenhaPessoa(pessoas)}");
            Console.WriteLine($"Pessoa que não possui CPF: {ObtenhaPessoaSemCPF(pessoas)}");
        }

        private static string ObtenhaMenorDataNascimento(List<Pessoa> pessoas)
        {
            return pessoas.OrderByDescending(pessoa => pessoa.DataNascimento).First().DataNascimento.ToString();
        }

        private static string ObtenhaPessoa(List<Pessoa> pessoas)
        {
            return pessoas.Find(pessoa => pessoa.CPF == "151.544.444-88" && Equals(pessoa.DataNascimento, new DateTime(1996, 2, 5))).Nome;
        }
        private static string ObtenhaPessoaSemCPF(List<Pessoa> pessoas)
        {
            return pessoas.Find(pessoa => string.IsNullOrEmpty(pessoa.CPF)).Nome;
        }

        private static void MostrePessoasPorCidade(List<Pessoa> pessoas)
        {
            var pessoasAgrupadasPorCidade = from pessoa in pessoas
                        group pessoa by pessoa.Cidade into g
                        select new { Cidade = g, Quantidade = g.Count() };

            foreach (var agrupamento in pessoasAgrupadasPorCidade)
            {
                Console.WriteLine($"Cidade: {agrupamento.Cidade.Key}, Pessoas: {agrupamento.Quantidade}");
            }
        }
    }
}
