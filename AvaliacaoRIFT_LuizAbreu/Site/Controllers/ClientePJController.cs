using DTO;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class ClientePJController : Controller
    {
        ClientePJModel model = new ClientePJModel();
        public ActionResult Index()
        {
            try
            {
                model.ListarClientePJ();
                model.CadastroClientePJ = new ClientePJ_DTO();
            }
            catch
            {
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string CNPJ, string RazaoSocial, string NomeFantasia)
        {
            try
            {
                bool filtro = false;
                model.ListarClientePJ();

                List<ClientePJ_DTO> listaClientePJ = new List<ClientePJ_DTO>();

                if (!string.IsNullOrEmpty(CNPJ))
                {
                    filtro = true;
                    listaClientePJ.AddRange(model.ListaClientePJ.FindAll(w => w.CNPJ.Contains(CNPJ)));
                }

                if (!string.IsNullOrEmpty(RazaoSocial))
                {
                    filtro = true;
                    listaClientePJ.AddRange(model.ListaClientePJ.FindAll(w => w.RazaoSocial.Contains(RazaoSocial)));
                }

                if (!string.IsNullOrEmpty(NomeFantasia))
                {
                    filtro = true;
                    listaClientePJ.AddRange(model.ListaClientePJ.FindAll(w => w.NomeFantasia.Contains(NomeFantasia)));
                }

                if (filtro)
                    model.ListaClientePJ = listaClientePJ;

                model.CadastroClientePJ = new ClientePJ_DTO();
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
                    ClientePJ_DTO clientePJ = new ClientePJ_DTO();
                    clientePJ = model.ListaClientePJ.Where(w => w.IdClientePJ == id).FirstOrDefault();

                    if (clientePJ.IdClientePJ == 0)
                    {
                        model.MensagemRetorno = "E1 - Erro ao selecionar cliente.";
                        return RedirectToAction("Index");
                    }
                    model.CadastroClientePJ = clientePJ;
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
        public ActionResult Cadastro(ClientePJModel model)
        {
            try
            {
                model.CadastrarClientePJ();
            }
            catch
            {
                model.MensagemRetorno = model.CadastroClientePJ.IdClientePJ== 0 ? "E3 - Erro ao cadastrar cliente." : "E3 - Erro ao atualizar cadastro do cliente.";
            }
            return RedirectToAction("Index", "ClientePJ");
        }
    }
}