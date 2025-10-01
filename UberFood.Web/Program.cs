using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IDrinksService, DrinksService>(client => 
{
    client.BaseAddress = new Uri("https://localhost:7018/api/drinks");
});
builder.Services.AddHttpClient<IIngredientsService, IngredientsService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7018/api/ingredients");
});
builder.Services.AddHttpClient<IUsersService, UsersService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7018/api/users");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
