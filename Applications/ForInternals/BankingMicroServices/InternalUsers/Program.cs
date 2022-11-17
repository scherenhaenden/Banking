using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Persistence.UnitiesOfWork;
using InternalUsers.BusinessLogic.Core;
using InternalUsers.DataAccess.Core;
using InternalUsers.DataAccess.Database.Domain;
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


builder.Services.AddScoped<IUnitOfWorkV2, UnityOfWorkV2>();
builder.Services.AddScoped<ILoginDataAccessDataBase, LoginDataAccessDataBase>();
builder.Services.AddScoped<ILoginDataAccess, LoginDataAccess>();
builder.Services.AddScoped<ILogicBusinessLogic, LogicBusinessLogic>();

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