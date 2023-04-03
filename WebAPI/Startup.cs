using DataAccess;
using DataAccess.CustomContexts;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Mailing.EmailServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Models.MailingModels;
using WebAPI.HttpProxy;
using WebAPI.Services;
using WebAPI.Services.Interfaces;

namespace WebAPI
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddControllers();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("dev", new OpenApiInfo { Title = "WebAPI"});
            });

            #region HTTPProxy
            // Initialize HTTPProxy
            services.AddHttpClient<HttpProxyClient>();
            services.AddTransient<IHttpProxy, WebAPI.HttpProxy.HttpProxy>(serviceProvider =>
            {
                var httpClient = serviceProvider.GetRequiredService<HttpProxyClient>();
                var httpProxy = new WebAPI.HttpProxy.HttpProxy(httpClient.Client);

                return httpProxy;
            });
            #endregion
            #region Database
            // Initialize the context
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                ));

            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITest2Repository, Test2Repository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
            #region Application services
            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISensorService, SensorService>();
            services.AddTransient<INgrokService, NgrokService>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/dev/swagger.json", "WebApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
