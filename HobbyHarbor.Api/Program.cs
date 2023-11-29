using HobbyHarbor.Application;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var allowOrigins = "_allowOrigins";

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddStorage(builder.Configuration);
builder.Services.AddAutoMapper(typeof(DependencyInjection));
builder.Services.AddApplication();
builder.Services.AddScoped<IFileStorageService, LocalFileStorageService>();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: allowOrigins, policy =>
		{
			policy.WithOrigins("https://localhost:7278");
		});
});

builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please Enter Authentication Token",
		Name = "api_one",
		Type = SecuritySchemeType.ApiKey
	});
});

builder.Services.AddAuthentication("Bearer")
	.AddJwtBearer("Bearer", options =>
	{
		options.Authority = "https://localhost:5001";

		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateAudience = false
		};
	});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("ApiScope", policy =>
	{
		policy.RequireAuthenticatedUser();
		policy.RequireClaim("scope", "api_one");
	});
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ApiScope");
app.UseCors(allowOrigins);

app.Run();
