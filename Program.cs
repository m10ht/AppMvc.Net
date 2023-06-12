using System.Net;
using App.ExtendMethods;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => {
    // builder.Configuration.GetConnectionString("ConnectionStrings:AppMvcConnectionString");
    string? connectString = builder.Configuration["ConnectionStrings:AppMvcConnectionString"];
    options.UseSqlServer(connectString);
    
});

builder.Services.Configure<RazorViewEngineOptions>(options => {
    //đường dẫn mặc định: /View/Controller/Action.cshtml
                        

    // Thêm đường dẫn để tìm file cshtml để show ra View
    options.PageViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

builder.Services.AddSingleton<PlanetService>();
builder.Services.AddSingleton<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.AddStatusCodePage();   // Tùy biến Response khi có lỗi Code 400 - 599

app.UseRouting();   //EndpointRoutingMiddleware

app.UseAuthorization(); // Xac thuc quyen truy cap

app.MapAreaControllerRoute(
    name: "product",
    areaName: "ProductManage",
    pattern: "{controller}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapControllerRoute(
//     name: "first",
//     pattern: "{url}/{id?}",
//     defaults: new {
//         controller = "First",
//         action = "MyView"
//     },
    // constraints: new {
    //     url = new StringRouteConstraint("xemsanpham"),
    //     id = new RangeRouteConstraint(1,3)
    // });

app.UseEndpoints(e => {
    e.MapGet("/sayhi", async (context) => {
        await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
    });
});
app.Run();
