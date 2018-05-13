using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Part3.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}