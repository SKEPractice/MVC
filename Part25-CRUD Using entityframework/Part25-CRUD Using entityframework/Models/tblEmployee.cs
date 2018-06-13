using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Part25_CRUD_Using_entityframework.Models
{
    [MetadataType(typeof(MetaDataEmployee))]
    public partial class Employee
    {

    }
    public class MetaDataEmployee
    {
        public int EmployeeID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
    }
}