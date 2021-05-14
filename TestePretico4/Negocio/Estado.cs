
using System.ComponentModel.DataAnnotations;

namespace TestePretico4
{
    public class Estado
    {
        public string Nome { get; set; }

        [Key]
        public string UnidadeFederativa { get; set; }
    }
}
