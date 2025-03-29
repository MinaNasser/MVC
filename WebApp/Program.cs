using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ITIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession(option =>
{
    option.IdleTimeout= TimeSpan.FromMinutes(10);
    
     
});
//Custom Servce "RegisterB
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

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
