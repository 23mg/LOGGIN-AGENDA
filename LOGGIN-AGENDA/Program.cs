

using Microsoft.EntityFrameworkCore;
using LOGGIN_AGENDA.Models;

using LOGGIN_AGENDA.Servicios.Contrato;
using LOGGIN_AGENDA.Servicios.Implementacion;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;



namespace LOGGIN_AGENDA
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DbAccesoContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql"));
            });

            builder.Services.AddDbContext<DbAgendaContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
            });


            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

            builder.Services.AddControllersWithViews(options => {
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}