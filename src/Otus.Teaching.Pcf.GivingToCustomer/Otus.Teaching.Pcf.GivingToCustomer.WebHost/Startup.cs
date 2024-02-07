using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Gateways;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess.Data;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.Integration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using MongoDB.Driver;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;

namespace Otus.Teaching.Pcf.GivingToCustomer.WebHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IMongoClient>(_ =>
                    new MongoClient(Configuration["MongoDb:ConnectionString"]))
                .AddSingleton(serviceProvider =>
                    serviceProvider.GetRequiredService<IMongoClient>()
                        .GetDatabase(Configuration["MongoDb:Database"]))
                .AddSingleton(serviceProvider =>
                    serviceProvider.GetRequiredService<IMongoDatabase>()
                        .GetCollection<Customer>("customer"))
                .AddSingleton(serviceProvider =>
                    serviceProvider.GetRequiredService<IMongoDatabase>()
                        .GetCollection<Preference>("preference"))
                .AddSingleton(serviceProvider =>
                    serviceProvider.GetRequiredService<IMongoDatabase>()
                        .GetCollection<PromoCode>("promocode"))
                .AddScoped(serviceProvider =>
                    serviceProvider.GetRequiredService<IMongoClient>()
                        .StartSession());

            services.AddControllers().AddMvcOptions(x=> 
                x.SuppressAsyncSuffixInActionNames = false);

            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IRepository<Customer>, MongoRepository<Customer>>();
            services.AddScoped<IRepository<Preference>, MongoRepository<Preference>>();
            services.AddScoped<IRepository<PromoCode>, MongoRepository<PromoCode>>();

            services.AddScoped<INotificationGateway, NotificationGateway>();
            services.AddScoped<IDbInitializer, MongoDbInitializer>(x =>
            new MongoDbInitializer(x.GetRequiredService<IMongoClient>(), Configuration["MongoDb:Database"]));

            //services.AddDbContext<DataContext>(x =>
            //{
            //    //x.UseSqlite("Filename=PromocodeFactoryGivingToCustomerDb.sqlite");
            //    x.UseNpgsql(Configuration.["PostgreSQL:ConnectionString"]);
            //    x.UseSnakeCaseNamingConvention();
            //    x.UseLazyLoadingProxies();
            //});

            services.AddOpenApiDocument(options =>
            {
                options.Title = "PromoCode Factory Giving To Customer API Doc";
                options.Version = "1.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(x =>
            {
                x.DocExpansion = "list";
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            dbInitializer.InitializeDb();
        }
    }
}