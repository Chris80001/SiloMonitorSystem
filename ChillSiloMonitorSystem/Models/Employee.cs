using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChillSiloMonitorSystem.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Head")]
        public int HeadID { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Prefix { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Title { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string MobilePhone { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
    }
}