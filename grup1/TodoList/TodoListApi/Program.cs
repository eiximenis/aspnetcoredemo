using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoItems.Database;
using TodoList.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TodoItemsDatabase>();
builder.Services.AddMediatR(typeof(Program), typeof(TodoList.Domain.Marker), typeof(TodoList.Data.Marker));
var constr = builder.Configuration["db"];
builder.Services.AddDbContext<TodoListDataContext>(opt => opt.UseSqlServer(constr));
builder.Services.AddDataRepositories();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");

app.MapControllers();

var dbbuilder = new DbContextOptionsBuilder<TodoListDataContext>();
dbbuilder.UseSqlServer(constr);
var dbcontext = new TodoListDataContext(dbbuilder.Options, null);
dbcontext.Database.EnsureCreated();

app.Run();
