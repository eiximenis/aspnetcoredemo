using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Data
{
    public class TodoListDataContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoListDataContext(DbContextOptions<TodoListDataContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);
            modelBuilder.Entity<TodoItem>().ToTable("TBL_TODOITEMS");
            modelBuilder.Entity<TodoItem>().Property(x => x.Text).HasColumnName("TodoItemText");
        }
    }
}
