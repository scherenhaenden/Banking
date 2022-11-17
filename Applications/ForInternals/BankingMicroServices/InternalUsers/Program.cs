using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Persistence.UnitiesOfWork;
using InternalUsers.BusinessLogic.Core;
using InternalUsers.DataAccess.Core;
using InternalUsers.DataAccess.Core.Domain;
using InternalUsers.DataAccess.Database.Domain;
using InternalUsers.DataAccess.Database.Domain.Login;
using InternalUsers.DataAccess.Database.Logic.Login;
using InternalUsers.Services.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// get current directory
var currentDirectory = Directory.GetCurrentDirectory();

builder.Services.AddDbContextPool<DbContext, GenericContext>(options => options
    // replace with your connection string
    .UseLazyLoadingProxies().
    //UseSqlite("Data Source=/Users/edwardflores/Projects/Development/micro-service-learning/Example/Bank/Data/BankingSeeding.db"));
    UseMySQL("Server=localhost; Port=13306;database=db;uid=root;pwd=password"));


ServiceCollectionCollector serviceCollectionCollector = new ServiceCollectionCollector();

serviceCollectionCollector.FillTheCollection(builder.Services);



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

app.Run("http://localhost:60001");