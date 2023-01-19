using E_Esecurity.DataAccess;
using E_Esecurity.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Esecurity.Controllers
{
    public class MitreAttackController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();
        // GET: MitreAttack
        public ActionResult Index()
        {
            if (Session["CompanyId"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult TestNMap()
        {
            var procInfo1 = new ProcessStartInfo();
            string testCommand = "nmap -Pn -T5 --open -oN nmap_test_result.txt 127.0.0.1";
            procInfo1.UseShellExecute = true;
            procInfo1.WorkingDirectory = @"C:\Windows\SysWOW64";
            procInfo1.FileName = @"C:\Windows\System32\cmd.exe";
            procInfo1.Verb = "runas";
            procInfo1.Arguments = "/c " + testCommand;
            procInfo1.WindowStyle = ProcessWindowStyle.Normal;
            Process process = Process.Start(procInfo1);
            process.WaitForExit();

            string testResult1 = System.IO.File.ReadAllText(@"C:\Windows\SysWOW64\nmap_test_result.txt");
            var today = DateTime.Today;

            var company = context.Company.SingleOrDefault(x => x.CompanyId == Session["CompanyId"].ToString());
            Reports report = new Reports();
            report.CompanyId = company.CompanyId;
            report.TestCategory = 1;
            report.TestDate = today;
            report.TestResult = testResult1;
            context.Reports.Add(report);
            context.SaveChanges();
            Response.Write("<script>alert('Nmap test applied succesfully!');</script>");
            return RedirectToAction("Index", "MitreAttack");
        }
        [HttpPost]
        public ActionResult TestCreateLocalAccount(string accountName, string password)
        {
            var procInfo2 = new ProcessStartInfo();
            string testCommand2 = $"net user /add {accountName} {password}";
            procInfo2.UseShellExecute = true;
            procInfo2.WorkingDirectory = @"C:\Windows\SysWOW64";
            procInfo2.FileName = @"C:\Windows\System32\cmd.exe";
            procInfo2.Verb = "runas";
            procInfo2.Arguments = "/c " + testCommand2;
            procInfo2.WindowStyle = ProcessWindowStyle.Normal;
            Process process2 = Process.Start(procInfo2);
            process2.WaitForExit();

            var procInfo3 = new ProcessStartInfo();
            string testCommand3 = "net user > net_user_test.txt";
            procInfo3.UseShellExecute = true;
            procInfo3.WorkingDirectory = @"C:\Windows\SysWOW64";
            procInfo3.FileName = @"C:\Windows\System32\cmd.exe";
            procInfo3.Verb = "runas";
            procInfo3.Arguments = "/c " + testCommand3;
            procInfo3.WindowStyle = ProcessWindowStyle.Normal;
            Process process3 = Process.Start(procInfo3);
            process3.WaitForExit();

            string testResult2 = System.IO.File.ReadAllText(@"C:\Windows\SysWOW64\net_user_test.txt");
            var today = DateTime.Today;

            var company = context.Company.SingleOrDefault(x => x.CompanyId == Session["CompanyId"].ToString());
            Reports report = new Reports();
            report.CompanyId = company.CompanyId;
            report.TestCategory = 2;
            report.TestDate = today;
            report.TestResult = testResult2;
            context.Reports.Add(report);
            context.SaveChanges();
            Response.Write("<script>alert('Create account test applied succesfully!');</script>");
            return RedirectToAction("Index", "MitreAttack");
        }
    }
}