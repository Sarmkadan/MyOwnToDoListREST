using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyTodoList_1.Models
{
    public class TokensDbContext : DbContext
    {
        public TokensDbContext() : base("Connstring") { }
        public DbSet<Token> ItemDbSet { get; set; }
    }
    public class Token
    {
        public Nullable<int> Id { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }
        public Nullable<int> GroupId { get; set; } 
    }
}
