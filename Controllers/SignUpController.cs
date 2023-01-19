using E_Esecurity.DataAccess;
using E_Esecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Esecurity.Controllers
{
    public class SignUpController : Controller
    {
        private readonly BaseDbContext context=new BaseDbContext();
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Company company)
        {
            if (ModelState.IsValid)
            {
                context.Company.Add(company);
                context.SaveChanges();
                HttpContext.Session["CompanyId"] = company.CompanyId;
                Session["CompanyId"] = company.CompanyId;
                Session["CompanyName"] = company.CompanyName;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "SignUp");
        }
    }
}