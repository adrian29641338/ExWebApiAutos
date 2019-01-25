using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExWebApiAutos.Model;
using ExWebApiAutos.Model.ExWebApiAutos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ExWebApiAutos
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
            services.AddDbContext<ExWebApiDbContext>(options => 
                options.UseSqlServer(
                    Configuration["Data:ExWebApiAutos:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options => 
            options.UseSqlServer(
                Configuration["Data:ExWebApiAutosIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAutoRepository, EFAutoRepository>();
            services.AddTransient<IMarcaRepository, EFMarcaRepository>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "ExWebApiAutos", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseAuthentication();
            app.UseMvc();
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
