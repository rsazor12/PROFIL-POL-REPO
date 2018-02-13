using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProfilPol.Core.Domain.Repositories;
using ProfilPol.Infrastructure.Mappers;
using ProfilPol.Infrastructure.Repositories;
using ProfilPol.Infrastructure.Services;
using ProfilPol.Infrastructure.Settings;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });



            services.AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
            // Add authorization to App
            services.AddAuthorization(x => x.AddPolicy("HasAdminRole", p => p. RequireRole("admin")));
            // Created by one request HTTP
            services.AddScoped<IGarageRepository, GarageRepository >();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGarageService, GarageService>();
            services.AddScoped<IUserService, UserService>();
            // Pernament objects
            services.AddSingleton(AutoMapperConfig.Initialize()); // methods Initialize return IMapper so <Imapper> is not necessary here

            // Jwt json settings settings binding to class (from app settings)
            // services.Configure<JwtSettings>(Configuration.GetSection("jwt"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // var jwtSettings = app.ApplicationServices.GetService<JwtSettings>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
