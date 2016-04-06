using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace STEM_Db.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public Image BlogPicture { get; set; }
        public string BlogContent { get; set; }
        public string BlogSummary { get; set; }
        public DateTime DatePublished { get; set; }

    }
}