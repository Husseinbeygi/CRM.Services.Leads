using Api.Infrustructure.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;
services.AddControllers();
services.AddHealthChecks();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>();

X509Certificate2 cert = new X509Certificate2("key.pfx", "123456789");
SecurityKey key = new X509SecurityKey(cert);

services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Audience"],
		IssuerSigningKey = key,
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = false,
		ValidateIssuerSigningKey = true
	};
});


services.AddCors(o => o.AddPolicy("BlazorPolicy", builder =>
{
	builder.WithOrigins("https://localhost:7083")
		   .AllowAnyMethod()
		   .AllowAnyHeader();
}));

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


app.UseCors("BlazorPolicy");

app.UseExceptionHandling();

app.UseHttpsRedirection();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthcheck");

app.UseCultureHandler();

app.Run();





public partial class Program { }