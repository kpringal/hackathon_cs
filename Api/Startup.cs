using Api.Helper;
using Api.Models;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
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
            OptionsConfigurationServiceCollectionExtensions.Configure<Settings>(services, Configuration.GetSection("Settings"));
          

            services.AddSwaggerGen();
            services.AddDbContext<OfficeSpaceAllocationContext>(
                    options => options.UseSqlServer("Server=tcp:hackathon-cs.database.windows.net,1433;Database=OfficeSpaceAllocation;user id=hackathon;password=cloudecare@123"));

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<ISpaceAllocationService, SpaceAllocationService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
