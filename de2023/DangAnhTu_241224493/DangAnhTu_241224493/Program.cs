using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using DangAnhTu_241224493.Models;

=======
using DangAnhTu_241224493.Models; // Đổi đúng namespace của bạn
>>>>>>> 3ab655a (De 2023)


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
<<<<<<< HEAD
builder.Services.AddDbContext<QLNhaSachContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLNhaSachConnection") ?? "Server=localhost\\SQLEXPRESS;Database=QLNhaSach;Trusted_Connection=true;"));
=======
builder.Services.AddDbContext<QlhangHoaContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=QLHangHoa;Trusted_Connection=True;TrustServerCertificate=True;"));
>>>>>>> 3ab655a (De 2023)

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
