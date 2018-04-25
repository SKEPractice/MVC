using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Part11_Creating_Views_To_insert_data.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    }
}