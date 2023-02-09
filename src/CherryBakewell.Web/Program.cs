using CherryBakewell.Base.Interfaces;
using CherryBakewell.Base;
using Microsoft.EntityFrameworkCore;
using CherryBakewell.Database;
using CherryBakewell.Web.Helpers;
using CherryBakewell.Base.Interfaces.Repository;
using CherryBakewell.Base.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add Database
builder.Services.AddDbContext<DAL>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//Add dependency injection.
builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<ICalculationRepository, CalculationRepository>();

//Auto Mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
