using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyTodoList_1.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MyTodoList_1.Controllers
{


    //  [Authorize]
    public class GroupController : ApiController
    {
        private GroupDbContext db = new GroupDbContext();

        // GET api/values
        [Route("api/Group")]
        public IEnumerable<Group> Get()
        {

            var a = db.ItemDbSet.AsQueryable().ToList();
            return a;

        }

        // POST api/values
        [Route("api/Group")]
        public Result Post([FromBody] Group value)
        {
            Result endResult = new Result();
            if (null != value)
            {

                endResult.Status = "Ok";
                db.ItemDbSet.Add(value);
                db.SaveChanges();
                var b = db.ItemDbSet.FirstOrDefault(B => B.Name == value.Name);
                endResult.Id = b.Id;
                return endResult;
            }

            endResult.Status = "fail";
            return endResult;
        }


    }
}
