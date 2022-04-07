using Cqs.Domain;
using Cqs.Implementation;
using CqsApi;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddSingleton<CustomDbContext>();
builder.Services.AddSingleton<IUnitOfWork>(sp => sp.GetService<CustomDbContext>());
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<ValidationExceptionMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapGet("/orders", OrderQueries.GetAll);
app.MapPost("/orders", OrdersCommands.AddNewOrder);


app.Run();
