using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hawk_products_display.Service.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Hawk_products_display.Service.Domain.Interface;
using Hawk_products_display.Service.Domain.DataAccess.Interface;
using Hawk_products_display.Service.Domain.DataAccess;
using Hawk_products_display.Service.DataAccess.Interface;
using Hawk_products_display.Service.DataAccess;

namespace Hawk_products_display
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
            services.AddAutoMapper();
            services.AddScoped<IProductDao, ProductDao>();
            services.AddScoped<ICategoryDao, CategoryDao>();
            services.AddScoped<IProductBuilder, ProductBuilder>();
            services.AddScoped<IPriceCalculator, PriceCalculator>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
