using STEM_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace STEM_Db.Controllers
{
    public class STEM_DbController : ApiController
    {
        public STEM_DbRepository Repo { get; set; }
        public STEM_DbController() : base()
        {
            Repo = new STEM_DbRepository();
        }

        public STEM_DbController(STEM_DbRepository _repo)
        {
            Repo = _repo;
        }
        // GET: api/STEM_Db
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/STEM_Db/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/STEM_Db
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/STEM_Db/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/STEM_Db/5
        public void Delete(int id)
        {
        }
    }
}
