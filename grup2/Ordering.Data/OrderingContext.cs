using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Data
{
    public class OrderingContext : DbContext, IUnitOfWork
    {
        private IMediator _mediator;

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public OrderingContext(DbContextOptions<OrderingContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            
            modelBuilder.Entity<Order>().Ignore(o => o.Events);
            modelBuilder.Entity<OrderLine>().Ignore(o => o.Events);
            
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var events = new List<DomainEvent>();
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity as Entity;
                events.AddRange(entity.Events);
            }
            var retVal = await base.SaveChangesAsync(cancellationToken);

            foreach (var evt in events)
            {
                await _mediator.Publish(evt);
            }

            return retVal;

        }
    }
}
