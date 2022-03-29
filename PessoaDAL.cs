using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CadastroPessoa
{
    class PessoaDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_Cadastro.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void conecta()
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados");
            }

        }

        public static void desconecta()
        {
            conn.Close();
        }

        public static void inseriUmaPessoa(Pessoa umaPessoa)
        {
            String aux = "insert into tb_Pessoa(cd_Pessoa,nm_Pessoa,sg_Sexo,ds_Idade) values ('" + umaPessoa.getCodigo() + "','" + umaPessoa.getNome() + "','" + umaPessoa.getSexo() + "','" + umaPessoa.getIdade() + "')";

            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Erro.setMsg(e.Message);
            }
        }

        public static void consultaUmaPessoa(Pessoa umaPessoa)
        {
            String aux = "select * from tb_Pessoa where codigo ='" + umaPessoa.getCodigo() + "'";
            strSQL = new OleDbCommand(aux, conn);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                umaPessoa.setCodigo(result.GetString(1));
                umaPessoa.setNome(result.GetString(2));
                umaPessoa.setSexo(result.GetString(3));
                umaPessoa.setIdade(result.GetString(4));
            }
            else
            {
                Erro.setMsg("Pessoa não cadastrada.");
            }
        }
    }
}
