using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProfilPol.Core.Domain.Repositories;
using ProfilPol.Infrastructure.Mappers;
using ProfilPol.Infrastructure.Repositories;
using ProfilPol.Infrastructure.Services;

namespace ProfilPol.Api
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
            services.AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
            // Created by one request HTTP
            services.AddScoped<IGarageRepository, GarageRepository >();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGarageService, GarageService>();
            // Pernament objects
            services.AddSingleton(AutoMapperConfig.Initialize()); // methods Initialize return IMapper so <Imapper> is not necessary here

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
