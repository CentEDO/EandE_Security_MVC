using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Esecurity.Models
{
    public class Reports
    {
        public int Id { get; set; }
        public int TestCategory { get; set; }
        public string TestResult { get; set; }
        public string CompanyId { get; set; }
        public DateTime TestDate { get; set; }

    }
}