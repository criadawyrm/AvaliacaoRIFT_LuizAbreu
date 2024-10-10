using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class LoginController : Controller
    {
        LoginModel model = new LoginModel();
        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            try
            {
                
                model.StatusLogin = false;
            }
            catch
            {

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string Usuario, string Senha)
        {
            try
            {
                if (model.Login(Usuario, Senha))
                {
                    return RedirectToAction("Index", "Inicio");
                }
            }
            catch
            {
                model.MensagemRetorno = "E3 - Erro ao realizar Login.";
            }
            return View(model);
        }
    }
}