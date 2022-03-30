using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TodoItems.Database;
using TodoList.Data;
using TodoList.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(c =>
{
    c.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    c =>
    {
        c.LoginPath = "/Auth/Login";
    });

builder.Services.AddRazorPages(options => options.Conventions.AuthorizePage("/Privacy"));
builder.Services.AddControllersWithViews(opt =>
{
    opt.ModelBinderProviders.Insert(0, new CustomCollectionModelBinderProvider());
});

builder.Services.AddSingleton<TodoItemsDatabase>();
var constr = builder.Configuration["db"];
builder.Services.AddDbContext<TodoListDataContext>(opt => opt.UseSqlServer(constr));
builder.Services.AddDataRepositories();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
