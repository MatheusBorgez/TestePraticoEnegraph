using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestePretico4.Processos;

namespace TestePretico4
{
    public partial class Form1 : Form
    {
        private readonly ProcessoCadastroPessoas _processo = new();

        public Form1()
        {
            InitializeComponent();
            CarregueGridPessoas();
        }

        private void CarregueGridPessoas()
        {
            var pessoas = _processo.ObtenhaTodasAsPessoas();

            bsPessoas.DataSource = pessoas;
            gridPessoas.DataSource = bsPessoas;

            bsPessoas.ResetBindings(true);
        }

        private void button1_Click(object sender, EventArgs ex)
        {
            var estado = txtEstado.SelectedItem as Estado;
            var cidade = new Cidade { Nome = txtCidade.Text, Estado = estado };

            var pessoa = new Pessoa()
            {
                Nome = txtNome.Text,
                Estado = estado,
                Cidade = cidade,
                CPF = txtCPf.Text,
                CEP = new CEP { CodigoPostal = txtCEP.Text, Cidade = cidade, Estado = estado },
                DataNascimento = dtpNascimento.Value
            };

            try
            {
                _processo.InsiraPessoa(pessoa);
            }
            catch (Exception)
            {
                throw;
            }

            MessageBox.Show("Pessoa inserida com sucesso!!");
        }
    }
}
