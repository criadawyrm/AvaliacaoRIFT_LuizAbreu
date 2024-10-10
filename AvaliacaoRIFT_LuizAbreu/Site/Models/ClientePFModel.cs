using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using DAO;

namespace Site.Models
{
    public class ClientePFModel : UtilModel
    {
        ClientePF_DAO dao = new ClientePF_DAO();
        public List<ClientePF_DTO> ListaClientePF
        {
            get
            {
                if (HttpContext.Current.Session["ListaClientePF"] != null)
                {
                    return (List<ClientePF_DTO>)HttpContext.Current.Session["ListaClientePF"];
                }
                else
                {
                    return new List<ClientePF_DTO>();
                }
            }
            set
            {
                HttpContext.Current.Session.Add("ListaClientePF", value);
            }
        }
        public ClientePF_DTO CadastroClientePF
        {
            get
            {
                if (HttpContext.Current.Session["CadastroClientePF"] != null)
                {
                    return (ClientePF_DTO)HttpContext.Current.Session["CadastroClientePF"];
                }
                else
                {
                    return new ClientePF_DTO();
                }
            }
            set
            {
                HttpContext.Current.Session.Add("CadastroClientePF", value);
            }
        }
        public void ListarClientePF()
        {
            try
            {
                ListaClientePF = dao.ListarClientePF();
            }
            catch
            {
            }
        }
        public void CadastrarClientePF()
        {
            try
            {
                string retorno = dao.CadastrarClientePF(CadastroClientePF);

                if (retorno.Equals("A"))
                {
                    MensagemRetorno = CadastroClientePF.IdClientePF == 0 ? "Cadastro realizado com sucesso." : "Cadastro atualizado com sucesso.";
                }
                else if (retorno.Equals("E1"))
                {
                    MensagemRetorno = "CPF ja esta cadastrado.";
                }
                else if (retorno.Equals("E2"))
                {
                    MensagemRetorno = "Cliente nao localizado.";
                }
                else
                {
                    MensagemRetorno = CadastroClientePF.IdClientePF == 0 ? "E1 - Erro ao cadastrar cliente." : "E1 - Erro ao atualizar cadastro do cliente.";
                }

            }
            catch
            {
                MensagemRetorno = CadastroClientePF.IdClientePF == 0 ? "E2 - Erro ao cadastrar cliente." : "E2 - Erro ao atualizar cadastro do cliente.";
            }
        }
    }
}