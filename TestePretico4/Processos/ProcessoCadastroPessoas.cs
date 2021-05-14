using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePretico4.Model;

namespace TestePretico4.Processos
{
    public class ProcessoCadastroPessoas
    {
        private Contexto _contexto = new();

        public void InsiraPessoa(Pessoa pessoa)
        {
            _contexto.Pessoas.Add(pessoa);
            _contexto.SaveChanges();
        }

        public IEnumerable<Pessoa> ObtenhaTodasAsPessoas()
        {
            return _contexto.Pessoas.OrderBy(pessoa => pessoa.Nome);
        }
    }
}
