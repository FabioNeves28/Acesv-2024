using Acesv2.Models;
using Acesvv.Areas.Identity.Data;
using Acesvv.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AcesvvContextConnection") ?? throw new InvalidOperationException("Connection string 'AcesvvContextConnection' not found.");

builder.Services.AddDbContext<AcesvvContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<UsuarioModel>(options => options.SignIn.RequireConfirmedAccount = false)
.AddEntityFrameworkStores<AcesvvContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BD>();
builder.Services.AddScoped<ChaveADMRequirement>();

var app = builder.Build();

var cultureInfo = new CultureInfo("pt-BR");  CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
