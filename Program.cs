using JobAppTracker.Demo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("DefaultConnectionOrig") ??
    throw new InvalidOperationException("Connection string not found.");

/*var connStringSqlLite = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string not found.");*/

builder.Services.AddDbContext<JobTrackerContext>(options => options.UseSqlServer(connString));
//builder.Services.AddDbContext<JobTrackerContext>(options => options.UseSqlite(connStringSqlLite));

var app = builder.Build();

var isSwaggerEnabled = builder.Configuration.GetValue<bool>("SwaggerUI");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || isSwaggerEnabled)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();

