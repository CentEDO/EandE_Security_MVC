using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Esecurity.Models
{
    public class Company
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}