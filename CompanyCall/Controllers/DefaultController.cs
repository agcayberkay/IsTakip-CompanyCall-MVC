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
            var sesion = Session["Mail"];
            ViewBag.m = sesion;
            var cagrilar = db.InCall.Where(x => x.Durum == true && x.CallCompany == 4).ToList();
            return View(cagrilar);
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

        public ActionResult GetCall(int id)
        {
            var call = db.InCall.Find(id);
            return View("GetCall",call);
        }

        public ActionResult EditCall(InCall ın)
        {
            var call = db.InCall.Find(ın.ID);
            call.Descriptions = ın.Descriptions;
            call.Subjects = ın.Subjects;
            db.SaveChanges();
            return RedirectToAction("ActiveCall");

        }

    }
}