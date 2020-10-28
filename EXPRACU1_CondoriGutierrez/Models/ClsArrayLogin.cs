using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXPRACU1_CondoriGutierrez.Models
{
    public class ClsArrayLogin
    {
        public List<string> usuario { get; set; }
        public List<string> password { get; set; }
        public List<string> resultado { get; set; }
        public string id { get; set; }
        public string contra { get; set; }
        public string aceptado { get; set; }
    }
}