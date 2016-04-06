using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace STEM_Db.Models
{
    public class Experiment
    {
        [key]
        public int ExperimentId { get; set; }
        public string ExperimentTitle { get; set; }
        public string ExperimentCatagory { get; set; }
        public Image Experimentpicture { get; set; }
        public string ExperimentBackground { get; set; }
        public string ExperimentProcedure { get; set; }
        public string ExperimentSummary { get; set; }
        public string SupplyList { get; set; }
        
    }
}