using Financev1.Exceptions;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// Add dependencies
builder.Services.AddConfiguration(builder.Configuration); // sets the configuration userid & connection string which will be used globally
builder.Services.AddCustomExceptionHandler(); // custom exception will be implemented here

builder.Services.AddAuthInfrastructure(); // Authentication implementation here
builder.Services.AddManageInfrastructure(); // Manage functionality like user account creation, roles, 

// sets the route to lower cases
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = false;
    options.LowercaseQueryStrings = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
);

// redirect to log in by default 
app.MapGet("/", () => Results.Redirect("/auth/login"));

app.Run();