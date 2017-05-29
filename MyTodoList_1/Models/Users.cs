using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyTodoList_1.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("Connstring") { }
        public DbSet<Users> ItemDbSet { get; set; }


    }
    public class Users
    {
        public Nullable<int> Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string Password { get; set; }
    }
}
