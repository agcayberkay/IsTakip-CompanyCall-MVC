using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyCall.Models.Entity;
namespace CompanyCall.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }


        IsTakipEntities db = new IsTakipEntities();
        public ActionResult ActiveCall()
        {
            var Incall = db.InCall.ToList();
            return View(Incall);
        }

        public ActionResult InactiveCall()
        {
            var InactiveCall = db.InCall.Where(x => x.Durum == false).ToList();
            return View(InactiveCall);
        }

        [HttpGet]
        public ActionResult NewCall()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCall(InCall ın)
        {
            ın.Durum = true;
            ın.CallCompany = 1;
            ın.Dates = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.InCall.Add(ın);
            db.SaveChanges();
            return RedirectToAction("ActiveCall");
        }

        public ActionResult InCallDetails(int id)
        {
            var cagri = db.InCallDetails.Where(x => x.Call == id).ToList();
            return View(cagri);
        }
    }
}