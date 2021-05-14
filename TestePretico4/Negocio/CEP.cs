using System.ComponentModel.DataAnnotations;

namespace TestePretico4
{
    public class CEP
    {
        [Key]
        public string CodigoPostal { get; set; }

        public Cidade Cidade { get; set; }

        public Estado Estado { get; set; }
    }
}