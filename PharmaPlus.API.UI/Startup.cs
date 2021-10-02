using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaPlus.Core.Produits.Infrastructures.Data;
using PharmaPlus.Core.Produits.Domain;
using PharmaPlus.Core.Produits.Infrastructures.Repositories;
using PharmaPlus.API.UI.ExtensionMethods;
using Microsoft.AspNetCore.Identity;

namespace PharmaPlus.API.UI
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
            services.AddDbContext<ProduitsContext>(options => {
                options.UseSqlServer(this.Configuration.GetConnectionString("ProduitsDatabase"), sqlOptions => {});
            });

            services.AddDefaultIdentity<IdentityUser>(options => 
            {
                //options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<ProduitsContext>();

            services.AddInjection();
            services.AddCustomSecurity(this.Configuration);


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PharmaPlus.API.UI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PharmaPlus.API.UI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(SecurityMethods.DEFAULT_POLICY);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
