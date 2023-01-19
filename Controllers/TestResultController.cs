using E_Esecurity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Esecurity.Controllers
{
    public class TestResultController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();
        // GET: TestResult
        public ActionResult Index()
        {
            if (Session["CompanyId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult TestResults()
        {
            var company = context.Company.SingleOrDefault(x => x.CompanyId == Session["CompanyId"].ToString());
            var reports = (from r in context.Reports where r.CompanyId == company.CompanyId select r).ToList();
            return View(reports);
        }
    }
}