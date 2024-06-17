using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChillSiloMonitorSystem.Models
{
    public class ImmediateBoardNew
    {
        [Key]
        public string Id { get; set; }
        public string SettingRowDataId { get; set; }
        public int Sort { get; set; }
        public string Department { get; set; }
        public string PLC { get; set; }
        public string TagAddress { get; set; }
        public string ShowLocation { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public DateTime SaveTime { get; set; }
    }
}