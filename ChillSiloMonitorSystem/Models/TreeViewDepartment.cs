using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChillSiloMonitorSystem.Models
{
    public class TreeViewDepartment
    {
        public string ID { get; set; }
        public string CategoryId { get; set; }
        public string Text { get; set; }
        public bool Expanded { get; set; }
        public IEnumerable<TreeViewDepartment> Items { get; set; }
    }
}