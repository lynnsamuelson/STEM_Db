using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_Db.Models
{
    public class Fact
    {
        [key]
        public int FactId { get; set; }
        public string FactText { get; set; }
        public string Author { get; set; }
        public bool IsQuote { get; set; }
    }
}