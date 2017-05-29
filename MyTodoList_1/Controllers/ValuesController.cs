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
    public class ValuesController : ApiController
    {
        private ItemsDbContext db = new ItemsDbContext();
        private TokensDbContext tk = new TokensDbContext();
        // GET api/values
        [Route("api/Task")]
        public IEnumerable<Item> Get()
        {

            var header = ActionContext.Request.Headers;
            var r = header.GetValues("Token").First();
            if (r != null)
            {
                Token nToken = new Token();
                nToken.Value = r;
                if (tk.ItemDbSet.FirstOrDefault(I => I.Value == nToken.Value) != null) // если не нуль
                {
                    // получити токен и групу - определяем только с групой значения 
                    Item findItem = new Item();
                    var a = db.ItemDbSet.AsQueryable().ToList();
                    return a;
                }
            }
            return null; //получаем токен - после получения орпдееляем что там за * может быть
        }
    

    // GET api/values/5
        [Route("api/Task/{id}")]
        public Item Get(int id)
        {
            Item item = db.ItemDbSet.Find(id);
            return item;
        }

        // POST api/values
        [Route("api/Task")]
        public string Post([FromBody] Item value)
        {
            if (null != value)
            {
                //return value.ToString();
                db.ItemDbSet.Add(value);
                db.SaveChanges();
            //    db.ItemDbSet.
                return "Post sucsess id is = ";
            }
            return "Value = null Post fail";
        }
        // PUT api/values/5
        [Route("api/Task/{id}")]
        public void Put([FromUri]int id, [FromBody] Item value)
        {
            Item uploaditem = new Item();
            uploaditem = db.ItemDbSet.Find(id);
            if (value.Value != null)
            {
                uploaditem.Value = value.Value;
            }
            if (value.State !=null)
            {
                uploaditem.State = value.State;
            }
            db.SaveChanges();
          
        }
        // DELETE api/values/5
        [Route("api/Task/{id}")]
        public string Delete(int id)
        {
            db.ItemDbSet.Remove(db.ItemDbSet.Find(id));
            db.SaveChanges();
            return @"[{Status:""Ok""}]";
        }
    }
}
