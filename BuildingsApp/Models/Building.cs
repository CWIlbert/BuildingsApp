using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuildingsApp.Models
{
    public class Building
    {
        [ScaffoldColumn(false)]
        public int BuildingID { get; set; }

        [Required, StringLength(50), Display(Name = "Building Name")]
        public string Name { get; set; }

        [Required, StringLength(200), Display(Name = "Building Address")]
        public string Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}