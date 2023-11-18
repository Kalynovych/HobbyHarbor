using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Infrastructure;
using HobbyHarbor.Infrastructure.Data;
using HobbyHarbor.WebUI.Middlewares;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
	.AddDataAnnotationsLocalization()
	.AddViewLocalization();

builder.Services.AddHttpClient();

builder.Services.AddStorage(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<IFileStorageService, LocalFileStorageService>();

builder.Services.AddAuthentication(config =>
{
	config.DefaultScheme = "Cookie";
	config.DefaultChallengeScheme = "oidc";
})
	.AddCookie("Cookie")
	.AddOpenIdConnect("oidc", config =>
	{
		config.Authority = "https://localhost:5001/";
		config.ClientId = "client_mvc";
		config.ClientSecret = "client_secret";
		config.ResponseType = "code";

		config.UsePkce = true;
		config.SaveTokens = true;

		config.ResponseType = "code";
		config.Scope.Add("api_one");
		config.Scope.Add("profile");
		config.Scope.Add("openid");
		config.Scope.Add("email");
		config.Scope.Add("offline_access");

		config.AccessDeniedPath = "/Home/Index";
		config.SignedOutCallbackPath = "/Home/Index";
        config.GetClaimsFromUserInfoEndpoint = true;
	});

builder.Services.AddLocalization(options =>
{
	options.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedCultures = new[] { "en", "uk-UA" };
	options.SetDefaultCulture("eu");
	options.AddSupportedCultures(supportedCultures);
	options.AddSupportedUICultures(supportedCultures);
});

var app = builder.Build();
await app.CreateDatabase();

if (!app.Environment.IsDevelopment())
{
	app.UseMiddleware<ExceptionHandlingMiddleware>();
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
