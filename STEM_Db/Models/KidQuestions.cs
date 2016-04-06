using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_Db.Models
{
    public class KidQuestions
    {
        [key]
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer {get; set;}
        public DateTime QuestionDate { get; set; }
        public int KidAge { get; set; }
        public string Catagory { get; set; }
                
    }
}