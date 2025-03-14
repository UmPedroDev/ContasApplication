using ContasApplication.Data;
using ContasApplication.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adicionamos o atualizador automático de páginas Razor
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

//Adicionamos a comunicação com o banco de dados.
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BankContext>(a => a.UseSqlServer(
            "Server=testeazuregravacao.database.windows.net;Database=TesteAzure;User Id=pedroHenrique;Password=2610#Gabi;"));

builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Despesas}/{action=Index}/{id?}");

app.Run();
