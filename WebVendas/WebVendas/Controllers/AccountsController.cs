using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebVendas.Data;
using WebVendas.Models;


namespace WebVendas.Controllers
{
    public class AccountsController : Controller
    {
        Users_dbEntities entity = new Users_dbEntities();
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials )
        {
            bool userExist = entity.ACESSO.Any(x => x.EMAIL == credentials.EMAIL && x.SENHA == credentials.PASSWORD);
            ACESSO u = entity.ACESSO.FirstOrDefault(x => x.EMAIL == credentials.EMAIL && x.SENHA == credentials.PASSWORD);
            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.NOME, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Usuario ou senha estão incorretos!");

            return View();
        }
        [HttpPost]
        public ActionResult SignUp(ACESSO userinfo )
        {
            entity.ACESSO.Add(userinfo);
            entity.SaveChangesAsync();
            return RedirectToAction("Login");
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            
            return RedirectToAction("Home");
        }
    }
}