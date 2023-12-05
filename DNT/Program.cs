using DNT;
using DNT.Domain;
using DNT.Infrastructure;
using DNT.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

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

// Auth DI
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<LoginService, LoginService>();

// Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
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
