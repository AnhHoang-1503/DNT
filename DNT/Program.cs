using DNT;
using DNT.Domain;
using DNT.Domain.Common;
using DNT.Domain.Service;
using DNT.Infrastructure;
using DNT.Infrastructure.Repository;
using DNT.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration["ConnectionString"];
var serverVersion = new MariaDbServerVersion(new Version(10, 5, 23));


// Add controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Connect DB, create dbcontext for efcore
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(conectionString, serverVersion)
    );

// User DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService, UserService>();

// ForHelpRequest
builder.Services.AddScoped<IForHelpRequestRepository, ForHelpRequestRepository>();
builder.Services.AddScoped<ForHelpRequestService, ForHelpRequestService>();

// Auth DI
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<LoginService, LoginService>();

builder.Services.AddScoped<UserSessionState, UserSessionState>();

// Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.Events = new JwtBearerEvents()
    {
        OnTokenValidated = context =>
        {
            var userSessionState = context.HttpContext.RequestServices.GetRequiredService<UserSessionState>();

            var claims = context.Principal?.Claims;

            var userName = claims?.FirstOrDefault(c => c.Type == "name");

            var userId = claims?.FirstOrDefault(c => c.Type == "user_id");


            if (userName != null)
            {
                userSessionState.Name = userName.Value;
            }

            if (userId != null)
            {
                userSessionState.Id = Guid.Parse(userId.Value);
            }

            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<Middleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
