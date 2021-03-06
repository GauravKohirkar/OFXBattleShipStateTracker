using BattleShipStateTracker.API.Filters;
using BattleShipStateTracker.Data.Data;
using BattleShipStateTracker.Repo;
using BattleShipStateTracker.Repo.Interfaces;
using BattleShipStateTracker.Service;
using BattleShipStateTracker.Service.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShipStateTracker
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            })
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();
            services.AddScoped<IMatchRepo, MatchRepo>();
            services.AddScoped<IBoardRepo, BoardRepo>();
            services.AddScoped<IPlayerRepo, PlayerRepo>();
            services.AddScoped<IShipRepo, ShipRepo>();
            services.AddScoped<IBattleShipService, BattleShipService>();
            services.AddDbContext<BattleShipDbContext>(options =>
                options.UseInMemoryDatabase("BattleShipDb"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
