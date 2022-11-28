using Api.Infrustructure.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;
services.AddControllers();
services.AddHealthChecks();


services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>();


var connection = builder.Configuration.GetConnectionString("ConnctionString");
services.AddDbContext<Persistence.DatabaseContext>(opt =>
{
	opt.UseSqlServer(connection);
	opt.EnableSensitiveDataLogging();
	opt.UseLazyLoadingProxies();

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseExceptionHandling();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthcheck");

app.Run();





public partial class Program{}