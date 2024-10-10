using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using DAO;


namespace Site.Models
{
    public class LoginModel : UtilModel
    {

        public bool Login(string Usuario, string Senha)
        {
			try
            {
                Login_DAO dao = new Login_DAO();
                string retorno = dao.Login(Usuario, Senha);

                if (retorno.Equals("B"))
                {
                    MensagemRetorno = "Usuario bloqueado.";
                }
                else if (retorno.Equals("D"))
                {
                    MensagemRetorno = "Usuario desativado.";
                }
                else if (retorno.Equals("E"))
                {
                    MensagemRetorno = "Senha incorreta.";
                }
                else if (retorno.Equals("EX"))
                {
                    MensagemRetorno = "E1 - Erro ao realizar Login.";
                }
                else if (retorno.Equals("A"))
                {
                    StatusLogin = true;
                    return true;
                }
                else
                {
                    MensagemRetorno = "Usuario nao localizado.";
                }
            }
			catch
            {
                MensagemRetorno = "E2 - Erro ao realizar Login.";
            }
            return false;
        }
    }
}