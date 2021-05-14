using System;
using System.ComponentModel.DataAnnotations;

namespace TestePretico4
{
    public class Pessoa
    {
        public string Nome { get; set; }

        [Key]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public Cidade Cidade { get; set; }

        public Estado Estado { get; set; }

        public CEP CEP { get; set; }
    }
}
