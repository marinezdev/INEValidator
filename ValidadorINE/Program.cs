using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ValidadorINE.Areas.Persona.Models.Consulta;
using ValidadorINE.Repository.Interface.Administracion;
using ValidadorINE.Repository.Interface.Persona;
using ValidadorINE.Repository.Services.Administracion;
using ValidadorINE.Repository.Services.Persona;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsuarioRepository, UsuarioService>();
builder.Services.AddScoped<IPersonaUsuarioRepository, PersonaUsuarioService>();
builder.Services.AddScoped<IPersonaINERepository, PersonaINEService>();


///CAMBIO PARA RECARGA ACTIVA EN EL PROYECTO
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Administracion/Login/";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        }
    );

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Administracion}/{controller=Login}/{action=Index}/{id?}");

app.Run();