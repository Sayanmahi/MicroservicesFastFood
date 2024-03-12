using Microservice.WebBlazor.Data;
using Microservice.WebBlazor.Service.IService;
using Microservice.WebBlazor.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICategoryService, CategoryService>();
SD.CategoryAPIBase = builder.Configuration["ServiceUrls:CategoryAPI"];

builder.Services.AddHttpClient<IItemService, ItemService>();
SD.CategoryAPIBase = builder.Configuration["ServiceUrls:ItemAPI"];

builder.Services.AddHttpClient<ILoginService, LoginService>();
SD.LoginAPIBase = builder.Configuration["ServiceUrls:LoginAPI"];
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ILoginService,LoginService>();   
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IItemService,ItemService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCookiePolicy();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
