using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebVendas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
            [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sistema Generico de Vendas Online!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contatos";

            return View();
        }
    }
}