using E_Esecurity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Esecurity.DataAccess
{
    public class BaseDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EandESecurity;Trusted_Connection=true");

        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Reports> Reports { get; set; }
    }
}