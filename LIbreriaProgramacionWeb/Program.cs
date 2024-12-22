using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<LIbreriaProgramacionWeb.Models.LiberiaprograwebContext>(options=>options.UseMySql("server=localhost;user=root;password=root;database=liberiaprograweb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
