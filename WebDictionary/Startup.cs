using DataAccessLayer;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionary
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
             services.AddDbContext<DictionaryDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("MssqlConnection")));
             services.AddControllersWithViews();

           // services.AddScoped<IRepositoryWord, WordRepositoryJson>();
            services.AddScoped<IRepositoryWord,WordRepository>();


            /////////////////////////Test örneği ile instanceCount sayımı,abstraction////////////////////////////////
          //  services.AddTransient<Test>();/////////ne  zaman ihtiyaç olursa bir test objesi üret.///////////////
            //services.AddSingleton<Test>();/////////bir tane üretir eğer yine ihtiyaç olursa aynısını kullan.///////
           // services.AddScoped<Test>();////////1 request boyunca bir tane üretir,ihtiyaç olursa 1 tane daha üretir.
            //services.AddTransient<Test>();
            //services.AddTransient<Test1>();
            //services.AddTransient<Deneme>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
                   //pattern: "{controller=Home}/{action=CreateWord}/{id?}");
            });
        }
    }
}
