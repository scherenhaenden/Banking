using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Persistence.UnitiesOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmallConsoleView.Data;
using UserClients.BusinessLogic.Core.Registration;
using UserClients.DataAccess.Core.Registration;
using UserClients.DataAccess.Database.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDbContextPool<DbContext, GenericContext>(options => options
    // replace with your connection string
    .UseLazyLoadingProxies().
    UseInMemoryDatabase("BankingSeeding"));

builder.Services.AddScoped<IUnitOfWorkV2, UnityOfWorkV2>();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.Run();