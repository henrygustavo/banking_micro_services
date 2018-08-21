namespace Customer.Api
{
    using AutoMapper;
    using Customer.Application.Service;
    using Customer.Domain.Repository;
    using Customer.Domain.Service;
    using Customer.Infrastructure.Repository;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CustomerContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<ICustomerApplicationService, CustomerApplicationService>();
            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            services.AddScoped<ICustomerDomainService, CustomerDomainService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<DbInitializer>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFromAll",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials()
                        .AllowAnyHeader());
            });

            services.AddAutoMapper();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInitializer seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");

            app.UseCors("AllowFromAll")//always berofe "UseMvc"
               .UseMvc()
               .UseDefaultFiles(options)
               .UseStaticFiles();

            seeder.Seed().Wait();

        }
    }
}
