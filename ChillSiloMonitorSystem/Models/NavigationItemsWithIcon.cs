using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChillSiloMonitorSystem.Models
{
    public partial class SampleData
    {
        public static readonly IEnumerable<NavigationItemWithIcon> NavigationItemsWithIcon = new[] {
            new NavigationItemWithIcon {
                id = "Dyeing",
                text = "染色課",
                icon = "mediumiconslayout"
            },
            new NavigationItemWithIcon {
                id = "Multiple",
                text = "複材課",
                icon = "mediumiconslayout"
            },
            new NavigationItemWithIcon {
                id = "New",
                text = "新材料課",
                icon = "mediumiconslayout"
            }
        };
    }
}