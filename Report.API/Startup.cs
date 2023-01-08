using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Report.API.Cache.RedisCache;
using Report.Api.Service.Automapper;
using Report.API.Data;
using Report.API.Data.Repository;
using Report.API.Data.Repository.Interfaces;
using Report.API.Messaging.Options;
using Report.API.Messaging.Receiver;
using Report.API.Messaging.Sender;
using Report.API.Service.Interfaces;
using Report.API.Service.Services;

namespace Report.API
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
            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            var serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMqConfiguration>();
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);

            services.AddDbContext<PostgreSqlReportDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Report.API.Data")));
            services.AddScoped<DbContext>(provider => provider.GetService<PostgreSqlReportDbContext>());

            services.AddScoped<IContactDetailRepository, ContactDetailRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            
            services.AddSingleton<IReportRequestSender, ReportRequestSender>();
            services.AddSingleton<ICacheProvider, CacheProvider>();
            services.AddSingleton<ICalculationService, CalculationService>();

            services.AddScoped<IElectionService, ElectionService>();

            services.AddControllers();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddStackExchangeRedisCache(action =>
            {
                action.Configuration = "127.0.0.1:6379";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Report.API", Version = "v1" });
            });

            if (serviceClientSettings.Enabled)
            {
                services.AddHostedService<ReportRequestReceiver>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Report.API v1"));
            }

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