using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ClientePJModel : UtilModel
    {
        ClientePJ_DAO dao = new ClientePJ_DAO();
        public List<ClientePJ_DTO> ListaClientePJ
        {
            get
            {
                if (HttpContext.Current.Session["ListaClientePJ"] != null)
                {
                    return (List<ClientePJ_DTO>)HttpContext.Current.Session["ListaClientePJ"];
                }
                else
                {
                    return new List<ClientePJ_DTO>();
                }
            }
            set
            {
                HttpContext.Current.Session.Add("ListaClientePJ", value);
            }
        }
        public ClientePJ_DTO CadastroClientePJ
        {
            get
            {
                if (HttpContext.Current.Session["CadastroClientePJ"] != null)
                {
                    return (ClientePJ_DTO)HttpContext.Current.Session["CadastroClientePJ"];
                }
                else
                {
                    return new ClientePJ_DTO();
                }
            }
            set
            {
                HttpContext.Current.Session.Add("CadastroClientePJ", value);
            }
        }
        public void ListarClientePJ()
        {
            try
            {
                ListaClientePJ = dao.ListarClientePJ();
            }
            catch
            {
            }
        }
        public void CadastrarClientePJ()
        {
            try
            {
                string retorno = dao.CadastrarClientePJ(CadastroClientePJ);

                if (retorno.Equals("A"))
                {
                    MensagemRetorno = CadastroClientePJ.IdClientePJ == 0 ? "Cadastro realizado com sucesso." : "Cadastro atualizado com sucesso.";
                }
                else if (retorno.Equals("E1"))
                {
                    MensagemRetorno = "CNPJ ja esta cadastrado.";
                }
                else if (retorno.Equals("E2"))
                {
                    MensagemRetorno = "Cliente nao localizado.";
                }
                else
                {
                    MensagemRetorno = CadastroClientePJ.IdClientePJ == 0 ? "E1 - Erro ao cadastrar cliente." : "E1 - Erro ao atualizar cadastro do cliente.";
                }

            }
            catch
            {
                MensagemRetorno = CadastroClientePJ.IdClientePJ == 0 ? "E2 - Erro ao cadastrar cliente." : "E2 - Erro ao atualizar cadastro do cliente.";
            }
        }
    }
}