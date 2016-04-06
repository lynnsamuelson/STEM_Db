using STEM_Db.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace STEM_Db.Models
{
    public class STEM_DbContext : ApplicationDbContext
    {
        public virtual DbSet<Blog> Blogs {get; set;}
        public virtual DbSet<Experiment> Experiments {get; set;}
        public virtual DbSet<Fact> Facts {get; set; }
        public virtual DbSet<KidQuestions> KidQuestions {get; set;}

    }
}