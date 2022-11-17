using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using BankingDataAccess.Persistence.UnitiesOfWork;
using Microsoft.EntityFrameworkCore;
using UserClients.BusinessLogic.Core.Registration;
using UserClients.DataAccess.Core.Registration;
using UserClients.DataAccess.Database.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
var optionsBuilder = new DbContextOptionsBuilder<GenericContext>();
optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("BankingSeeding");
builder.Services.AddSingleton(optionsBuilder.Options);*/


/*builder.Services.AddDbContextPool<DbContext, GenericContext>(options => options
    // replace with your connection string
    .UseLazyLoadingProxies().
    UseInMemoryDatabase("BankingSeeding"));*/

builder.Services.AddDbContextPool<DbContext, GenericContext>(options => options
    // replace with your connection string
    .UseLazyLoadingProxies().
    UseSqlite("Data Source=../../../../../../../Data/BankingSeeding.db"));



builder.Services.AddScoped<IUnitOfWorkV2, UnityOfWorkV2>();

builder.Services.AddScoped<IUnityOfWork<Customer>, UnityOfWorkInMemory<Customer>>();
builder.Services.AddScoped<IUnityOfWork<Addresses>, UnityOfWorkInMemory<Addresses>>();
builder.Services.AddScoped<IRegistrationDataAccess, RegistrationDataAccess>();
builder.Services.AddScoped<IRegistrationDataAccessService, RegistrationDataAccessService>();
builder.Services.AddScoped<IRegistrationLogicService, RegistrationLogicService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();