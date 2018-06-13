using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Part25_CRUD_Using_entityframework.Models
{
    [MetadataType(typeof(MetaDataType))]
    public partial class Department
    {

    }
    public class MetaDataType
    {
        [Display(Name = "Department Name")]
        public string Name { get; set; }
    }
}