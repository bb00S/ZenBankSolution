using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ZenCoreService.Data;
using ZenCoreService.Services;
using ZenCoreService.Services.TransactionServices;
using ZenCoreService.Services.Interfaces;
using ZenCoreService.Interfaces;
using Microsoft.OpenApi.Models;
using ZenCoreService.Filters;
using ZenCoreService.Models;



namespace ZenCoreService
{
    public class ZenCoreServiceStartup
    {
        public ZenCoreServiceStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IUserService, UserService>();

            /* services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZenCoreService API", Version = "v1" });
                 c.SchemaFilter<CustomSchemaFilter>();
                 //c.SchemaGeneratorOptions.SchemaIdSelector = type => type == typeof(Transaction) ? "Transaction" : null;
             });*/
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZenCoreService API", Version = "v1" });
                c.SchemaFilter<CustomSchemaFilter>();
            });

            services.AddLogging(builder =>
            {
                builder.AddDebug();
                builder.AddConsole();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZenCoreService API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
