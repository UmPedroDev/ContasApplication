using ContasApplication.Data;
using ContasApplication.Repository;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

//Adicionamos o atualizador autom�tico de p�ginas Razor
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

//Adicionamos a comunica��o com o banco de dados.
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BankContext>(a => a.UseSqlServer(
                "Server=testeazuregravacao.database.windows.net;Database=TesteAzure;User Id=pedroHenrique;Password=2610#Gabi;"));


builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddDistributedMemoryCache();  // Usar mem�ria para cache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Define o tempo de expira��o da sess�o
    options.Cookie.HttpOnly = true;  // Seguran�a
    options.Cookie.IsEssential = true;  // Necess�rio para conformidade com GDPR
});

var app = builder.Build();

builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environments.Production
});

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithRedirects("/Home/Error?code={0}");
    app.UseHsts();
}

var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
