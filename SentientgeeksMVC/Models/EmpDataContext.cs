using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace SentientgeeksMVC.Models
{
    public class EmpDataContext : DbContext
    {
        public EmpDataContext()
            : base("name=constr")
        {
        }
        public DbSet<Employee> employees { get; set; }
    }
}