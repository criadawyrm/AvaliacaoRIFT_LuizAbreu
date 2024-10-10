using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ClientePJ_DAO : Util_DAO
    {
        public List<ClientePJ_DTO> ListarClientePJ()
        {
            SqlConnection sqlConn = new SqlConnection(stringConn);
            SqlDataReader retornoConn;
            List<ClientePJ_DTO> retorno = new List<ClientePJ_DTO>();
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ClientePJ", sqlConn);
                retornoConn = cmd.ExecuteReader();
                while (retornoConn.Read())
                {
                    retorno.Add(new ClientePJ_DTO()
                    {
                        IdClientePJ = (int)retornoConn["IdClientePJ"]
                        ,CNPJ = retornoConn["CNPJ"].ToString()
                        ,NomeFantasia = retornoConn["NomeFantasia"].ToString()
                        ,RazaoSocial = retornoConn["RazaoSocial"].ToString()
                        ,Endereco = retornoConn["Endereco"].ToString()
                        ,Telefone1 = retornoConn["Telefone1"].ToString()
                        ,Telefone2 = retornoConn["Telefone2"].ToString()
                        ,Email = retornoConn["Email"].ToString()
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
        public string CadastrarClientePJ(ClientePJ_DTO clientePJ)
        {
            SqlConnection sqlConn = new SqlConnection(stringConn);
            SqlDataReader retornoConn;
            string retorno = "";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(
                    string.Concat(
                        "Proc_CadastroClientePJ "
                        , clientePJ.IdClientePJ
                        , ",'", clientePJ.CNPJ, "'"
                        , ",'", clientePJ.RazaoSocial, "'"
                        , ",'", clientePJ.NomeFantasia ?? "", "'"
                        , ",'", clientePJ.Endereco ?? "", "'"
                        , ",'", clientePJ.Telefone1 ?? "", "'"
                        , ",'", clientePJ.Telefone2 ?? "", "'"
                        , ",'", clientePJ.Email ?? "", "'"
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
