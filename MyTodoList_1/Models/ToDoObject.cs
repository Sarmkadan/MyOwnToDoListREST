using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyTodoList_1.Models
{   
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext() : base("Connstring") { }    
        public DbSet<Item> ItemDbSet { get; set; }
    }   

        public class Item
        {
            public int Id { get; set;}
            public Nullable<bool> State { get; set; }
            public string Value { get; set; }
            public int GroupId { get; set; }
        }
}
