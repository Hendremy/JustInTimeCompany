using JustInTimeCompany.Models;
using JustInTimeCompany.Models.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

builder.Services.AddDbContext<JITCDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddRazorPages();
builder.Services.AddIdentity<JITCUser, IdentityRole>()
    .AddDefaultUI()
    .AddEntityFrameworkStores<JITCDbContext>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
    var usermanager = scope.ServiceProvider.GetRequiredService<UserManager<JITCUser>>();
    var rolemanager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    UserSeed.AddDefaultRole(rolemanager);
    UserSeed.AddDefaultUser(usermanager);
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.Run();
