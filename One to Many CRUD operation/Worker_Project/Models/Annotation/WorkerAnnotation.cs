using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Worker_Project.Models.Annotation
{
    public class WorkerAnnotation
    {
        public int WorkerId { get; set; }
        [Required,StringLength(30),Display(Name ="Worker Name")]
        public string WorkerName { get; set; }
        [Required, Column(TypeName ="money")]
        public decimal Salary { get; set; }
        [StringLength(200)]
        public string Picture { get; set; }
        [Required]
        public int TypeId { get; set; }
    }
}