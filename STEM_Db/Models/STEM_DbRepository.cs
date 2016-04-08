using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;

namespace STEM_Db.Models
{
    public class STEM_DbRepository
    {
        private STEM_DbContext _context;
        public STEM_DbContext Context { get { return _context;} }

        public STEM_DbRepository()
        {
            _context = new STEM_DbContext();
        }

        public STEM_DbRepository(STEM_DbContext a_context)
        {
            _context = a_context;
        }

        public List<Blog> GetAllBlogs()
        {
            var query = from Blogs in _context.Blogs select Blogs;
            return query.ToList();
        }

        public Blog GetBlog(int blogId)
        {

            var query = from blog in _context.Blogs where blog.BlogId == blogId select blog;
            return query.SingleOrDefault();

        }

        public List<Experiment> GetAllExperiments()
        {
            var query = from expermients in _context.Experiments select expermients;
            return query.ToList();
        }

        public Experiment GetExperimentById(int Id)
        {
            var query = from experiment in _context.Experiments where experiment.ExperimentId == Id select experiment;
            return query.SingleOrDefault();
        }

        public List<Experiment> GetExperimentByCatagory(string catagory)
        {
            var query = from experiment in _context.Experiments where experiment.ExperimentCatagory == catagory select experiment;
            return query.ToList();
        }

        public List<Fact> GetAllFacts()
        {
            var query = from fact in _context.Facts select fact;
            return query.ToList();
        }

        public Fact GetFact(int factId)
        {
            var query = from fact in _context.Facts where fact.FactId == factId select fact;
            return query.SingleOrDefault();
        }

        public List<Fact> GetQuotes()
        {
            var query = from fact in _context.Facts where fact.IsQuote == true select fact;
            return query.ToList();
        }

        public List<KidQuestions> GetQuestions()
        {
            var query = from question in _context.KidQuestions select question;
            return query.ToList();
        }

        public KidQuestions GetQuestion(int Id)
        {
            var query = from question in _context.KidQuestions where question.QuestionId == Id select question;
            return query.SingleOrDefault();
        }
    }
}