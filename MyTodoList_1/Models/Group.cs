using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyTodoList_1.Models
{
    public class GroupDbContext : DbContext
    {
        public GroupDbContext() : base("Connstring") { }
        public DbSet<Group> ItemDbSet { get; set; }
    }
    public class Group
    {
        public Nullable<int> Id { get; set; }
        public string Name { get; set; }
    }
}
