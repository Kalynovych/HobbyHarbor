using HobbyHarbor.Application;
using HobbyHarbor.Infrastructure;
using HobbyHarbor.Infrastructure.Data;
using HobbyHarbor.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddStorage(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddApplication();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();
await app.CreateDatabase();

if (!app.Environment.IsDevelopment())
{
	app.UseMiddleware<ExceptionHandlingMiddleware>();
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
