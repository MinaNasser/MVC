using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews(
//    option =>
//    {
//        option.Filters.Add(new HandelErrorAttribute());
//    }


//    );


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ITIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession(option =>
{
    option.IdleTimeout= TimeSpan.FromMinutes(10);
    
     
});
//Custom Servce "RegisterB
builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<ITIContext>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();



var app = builder.Build();

//DEcalre & execute
//naming confinatoin Route (Defain rout with name ,pattern ,default )
//constrint
//Optianl segment
//app.MapControllerRoute("Route1", "R1/{name}/{age:int}/{color?}",
//    new { controller ="Route",action= "Method1" }
//    );
//app.MapControllerRoute("Route2", "R2",
//   new { controller = "Route", action = "Method2" }
//   );



//  app.MapControllerRoute("Route1", "{controller=Route}/{action=Method1}");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



//app.Use(async (httpContext, Next) =>
//    {
//        Console.WriteLine("Middleware 1");
//        await httpContext.Response.WriteAsync("1)Middleware 1\n");
//        await Next.Invoke();
//    });

//app.Use(async (httpContext, Next) =>
//{
//    Console.WriteLine("Middleware 1");
//    await httpContext.Response.WriteAsync("1)Middleware 1\n");
//    await Next.Invoke();
//});
//app.Run(async (httpContext) =>
//{
//    Console.WriteLine("Middleware 3 run");
//    await httpContext.Response.WriteAsync("3=dsds)Middleware 3\n");
//});
//app.Use(async (httpContext, Next) =>
//{
//    Console.WriteLine("Middleware 3");
//    await httpContext.Response.WriteAsync("3)Middleware 3\n");
//    await Next.Invoke();
//});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
