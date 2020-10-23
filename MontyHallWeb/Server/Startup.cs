using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MontyHallLibrary.Contracts;
using MontyHallService;
using MontyHallService.Contracts;
using MontyHallService.SettingsModel;
using System;
using System.Linq;

namespace MontyHallWeb.Server
{
    public class Startup
    {
        Random _rand = new Random((int)DateTime.Now.Ticks);
        MontyHallSetting _setting; 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _setting = Configuration.GetSection("GameSetting").Get<MontyHallSetting>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_rand);
            services.AddSingleton(_setting);
            services.AddScoped<IMontyHallSimulationService, MontyHallSimulationService>();
            services.AddScoped<IMontyHallFactory, MontyHallFactory>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
