using System.Text;
using BankingClientBackend.EnviromentConfigs;
using BankingClientBackend.Services.Middlewares.Cors;
using BankingClientBackend.Services.Middlewares.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "My API", 
        Version = "v1" 
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        In = ParameterLocation.Header, 
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey 
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { 
            new OpenApiSecurityScheme 
            { 
                Reference = new OpenApiReference 
                { 
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer" 
                } 
            },
            new string[] { } 
        } 
    });
});
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettings);
var realSettings = appSettings.Get<AppSettings>();
/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{        
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //var key = Encoding.ASCII.GetBytes(_appSettings.SecretJwtKey);
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = appSettings["Jwt:Issuer"],
        ValidAudience = appSettings["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(realSettings.SecretJwtKey))
    };
});*/

/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearerConfiguration(
        appSettings["Jwt:Issuer"],
        appSettings["Jwt:Audience"]
    );*/



//var appSettingsSection = Configuration.GetSection("AppSettings");


builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<JwtTokenGenerator>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Add Simple cors policy for development.
    app.UseCors(builder => builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials()
    );
    app.UseCorsMiddleware();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ReadAndResponseJWT>();

app.MapControllers();

app.Run();