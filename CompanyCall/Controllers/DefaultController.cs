using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        public ActionResult HomePage()
        {
            var mail = (string)Session["Mail"];
            ViewBag.c = mail;
            var id = db.Company.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var profile = db.Company.Where(x => x.ID == id).FirstOrDefault();
            var totalCall = db.InCall.Where(x => x.CallCompany == id).Count();
            var activeCall = db.InCall.Where(x => x.CallCompany == id && x.Durum == true).Count();
            var inActiveCall = db.InCall.Where(x => x.CallCompany == id && x.Durum == false).Count();
            var competent = db.Company.Where(x => x.ID == id).Select(y => y.Competent).FirstOrDefault();
            var company = db.Company.Where(x => x.ID == id).Select(y => y.Name).FirstOrDefault();
            var sector = db.Company.Where(x => x.ID == id).Select(y => y.Sector).FirstOrDefault();
            ViewBag.tCall = totalCall;
            ViewBag.aCall = activeCall;
            ViewBag.ınActCall = inActiveCall;
            ViewBag.competent = competent;
            ViewBag.company = company;
            ViewBag.sector = sector;
            return View(profile);
        }


        public PartialViewResult Partial1()
        {
            var mail = (string)Session["Mail"];
            var id = db.Company.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var messages = db.Messages.Where(x => x.Receiver == id && x.Status==true).ToList();
            var totalMessage = db.Messages.Where(x => x.Receiver == id && x.Status==true).Count();
            ViewBag.totalMessage = totalMessage;
            return PartialView(messages);
        }

        public PartialViewResult Partial2()
        {
            var mail = (string)Session["Mail"];
            var id = db.Company.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var activeCall = db.InCall.Where(x => x.CallCompany == id && x.Dates==DateTime.Today).ToList();
            var tactiveCall = db.InCall.Where(x => x.CallCompany == id && x.Dates==DateTime.Today).Count();
            var totalActiveCall = db.InCall.Where(x => x.CallCompany == id && x.Durum==true).Count();      
            ViewBag.totalActCall = tactiveCall;
            return PartialView(activeCall);
        }


        public PartialViewResult Partial3()
        {
            return PartialView();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


        IsTakipEntities db = new IsTakipEntities();
        public ActionResult ActiveCall()
        {
            var mail = (string)Session["Mail"];
            ViewBag.m = mail;
            var id = db.Company.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var cagrilar = db.InCall.Where(x => x.Durum == true && x.CallCompany == id).ToList();
            return View(cagrilar);
        }

        public ActionResult InactiveCall()
        {
            var mail = (string)Session["Mail"];
            var id = db.Company.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var cagrilar = db.InCall.Where(x => x.CallCompany == id && x.Durum == false).ToList();
            //var InactiveCall = db.InCall.Where(x => x.Durum == false).ToList();
            return View(cagrilar);
        }

        [HttpGet]
        public ActionResult NewCall()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCall(InCall ın)
        {
            var mail = (string)Session["Mail"];
            var id = db.Company.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            ın.Durum = true;
            ın.CallCompany = id;
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
            return View("GetCall", call);
        }

        public ActionResult EditCall(InCall ın)
        {
            var call = db.InCall.Find(ın.ID);
            call.Descriptions = ın.Descriptions;
            call.Subjects = ın.Subjects;
            db.SaveChanges();
            return RedirectToAction("ActiveCall");

        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            var mail = (string)Session["Mail"];
            ViewBag.f = mail;
            var id = db.Company.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();

            var profile = db.Company.Where(x => x.ID == id).FirstOrDefault();
            return View(profile);
        }



    }
}