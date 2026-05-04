using ControleAtendimentos.Data;
using ControleAtendimentos.DTOs.AtendimentoDTO;
using ControleAtendimentos.DTOs.ChamadoDTO;
using ControleAtendimentos.DTOs.PrioridadeDTO;
using ControleAtendimentos.DTOs.SetorDTO;
using ControleAtendimentos.Repositorys;
using ControleAtendimentos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AtendimentoRepository>();
builder.Services.AddScoped<ChamadoRepository>();
builder.Services.AddScoped<PrioridadeRepository>();
builder.Services.AddScoped<SetorRepository>();

builder.Services.AddScoped<AtendimentoMapper>();
builder.Services.AddScoped<ChamadoMapper>();
builder.Services.AddScoped<PrioridadeMapper>();
builder.Services.AddScoped<SetorMapper>();

builder.Services.AddScoped<AtendimentoService>();
builder.Services.AddScoped<ChamadoService>();
builder.Services.AddScoped<PrioridadeService>();
builder.Services.AddScoped<SetorService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
