using Data.Provider.Repositiories;
using DataAccess.Base;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Models;
using Services.Interfaces;
using Services.Services;
using WebAPI.HttpProxy;

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
            services.AddControllers();

            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieAPI", Version = "v1" });
            });

            services.AddHttpClient<HttpProxyClient>();
            services.AddTransient<IHttpProxy, WebAPI.HttpProxy.HttpProxy>(serviceProvider =>
            {
                var httpClient = serviceProvider.GetRequiredService<HttpProxyClient>();
                var httpProxy = new WebAPI.HttpProxy.HttpProxy(httpClient.Client);

                return httpProxy;
            });

            // Initialize the context
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                ));

            var baseRepoType = typeof(BaseRepository<BaseContext, BaseModel>);
            //var repositories = new List<baseRepoType>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITest2Repository, Test2Repository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi");
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
