using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part11_Creating_Views_To_insert_data.Models.Interfaces
{
    public class IStudent
    {
        int ID { get; set; }
        string Gender { get; set; }
        string Address { get; set; }
        DateTime DateOfBirth { get; set; }
    }
}