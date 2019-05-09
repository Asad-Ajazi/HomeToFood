using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeToFood.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeToFood
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
            // added my local db to the application
            services.AddDbContextPool<HomeToFoodDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("HomeToFoodDb"));
            });

            //changed from singleton to scoped
            services.AddScoped<IRestaurantData, SqlRestaurantData>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // only used in development to track exceptions in the pipeline and show detailed info about it.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // shows user friendly error message in production.
                app.UseExceptionHandler("/Error");
                // only access through secure connection.
                app.UseHsts();
            }

            //custom middleware;
            //app.Use(SayHelloMiddleWare);

            app.UseHttpsRedirection();
            // static files from wwwroot folder. 
            app.UseStaticFiles();
            // from node_modules folder.
            app.UseNodeModules(env);
            app.UseCookiePolicy();

            app.UseMvc();
        }

        //private RequestDelegate SayHelloMiddleWare(RequestDelegate arg)
        //{
        //    return async ctx =>
        //    {
        //        if (ctx.Path.StartsWithSegments(""))
        //        {
        //            await ctx.Response.WriteAsync("Hello, World");
        //        }
        //        else
        //        {
        //            await NavigationExtensions()
        //        }
                    
        //    };
        //}
    }
}
