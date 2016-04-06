using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_Db.Models
{
    public class Fact
    {
        public int FactId { get; set; }
        public string FactText { get; set; }
        public bool IsQuote { get; set; }
    }
}