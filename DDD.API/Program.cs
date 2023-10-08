using System.Text;
using DDD.API.Middlewares;
using DDD.Application;
using DDD.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "JWT";
        options.DefaultChallengeScheme = "JWT";
    })
    .AddJwtBearer("JWT", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(
                    builder.Configuration.GetValue<string>("Authentication:Key") 
                    ?? throw new InvalidOperationException()))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddTransient<ExceptionHandler>();
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Default")??"");
var app = builder.Build();
app.UseMiddleware<ExceptionHandler>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
