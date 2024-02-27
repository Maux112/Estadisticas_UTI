//Esto es para guardar el inicio de session (autenticacion)del usuario 
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Añade datos a las cokies como donde es el logeo y su duracion
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        //Donde logeamos
        option.LoginPath = "/Login/Login";
        option.AccessDeniedPath = "/AuxiliarViews/AccesoDenegado";
        //Expiracion
        option.ExpireTimeSpan = TimeSpan.FromMinutes(120);

    });
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/AuxiliarViews/Excepcion");
}
app.UseStaticFiles();

app.UseRouting();

//Para la Autenticacion
app.UseAuthentication();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
