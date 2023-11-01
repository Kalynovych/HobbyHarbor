using HobbyHarbor.Application;
using HobbyHarbor.Infrastructure;
using HobbyHarbor.Infrastructure.Data;
using HobbyHarbor.WebUI.Middlewares;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
	.AddDataAnnotationsLocalization()
	.AddViewLocalization();

builder.Services.AddStorage(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddApplication();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

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
