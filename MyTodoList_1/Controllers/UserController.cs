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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace MyTodoList_1.Controllers
{
    public class UserController : ApiController
    {

        UserDbContext db = new UserDbContext();
        // GET: api/Layout
        [Route("api/Users")]
        public IEnumerable<Users> Get()
        {
            var a = db.ItemDbSet.AsQueryable().ToList();
            return a;
        }

        // GET: api/Layout/5
        [Route("api/Users/{id}")]
        public Users Get(int id)
        {
            Users item = db.ItemDbSet.Find(id);
            return item;
        }

        public string CalculateMD5Hash(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);

            return result;
        }

        // POST: api/Layout
        [Route("api/Users")]
        public Result Post([FromBody] Users value)
        {
            Result result = new Result();

            if (null != value)
            {
                /* if (null == (db.ItemDbSet.First(b => b.Name == value.Name)))
                {*/
                foreach (var x in db.ItemDbSet)
                {
                    if (x.Name == value.Name)
                    {
                        result.Status = "Name exist";
                        return result;
                    }
                }
                // }
                //return value.ToString();
                Users newUsers = value;
                newUsers.Password = CalculateMD5Hash(newUsers.Password);
                newUsers.GroupId = 1;
                db.ItemDbSet.Add(newUsers);
                db.SaveChanges();
                result.Status = "Ok";

                Users finduser = new Users();
                finduser = db.ItemDbSet.FirstOrDefault(b => b.Name == value.Name);
                result.Id = finduser.Id;
                return result;
            }
            result.Status = "Fail";
            return result;
        }
    }
}
