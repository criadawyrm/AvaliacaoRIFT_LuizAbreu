using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Login_DAO : Util_DAO
    {
        public string Login(string Usuario, string Senha)
        {
            SqlConnection sqlConn = new SqlConnection(stringConn);
            SqlDataReader retornoConn;
            string retorno = "";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(string.Concat("EXEC Proc_Login '", Usuario, "','", Senha, "'"), sqlConn);
                retornoConn = cmd.ExecuteReader();
                while (retornoConn.Read())
                {
                    retorno = retornoConn["StatusRegistro"].ToString();
                }
            }
            catch (Exception ex)
            {
                retorno = "EX";
            }
            finally
            {
                sqlConn.Close();
            }
            return retorno;
        }
    }
}
