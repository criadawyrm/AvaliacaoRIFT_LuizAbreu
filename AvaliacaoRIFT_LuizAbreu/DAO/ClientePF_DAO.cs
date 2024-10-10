using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ClientePF_DAO : Util_DAO
    {
        public List<ClientePF_DTO> ListarClientePF()
        {
            SqlConnection sqlConn = new SqlConnection(stringConn);
            SqlDataReader retornoConn;
            List<ClientePF_DTO> retorno = new List<ClientePF_DTO>();
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ClientePF", sqlConn);
                retornoConn = cmd.ExecuteReader();
                while (retornoConn.Read())
                {
                    retorno.Add(new ClientePF_DTO()
                    {
                         IdClientePF = (int)retornoConn["IdClientePF"]
                        ,CPF = retornoConn["CPF"].ToString()
                        ,Nome = retornoConn["Nome"].ToString()
                        ,Sexo = retornoConn["Sexo"].ToString()
                        ,DataNascimento = retornoConn["DataNascimento"].ToString()
                        ,RG = retornoConn["RG"].ToString()
                        ,Endereco = retornoConn["Endereco"].ToString()
                        ,Telefone1 = retornoConn["Telefone1"].ToString()
                        ,Telefone2 = retornoConn["Telefone2"].ToString()
                        ,Email1 = retornoConn["Email1"].ToString()
                        ,Email2 = retornoConn["Email2"].ToString()
                        ,StatusRegistro = retornoConn["StatusRegistro"].ToString()
                    });
                }
            }
            catch
            {
            }
            finally
            {
                sqlConn.Close();
            }

            return retorno;
        }
        public string CadastrarClientePF(ClientePF_DTO clientePF)
        {
            SqlConnection sqlConn = new SqlConnection(stringConn);
            SqlDataReader retornoConn;
            string retorno = "";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(
                    string.Concat(
                        "Proc_CadastroClientePF "
                        ,clientePF.IdClientePF
                        , ",'",clientePF.CPF, "'"
                        , ",'", clientePF.Nome, "'"
                        , ",'", clientePF.Sexo ?? "", "'"
                        , ",'", clientePF.DataNascimento ?? "", "'"
                        , ",'", clientePF.RG ?? "", "'"
                        , ",'", clientePF.Endereco ?? "", "'"
                        , ",'", clientePF.Telefone1 ?? "", "'"
                        , ",'", clientePF.Telefone2 ?? "", "'"
                        , ",'", clientePF.Email1 ?? "", "'"
                        , ",'", clientePF.Email2 ?? "", "'"
                    )
                    , sqlConn);
                retornoConn = cmd.ExecuteReader();
                while (retornoConn.Read())
                {
                    retorno = retornoConn["retorno"].ToString();
                }
            }
            catch
            {
                retorno = "E3";
            }
            finally
            {
                sqlConn.Close();
            }

            return retorno;
        }
    }
}
