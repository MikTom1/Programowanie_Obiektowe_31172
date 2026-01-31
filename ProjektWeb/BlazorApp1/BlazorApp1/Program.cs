using System.Collections.Immutable;
using BlazorApp1.Components;
using BlazorApp1.Components.Database;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using BlazorApp1.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



builder.Services.AddDbContext<SportShopDb>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Db");
    options.UseNpgsql(connectionString);
});
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderPositionService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();