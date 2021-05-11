using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductAPI.Extensions;
using ProductAPI.Mapper;

namespace ProductAPI
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
            var connectionString = Configuration.GetConnectionString("OrclConnection");

            services.AddControllers();

            services.AddDbContext<StoreContext>(options => options
            .UseOracle(connectionString, x => x.UseOracleSQLCompatibility("11")));

            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseOracle(connectionString, x => x.UseOracleSQLCompatibility("11"));
            });

            services.AddScoped<IUom, Uom>();

            services.AddIdentityServices();

            services.AddSwaggerServices();

            services.AddAutoMapper(typeof(MapProfiles));

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerDoc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
