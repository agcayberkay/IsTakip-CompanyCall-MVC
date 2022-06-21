using CompanyCall.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompanyCall.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        IsTakipEntities db = new IsTakipEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Company c)
        {
            var bilgiler = db.Company.FirstOrDefault(x => x.Mail == c.Mail && x.Sifre == c.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("ActiveCall", "Default");
            }
            else
            {
                return RedirectToAction("Index","Views/Login/Index");
            }
           
        }
    }
}