using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Worker_Project.Models.Annotation
{
    public class WorkertypeAnn
    {
        public int TypeId { get; set; }
        [Required,StringLength(20),Display(Name = "Type Name")]
        public string TypeName { get; set; }
    }
}