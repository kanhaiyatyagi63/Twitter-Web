using Twitter.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//twitter setup 
builder.Services.AddTwitter(config =>
{
    config.Url = "https://api.twitter.com";
    config.ClientId = "Z9kj8JXssqU5Fmym39fxYbYfi";
    config.ClientSecret = "WF2tPvO4sxErhIblIfS0Ke8FFwbZiBpleLt7zHp400az1FIOPO";
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
app.UseStaticFiles();
// twitter middleware
app.UseTwitter();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
