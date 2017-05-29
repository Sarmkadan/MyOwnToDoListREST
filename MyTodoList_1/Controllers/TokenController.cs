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
using System.Data.Entity;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using Antlr.Runtime;
using Microsoft.Ajax.Utilities;

namespace MyTodoList_1.Controllers
{
    public class TokenController : ApiController
    {

        private TokensDbContext db = new TokensDbContext();
        private UserDbContext dbUsers = new UserDbContext();
        // GET: api/Layout
        [Route("api/Token")]
        public Token Put([FromBody]Users ab)
        {
            if (ab!=null)   // если есть юзер
            {
                Token tokens = new Token();
                if (dbUsers.ItemDbSet.FirstOrDefault(I => I.Name == ab.Name) != null)  // если имя есть в базе
                {
                    var e = dbUsers.ItemDbSet.FirstOrDefault(I => I.Name == ab.Name);
                    if (e.Password == CalculateMD5Hash(ab.Password))    //если пароль совпадает
                    {
                        tokens.Date = DateTime.Now;
                        tokens.Value = CalculateMD5Hash(tokens.Date.ToString("G") + ab.Name);
                        tokens.GroupId = e.GroupId;
                        db.ItemDbSet.Add(tokens);
                        db.SaveChanges();
                    }
                }
                Token a = db.ItemDbSet.FirstOrDefault(I => I.Value == tokens.Value);
                return a;
            }
            return null;
        }

        public string CalculateMD5Hash(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);

            return result;
        }

    }
}
