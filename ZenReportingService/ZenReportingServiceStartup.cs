using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ZenReportingService.Data;
using ZenReportingService.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;



namespace ZenReportingService
{
    public class ZenReportingServiceStartup
    {

        public ZenReportingServiceStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IEmailService, EmailService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZenReportingService API", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZenReportingService API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/api/reports/generate-pdf", async context =>
                {
                    
                    var document = new PdfDocument();
                    var page = document.AddPage();
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter = new XTextFormatter(graphics);

                    
                    var font = new XFont("Verdana", 20, XFontStyle.Bold);
                    textFormatter.DrawString("Hello, this is a sample PDF report.", font, XBrushes.Black,
                        new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);

                   
                    using (var memoryStream = new MemoryStream())
                    {
                        document.Save(memoryStream);
                        memoryStream.Position = 0;

                       
                        context.Response.Headers.Add("Content-Disposition", "attachment; filename=report.pdf");
                        context.Response.ContentType = "application/pdf";
                        await memoryStream.CopyToAsync(context.Response.Body);
                    }
                });
            });

        }
    }
}
