using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Data;
using Ordering.Data.Extensions;
using Ordering.DatabaseSimulator;
using Ordering.Domain;

var builder = WebApplication.CreateBuilder(args);
var constr = builder.Configuration["db"];
var options = new DbContextOptionsBuilder<OrderingContext>().UseSqlServer(constr, b => b.MigrationsAssembly("Ordering.Api")).Options;
var ctx =  new OrderingContext(options, null);
ctx.Database.Migrate();

// Add services to the container.
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddDbContext<OrderingContext>(opt => opt.UseSqlServer(constr, b => b.MigrationsAssembly("Ordering.Api")));
builder.Services.AddScoped<IUnitOfWork>(sp => sp.GetService<OrderingContext>()); ;
builder.Services.AddSingleton<OrderingDatabase>();
builder.Services.AddRepositories();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
