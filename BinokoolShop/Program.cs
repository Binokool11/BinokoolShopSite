using BinokoolShop.Models.AppDbContext;
using BinokoolShop.Models.Entity;
using BinokoolShop.Models.Repository;
using BinokoolShop.Models.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add controlers
builder.Services.AddControllersWithViews();

//Add repository
builder.Services.AddTransient<IGuitarRepository, GuitarsRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => Shop.GetCart(sp));
//Add DB context
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connection));

//Add session
builder.Services.AddSession();
builder.Services.AddMemoryCache();

var app = builder.Build();

//Add static file
app.UseStaticFiles();
app.UseDefaultFiles();
//Add session
app.UseSession();
//Add route
app.MapControllerRoute(name: "default", pattern:"{controller=Home}/{action=Main}/{id?}");

app.Run();
