using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroPessoa
{
    public partial class PessoaUIL : Form
    {
        Pessoa umaPessoa = new Pessoa();
        public PessoaUIL()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            umaPessoa.setCodigo(textBox1.Text);
            umaPessoa.setNome(textBox3.Text);
            umaPessoa.setSexo(comboBox1.Text);
            umaPessoa.setIdade(textBox2.Text);

            PessoaBLL.validaDados(umaPessoa);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
                MessageBox.Show("Dados inseridos com sucesso!");
            }
        }
        private void CadLivrosUIL_Load(object sender, EventArgs e)
        {
            PessoaBLL.conecta();
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
        }
       

        private void PessoaUIL_Load(object sender, EventArgs e)
        {
            PessoaBLL.conecta();
        }

        private void PessoaUIL_FormClosing(object sender, FormClosingEventArgs e)
        {
            PessoaBLL.desconecta();
        }
    }
}
