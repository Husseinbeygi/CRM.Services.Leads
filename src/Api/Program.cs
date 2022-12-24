using Api.Helpers;
using Api.Infrustructure.Middlewares;
using Framework.Logging.DIConfigurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using System.Security.Cryptography.X509Certificates;


try
{
	var builder = WebApplication.CreateBuilder(args);

	builder.Logging.ClearProviders();
	builder.Host.UseNLog();

	var services = builder.Services;

	services.AddControllers();
	services.AddHealthChecks();

	services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen();

	services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>();

	services
	.AddIdempotentRequest()
	.AddHttpContextAccessor()
	.AddCurrentContextHelper()
	.AddNLogServer();

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

	var connection = builder.Configuration
		.GetConnectionString("ConnctionString");

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

	app.UseIdempotencyCheck();

	app.MapControllers();

	app.MapHealthChecks("/healthcheck");

	app.UseCultureHandler();

	app.Run();

}
finally
{
	// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
	NLog.LogManager.Shutdown();
}




public partial class Program { }