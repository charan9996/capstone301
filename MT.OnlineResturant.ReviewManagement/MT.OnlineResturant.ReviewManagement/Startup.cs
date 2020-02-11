using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MT.OnlineRestaurant.BusinessLayer;
using MT.OnlineRestaurant.DataLayer.Repository;
using MT.OnlineRestaurant.DataLayer.ReviewManagementContext;
using Swashbuckle.AspNetCore.Swagger;

namespace MT.OnlineResturant.ReviewManagement
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = "ReviewManager", Version = "1.0" });
             
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ReviewManagementContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString"),
             b => b.MigrationsAssembly("MT.OnlineRestaurant.DataLayer")));
            services.AddTransient<IRestaurantBusiness, RestaurantBusiness>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "ReviewManager (V 1.0)");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
