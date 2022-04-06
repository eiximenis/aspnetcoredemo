using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(
        auth =>
        {
            auth.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
    .AddCookie(cookie => cookie.LoginPath = "/Login")
    .AddOpenIdConnect(oidc =>
    {
        oidc.Authority = "https://localhost:5001";
        oidc.ClientId = "demoweb";
        oidc.ResponseType = "code";
        oidc.UsePkce = true;
        oidc.SaveTokens = true;
        oidc.Scope.Add("scope2");
        oidc.Scope.Add("profile");
        oidc.Scope.Add("openid");
    });
builder.Services.AddRazorPages(opt =>
{
    opt.Conventions.AuthorizePage("/Privacy");
});

builder.Services.AddHttpClient("IdentityServer", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001");
});

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

app.MapGet("/Logout", async ctx =>
{
    await ctx.SignOutAsync();
    ctx.Response.Redirect("/");
});

app.MapRazorPages();

app.Run();


