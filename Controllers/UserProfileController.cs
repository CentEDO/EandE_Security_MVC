using E_Esecurity.DataAccess;
using E_Esecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Esecurity.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();
        // GET: UserProfile
        public ActionResult Index()
        {
            if (Session["CompanyId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var company = context.Company.SingleOrDefault(u => u.CompanyId == Session["CompanyId"].ToString());
            return View(company);
        }
        [HttpPost]
        public ActionResult ChangeInformations(Company company)
        {
            Company updatedCompany = (from c in context.Company
                                      where c.CompanyId == company.CompanyId
                                      select c).FirstOrDefault();

            if (updatedCompany != null)
            {
                updatedCompany.CompanyName = company.CompanyName;
                updatedCompany.ContactName = company.ContactName;
                updatedCompany.ContactTitle = company.ContactTitle;
                updatedCompany.Phone = company.Phone;
                updatedCompany.City = company.City;
                updatedCompany.Region = company.Region;
                updatedCompany.Address = company.Address;
                updatedCompany.PostalCode = company.PostalCode;
                updatedCompany.Country = company.Country;
                updatedCompany.CompanyId = company.CompanyId;
                updatedCompany.Password = company.Password;
                context.Company.Update(updatedCompany);
                context.SaveChanges();
                ViewBag.Message = "User record updated.";
            }
            else
            {
                ViewBag.Message = "User not found.";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}