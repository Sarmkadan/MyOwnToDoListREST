using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyTodoList_1.Controllers
{
    public class LayoutController : ApiController
    {
        // GET: api/Layout
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Layout/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Layout
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Layout/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Layout/5
        public void Delete(int id)
        {
        }
    }
}
