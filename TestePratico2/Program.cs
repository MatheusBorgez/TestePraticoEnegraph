using System;
using System.Collections.Generic;
using System.Linq;

namespace TestePratico2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dicionario = new Dictionary<int, string>
            {
                {1, "um"}, 
                {2, "dois"}, 
                {3, "tres"}, 
                {4, "quatro"}, 
                {5, "cinco"}, 
            };

            var maiorElemento = dicionario.Max(dic => dic.Key);

            var somatorio = dicionario.Keys.Where(chave => chave != dicionario.Min(dic => dic.Key)).Sum();

            Console.WriteLine($"chave: {maiorElemento}, valor: {dicionario[maiorElemento]}");
            Console.WriteLine($"somatório das chaves excluindo a primeira chave: {somatorio}");
        }
    }
}
