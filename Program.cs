using Labrary2023.Data;
using Labrary2023.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var c = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(c));

builder.Services.AddScoped<Reposotory_author,Implementauthors>();
builder.Services.AddScoped<Reposotorybook,ImplementBook>();
builder.Services.AddScoped<Reposotorybook_author,Implementbook_author>();
builder.Services.AddScoped<ReposotoryCategory,ImplementCategory>();
builder.Services.AddScoped<Reposotoryfine,Implementfine>();
builder.Services.AddScoped<Rreposotoryfine_payment,Implementfine_payment>();
builder.Services.AddScoped<Reposotoryloan, Implementloan>();
builder.Services.AddScoped<Reposotorymember, Implementmember>();
builder.Services.AddScoped<Reposotorymember_state, Implementmember_state>();
builder.Services.AddScoped<Reposotoryreservation_state, Implementreservation_state>();
builder.Services.AddScoped<Reposotoryreservation, Implementreservation>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
