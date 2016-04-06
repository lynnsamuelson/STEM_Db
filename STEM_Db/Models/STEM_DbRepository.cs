using System;
using System.Collections.Generic;
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

        
    }
}