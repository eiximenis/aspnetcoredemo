using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Data
{
    public class TodoListDataContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoListDataContext(DbContextOptions<TodoListDataContext> options, IMediator mediator) : base(options)
        { 
            _mediator = mediator;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);
            modelBuilder.Entity<TodoItem>().ToTable("TBL_TODOITEMS");
            modelBuilder.Entity<TodoItem>().Property(x => x.Text).HasColumnName("TodoItemText");
        }

        public override int SaveChanges()
        {
            var evts = new List<DomainEvent>();
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity as BaseEntity;
                foreach (var evt in entity.Events())
                {
                    evts.Add(evt);
                }
            }

            var ret = base.SaveChanges();


            foreach (var evt in evts)
            {
                _mediator.Send(evt);
            }

            return ret;
        }
    }
}
