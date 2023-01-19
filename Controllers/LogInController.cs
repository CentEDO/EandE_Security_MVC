using E_Esecurity.DataAccess;
using E_Esecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Esecurity.Controllers
{
    public class LogInController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();
        
        // GET: LogIn
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Login(Company company)
        {
            try
            {
                var userDb = context.Company.SingleOrDefault(x => x.CompanyId == company.CompanyId && x.Password == company.Password);
                if (userDb != null)
                {
                    HttpContext.Session["CompanyId"] = userDb.CompanyId;
                    Session["CompanyId"] = userDb.CompanyId;
                    Session["CompanyName"] = userDb.CompanyName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Response.Write("<script>alert('CompanyId or password is invalid. Try again!');</script>");
                    return View();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                throw ex;
            }
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}