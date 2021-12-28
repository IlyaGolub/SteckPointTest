using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using SteckPointTestSendData.Model;
using SteckPointTestSendData.Domain.Entities;
using SteckPointTestSendData.Services;

namespace SteckPointTestSendData
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
            services.AddControllers();
            services.AddAutoMapper(opt =>
            {            
                opt.CreateMap<User, UsersDTO>();
            });
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo
                    {                    
                    Contact = new OpenApiContact
                        {
                        Name = "Ilya Golub",
                        Email ="ilay52044@gmail.com",                        
                        },
                    }
                )
            );
            services.AddScoped<ISendDataServices, SendDataServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SteckPointTest");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
