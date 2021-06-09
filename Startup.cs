using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.HttpsPolicy; Comentamos esto ya que no vamos a usar el protocolo HTTPS
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Turnos.Models;

namespace Turnos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Lo siguiente establece la conexion con nuestra base SQL SERVER
            //Entre los signos mayor y menor se define el tipo de contexto, dentro de los parentesis definimos una funcion
            //sin nombre, definimos dentro de ella a opciones como parametro y asignamos a ese parametro el metodo useSqlServer
            //el objeto opciones va a conectarse a SqlServer
            //Configuration es un objeto nativo con el cual accedemos a la cadena de conexion Json,
            //con el metodo GetConnectionString obtenemos el elemento dentro de TurnosContext que contiene la propiedad
            //conectionString(ver en appsettings.json)
            services.AddDbContext<TurnosContext>(opciones => opciones.UseSqlServer(Configuration.GetConnectionString("TurnosContext")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseHttpsRedirection(); Comentamos esto ya que no vamos a usar el protocolo HTTPS
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
