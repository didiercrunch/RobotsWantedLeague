using RobotsWantedLeague.Models;
using RobotsWantedLeague.Services;

var builder = WebApplication.CreateBuilder(args);

// database settings

builder.Services.Configure<RobotsDatabaseSettings>(
    builder.Configuration.GetSection("RobotsDatabase"));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<RobotsService>();
builder.Services.AddSingleton<IRobotsService, NotEmptyRobotsService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Robots}/{action=Index}/{id?}");

app.Run();
