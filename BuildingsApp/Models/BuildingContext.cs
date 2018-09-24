using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BuildingsApp.Models
{
    public class BuildingContext : DbContext
    {
        public BuildingContext() : base("BuildingsApp")
        {
        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}