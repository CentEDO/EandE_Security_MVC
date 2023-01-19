using E_Esecurity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Esecurity.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    }
}