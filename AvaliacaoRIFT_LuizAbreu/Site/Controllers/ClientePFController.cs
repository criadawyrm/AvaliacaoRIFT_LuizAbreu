using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models;
using DTO;
using System.ComponentModel;

namespace Site.Controllers
{
    public class ClientePFController : Controller
    {
        ClientePFModel model = new ClientePFModel();
        public ActionResult Index()
        {
            try
            {
                model.ListarClientePF();
                model.CadastroClientePF = new ClientePF_DTO();
            }
            catch
            {
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string CPF, string Nome, string RG)
        {
            try
            {
                bool filtro = false;
                model.ListarClientePF();

                List<ClientePF_DTO> listaClientePF = new List<ClientePF_DTO>();

                if (!string.IsNullOrEmpty(CPF))
                {
                    filtro = true;
                    listaClientePF.AddRange(model.ListaClientePF.FindAll(w => w.CPF.Contains(CPF)));
                }

                if (!string.IsNullOrEmpty(Nome))
                {
                    filtro = true;
                    listaClientePF.AddRange(model.ListaClientePF.FindAll(w => w.Nome.Contains(Nome)));
                }

                if (!string.IsNullOrEmpty(RG))
                {
                    filtro = true;
                    listaClientePF.AddRange(model.ListaClientePF.FindAll(w => w.RG.Contains(RG)));
                }

                if (filtro)
                    model.ListaClientePF = listaClientePF;

                model.CadastroClientePF = new ClientePF_DTO();
            }
            catch
            {
            }
            return View(model);
        }
        public ActionResult Cadastro(int id = 0)
        {
            try
            {
                if (id != 0)
                {
                    ClientePF_DTO clientePF = new ClientePF_DTO();
                    clientePF =  model.ListaClientePF.Where(w=>w.IdClientePF == id).FirstOrDefault();

                    if (clientePF.IdClientePF == 0)
                    {
                        model.MensagemRetorno = "E1 - Erro ao selecionar cliente.";
                        return RedirectToAction("Index");
                    }
                    model.CadastroClientePF = clientePF;
                }
            }
            catch
            {
                model.MensagemRetorno = "E2 - Erro ao selecionar cliente.";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Cadastro(ClientePFModel model)
        {
            try
            {
                model.CadastrarClientePF();
            }
            catch
            {
                model.MensagemRetorno = model.CadastroClientePF.IdClientePF == 0 ? "E3 - Erro ao cadastrar cliente." : "E3 - Erro ao atualizar cadastro do cliente.";
            }
            return RedirectToAction("Index", "ClientePF");
        }
    }
}