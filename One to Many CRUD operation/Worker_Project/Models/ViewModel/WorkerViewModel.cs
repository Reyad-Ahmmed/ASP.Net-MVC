using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Worker_Project.Custom_Attribute;

namespace Worker_Project.Models.ViewModel
{
    public class WorkerViewModel
    {
        public int WorkerId { get; set; }
        [Required, Display(Name = "Worker Name")]
        public string WorkerName { get; set; }
        [Required, Column(TypeName = "money"), ValidSalary(ErrorMessage ="Salary must be >= 5000")]
        public decimal Salary { get; set; }
        
        public HttpPostedFileBase Picture { get; set; }
        [Required, Display(Name = "Type Id")]
        public int TypeId { get; set; }
    }
}