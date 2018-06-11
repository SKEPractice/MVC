using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Part11_Creating_Views_To_insert_data.Models.Interfaces;
namespace Part11_Creating_Views_To_insert_data.Models
{
    [Table("tblStudent")]
    public class Student : IStudent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime ? DateOfBirth { get; set; }
    }
}