using STEM_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace STEM_Db.Controllers
{
    public class BlogController : Controller
    {
        public STEM_DbRepository Repo { get; set; }
        public BlogController() : base()
        {
            Repo = new STEM_DbRepository();
        }

        public BlogController(STEM_DbRepository _repo)
        {
            Repo = _repo;
        }

        public ActionResult Index()
        {
            return View();
        }





        //GET: api/Blog
        public List<Blog> Get()
        {
            return Repo.GetAllBlogs();
        }

        [System.Web.Http.Route("api/Blog/")]
        [System.Web.Http.HttpPost]
        public void Post([FromBody]Blog newBlog)
        {

            Repo.CreateBlog(newBlog.BlogTitle, "this is a test blog", "this is a test summary");

        }

        


    }
}