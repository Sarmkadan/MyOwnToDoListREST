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

namespace MyTodoList_1.Controllers
{


  //  [Authorize]
    public class ValuesController : ApiController
    {
        ItemsDbContext db = new ItemsDbContext();
        // GET api/values

        public IEnumerable<Item> Get()
        { 
            //trying get from database
            /*string query = "select * from Table";
            string con ="Data Source=todo3.database.windows.net;Initial Catalog=ToDO.database.windows.net;Persist Security Info=True;User ID=sarmkadan;Password=Vlad123456789";

            string config = "server=localhost;username=mcubic;password=mcs@2011$;database=test";
            MySqlConnection connection = new MySqlConnection(con);
            MySqlCommand command = new MySqlCommand(query, connection);*/


         //   connection.Open();
          /*  MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
            //    a.date = Reader[3].ToString();
             //   a.free = Convert.ToInt32(Reader[4].ToString());
            }*/
          /*  connection.Close();

            query = "select * from test1";

            command = new MySqlCommand(query, connection);
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
           //     r.roomId = Reader[2].ToString();
            }
            connection.Close();*/

          /* Item[] products = new Item[]
     {
            new Item { Id = 1, Value = "Купити все для супу", State = true },
            new Item { Id = 2, Value = "Продати відеокарту", State = false },
            new Item { Id = 3, Value = "Приготувати суп", State = false},
            new Item { Id = 4, Value = "Вионати завдання для лабораторної", State = false},
            new Item { Id = 5, Value = "Створити нове модальне вікно", State = false},
            new Item { Id = 6, Value = "Ввести данні у базу даних", State = false}
     };
            return products;*/

          
            /* var item = new List<dynamic> { new  { Value = "Ale", Id = 30 } };

             return Request.CreateResponse(HttpStatusCode.OK, item);*/
             var a = db.ItemDbSet.AsQueryable();
            return a.ToList();
        }

        // GET api/values/5
        public Item Get(int id)
        {
            Item item = db.ItemDbSet.Find(id);
            return item;
        }

        // POST api/values
     /*   public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        { 
        }*/
    }
}
