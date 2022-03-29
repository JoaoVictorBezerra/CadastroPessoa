using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa
{
    class PessoaBLL
    {
        // Método bypass
        public static void conecta()
        {
            PessoaDAL.conecta();
        }

        public static void desconecta()
        {
            PessoaDAL.desconecta();
        }
        public static void validaCodigo(Pessoa umaPessoa)
        {
            Erro.setErro(false);
            if (umaPessoa.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            PessoaDAL.consultaUmaPessoa(umaPessoa);
        }

        public static void validaDados(Pessoa umaPessoa)
        {
            Erro.setErro(false);
            if (umaPessoa.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (umaPessoa.getNome().Equals(""))
            {
                Erro.setMsg("O nome é de preenchimento obrigatório!");
                return;
            }
            if (umaPessoa.getIdade().Equals(""))
            {
                Erro.setMsg("A idade é de preenchimento obrigatório!");
                return;
            }
            if (umaPessoa.getSexo().Equals(""))
            {
                Erro.setMsg("O campo sexo é de preenchimento obrigatório!");
                return;
            }
            if (umaPessoa.getIdade().Equals(""))
            {
                Erro.setMsg("O campo idade é de preenchimento obrigatório!");
                return;
            }
            try
            {
                int.Parse(umaPessoa.getIdade());
            }
            catch (Exception)
            {
                Erro.setMsg("O valor da idade deve ser numérico!");
                return;
            }


            if (int.Parse(umaPessoa.getIdade()) <= 0)
            {
                Erro.setMsg("O valor da idade deve ser numérico e positivo!");
                return;
            }
            PessoaDAL.inseriUmaPessoa(umaPessoa);
        }
    }
}
