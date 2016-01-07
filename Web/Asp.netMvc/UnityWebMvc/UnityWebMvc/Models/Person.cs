using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace UnityWebMvc.Models
{
    public class Person
    {
        //[ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [Display(Name="Contact Information")]
        public string ContactInfo { get; set; }
    }
}