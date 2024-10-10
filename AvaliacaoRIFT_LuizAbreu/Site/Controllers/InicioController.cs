using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class InicioController : Controller
    {
        UtilModel model = new UtilModel();
        // GET: Inicio
        public ActionResult Index()
        {
            ViewBag.Title = "Menu";

            try
            {
                if (!model.StatusLogin)
                    return RedirectToAction("Index", "Login");
            }
            catch
            {

                throw;
            }
            return View(model);
        }
    }
}