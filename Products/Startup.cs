using CommonLibraries.Interfaces;
using DataManager.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Products.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products
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
            services.AddCors();

            services.AddSwaggerGen(c =>
            { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
            services.AddCors();
            services.AddControllers().AddXmlDataContractSerializerFormatters();
            services.AddDbContext<DataContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ProductDB")));
            services.AddScoped<IDataUoW, DataUow>();
            
            services.AddScoped<IProducts, ProductsManager>();
            services.AddScoped<ICustomers, CustomersManager>();
            services.AddScoped<IOrders, OrdersManager>();
            services.AddScoped<IUserAddress, UserAddressManager>();
            services.AddScoped<IUserProfile, UserProfileManager>();
            services.AddScoped<IUserDetails, UserDetailsManager>();
            services.AddScoped<ISecretQuestions, SecretQuestionsManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());


            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => {
                c.RoutePrefix = "docs"; //localhost / docs to get swagger
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
