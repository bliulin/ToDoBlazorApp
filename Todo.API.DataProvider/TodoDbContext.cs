using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.API.DataProvider.Entities;

namespace Todo.API.DataProvider
{
    public class TodoDbContext : DbContext
    {
        public virtual DbSet<TodoItem> TodoItems { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("data source=localhost\\SQLEXPRESS;Initial Catalog=TodoDb;Integrated Security=True;trusted_connection=true;encrypt=false;");
        }
    }
}
