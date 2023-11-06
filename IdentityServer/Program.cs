using IdentityServer;
using IdentityServer4;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");
var assembly = typeof(Program).Assembly.GetName().Name;

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(config =>
{
	config.Password.RequiredLength = 4;
	config.Password.RequireNonAlphanumeric = false;
	config.Password.RequireDigit = false;
	config.Password.RequireUppercase = false;
})
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
	options.Events.RaiseErrorEvents = true;
	options.Events.RaiseInformationEvents = true;
	options.Events.RaiseFailureEvents = true;
	options.Events.RaiseSuccessEvents = true;

	options.EmitStaticAudienceClaim = true;
})
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
	{
		options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, 
			sql => sql.MigrationsAssembly(assembly));
	})
	.AddOperationalStore(options =>
	{
		options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString,
			sql => sql.MigrationsAssembly(assembly));
		options.EnableTokenCleanup = true;
	})
	.AddDeveloperSigningCredential();
	
builder.Services.AddAuthentication()
	.AddGoogle(options =>
	{
		options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

		options.ClientId = configuration.GetValue<string>("GoogleClientId");
		options.ClientSecret = configuration.GetValue<string>("GoogleClientSecret");
	});

var app = builder.Build();

app.AddStorage(configuration);
app.UseHsts();

app.UseHttpsRedirection();
app.UseRouting();

app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapDefaultControllerRoute();
});

app.Run();
