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

            services.AddCors(option =>
            {
                option.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen();
            services.AddDbContext<OfficeSpaceAllocationContext>(
                    options => options.UseSqlServer("Server=tcp:hackathon-cs.database.windows.net,1433;Database=OfficeSpaceAllocation;user id=hackathon;password=cloudecare@123", _ => _.CommandTimeout(5 * 60)));

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<ISpaceAllocationService, SpaceAllocationService>();
            services.AddScoped<IFreeAllocatedSpaceService, FreeAllocatedSpaceService>();
            services.AddScoped<IAutoSeatAllocationService, AutoSeatAllocationService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IPendingRequestService, PendingRequestService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

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
