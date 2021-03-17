using Application;
using ApplicationService.Interfaces;
using ApplicationServices.Implementation;
using DataAccess;
using DataAccess.Interface;
using DomainServices.Implementation;
using DomainServices.Interfaces;
using Infrastructure.Implementation;
using Infrastructure.Interfaces.Integrations;
using Infrastructure.Interfaces.WebApp;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UseCases.Order.Commands.Create;
using WebApp.Services;

namespace CleanArchStartingProject
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()); 
            });

            #region Domain
            services.AddScoped<IOrderDomainService, OrderDomainService>();
            #endregion

            #region Infrastructure
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddDbContext<IDbContext,AppDbContext>(opts => opts
                .UseSqlServer(
                    Configuration.GetConnectionString("sqlConnection"),
                    b=>b.MigrationsAssembly("DataAccess")
                    )
            );
            #endregion

            #region Application
            services.AddMediatR(typeof(CreateOrderCommand));
            services.AddScoped<ISecurityService, SecurityService>();
            #endregion

            #region Frameworks
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddControllers();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandlerMiddleware();

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
