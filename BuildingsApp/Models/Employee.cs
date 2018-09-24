using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuildingsApp.Models
{
    public class Employee
    {
        [ScaffoldColumn(false)]
        public int EmployeeID { get; set; }

        [Required, StringLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public double Salary { get; set; }

        public int? BuildingID { get; set; }

        public virtual Building Building { get; set; }
    }
}