using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChillSiloMonitorSystem.Models
{
    public class TreeViewHierarchicalData
    {
        public static readonly IEnumerable<TreeViewDepartment> TreeViewDepartments = new[] {
            new TreeViewDepartment {
                Text = "染色課",
                Expanded = true,
            },
            new TreeViewDepartment {
                Text = "複材課",
                Expanded = true,
            },
            new TreeViewDepartment {
                Text = "新材料課",
                Expanded = true,
            }
        };
    }
}