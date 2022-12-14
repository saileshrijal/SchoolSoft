using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolSoft.Data;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Implementations;
using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Services.Implementations;
using SchoolSoft.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

    builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IFacultyService, FacultyService>();
    builder.Services.AddScoped<IProgramService, ProgramService>();
    builder.Services.AddScoped<ISemesterService, SemesterService>();
    builder.Services.AddScoped<IBatchService, BatchService>();
    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddScoped<IParentService, ParentService>();    
}

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNotyf();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
