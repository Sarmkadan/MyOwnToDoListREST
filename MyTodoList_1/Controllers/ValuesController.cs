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
        private UserDbContext ub = new UserDbContext();
        // GET api/values
        [Route("api/Task")]
        public IEnumerable<Item> Get()
        {
           var header = ActionContext.Request.Headers;
            var r = header.GetValues("Token").First();
            if (r != null)
            {
                var a = Autorisation(r);
                if (a != null)
                {
                    var q = db.ItemDbSet.Where(Q => Q.GroupId == a);
                    return q;
                }
                /* var a = db.ItemDbSet.AsQueryable().ToList();
                  return a;*/
            }
            return null; //получаем токен - после получения орпдееляем что там за * может быть*/
        }
        private Nullable<int> Autorisation(string token)
        {
            Token nToken = new Token();
            nToken.Value = token;
            if (tk.ItemDbSet.FirstOrDefault(I => I.Value == nToken.Value) != null) // ПРОВЕРЯЕМ ТОКЕН
            {
                // получити токен и групу - определяем только с групой значения 
                Token Findid = new Token();
                Findid = tk.ItemDbSet.FirstOrDefault(I => I.Value == nToken.Value);
                Users a = new Users();
                a.Id = Findid.UserId;
                Users findgroupUsers = new Users();
                findgroupUsers = ub.ItemDbSet.FirstOrDefault(Q => Q.Id == a.Id);
                return findgroupUsers.GroupId.Value;
            }
            return null;
        }

        // GET api/values/5
        [Route("api/Task/{id}")]
        public Item Get(int id)
        {
            var header = ActionContext.Request.Headers;
            var r = header.GetValues("Token").First();
            if (r != null)
            {
                var a = Autorisation(r);
                if (a != null)
                {
                    var z = db.ItemDbSet.Where(q => q.GroupId == a).Where(w => w.Id == id).FirstOrDefault();
                    return z;
                }
            }
            return null; 
        }

        // POST api/values
        [Route("api/Task")]
        public Result Post([FromBody] Item value)
        {
            Result endResult = new Result();
            if (null != value)
            {
                var header = ActionContext.Request.Headers;
                var r = header.GetValues("Token").First();
                if (r != null)
                {
                    var a = Autorisation(r);
                    if (a != null)
                    {
                        endResult.Status = "Ok";
                        value.GroupId = a.Value;
                        db.ItemDbSet.Add(value);
                        db.SaveChanges();
                        var first = db.ItemDbSet.FirstOrDefault(Q => Q == value);
                        endResult.Id = first.Id;
                        return endResult;
                    }
                }
            }
            endResult.Status = "fail";
            return endResult;
        }

        // PUT api/values/5
        [Route("api/Task/{id}")]
        public Result Put([FromUri]int id, [FromBody] Item value)
        {
            Result endResult = new Result();
            var header = ActionContext.Request.Headers;
            var r = header.GetValues("Token").First();
            if (r != null)
            {
                var a = Autorisation(r);
                if (a != null)
                {
                    Item uploaditem = new Item();
                    uploaditem = db.ItemDbSet.Find(id);
                    if (uploaditem.GroupId == a)
                    {
                        if (value.Value != null)
                        {
                            uploaditem.Value = value.Value;
                        }
                        if (value.State != null)
                        {
                            uploaditem.State = value.State;
                        }
                    }
                   
                    db.SaveChanges();
                    endResult.Status = "Sucsess";
                }
            }
            endResult.Status = "fail";
            return endResult;
        }
        // DELETE api/values/5
        [Route("api/Task/{id}")]
        public Result Delete(int id)
        {
            Result endResult = new Result();
            var header = ActionContext.Request.Headers;
            var r = header.GetValues("Token").First();
            if (r != null)
            {
                var a = Autorisation(r);
                if (a != null)
                {
                    var check = db.ItemDbSet.Find(id);
                    if (check.GroupId == a)
                    {
                        db.ItemDbSet.Remove(db.ItemDbSet.Find(id));
                        db.SaveChanges();
                        endResult.Status = "Value Deleted";
                        endResult.Id = id;
                        return endResult;
                    }
                   
                }
            }
            endResult.Status = "fail";
            return endResult;
        }

    }
}
