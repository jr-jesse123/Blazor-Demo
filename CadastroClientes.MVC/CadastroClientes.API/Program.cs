using CadastroClientesCore.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CadastroClientesContext>();
builder.Services.AddTransient<RepositorioClientes>();
//builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

var supportedCultures = new[] { new CultureInfo("pt-BR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
});

//app.UseCors(p =>

//    p.AllowAnyOrigin()
//    .AllowAnyHeader()
//    .AllowAnyMethod()
//    .Build()
//);




// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
