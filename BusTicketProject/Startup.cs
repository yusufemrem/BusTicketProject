using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusTicketProject.Services;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using JWTIdentity.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketProject
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

            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });   
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>
                (TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                  ValidateActor = true,
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  RequireExpirationTime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = Configuration["Jwt:Issuer"],
                  ValidAudience = Configuration["Jwt:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
              };
          });

            services.AddTransient<IAuthService, AuthService>();

            services.AddMediatR(typeof(Startup));


            services.AddHttpClient();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman aþýmýný ayarlayabilirsiniz
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<ITicketDal, EfTicketRepository>();
            services.AddScoped<ITicketService, TicketManager>();

            services.AddScoped<IVoyageDal, EfVoyageRepository>();
            services.AddScoped<IVoyageService, VoyageManager>();

            services.AddScoped<IUserDal, EfUserRepository>();
            services.AddScoped<IUserService, UserManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<ICompanyDal, EfCompanyRepository>();
            services.AddScoped<ICompanyService, CompanyManager>();

            services.AddScoped<IExcelService, ExcelManager>();

            services.AddScoped<IMessageDal, EfMessageRepository>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<IDiscountDal, EfDiscountRepository>();
            services.AddScoped<IDiscountService, DiscountManager>();

            services.AddSingleton<IFileProvider>(
   new PhysicalFileProvider(Directory.GetCurrentDirectory()));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:8082")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithExposedHeaders("Access-Control-Allow-Origin")
            .SetIsOriginAllowed((host) => true));
            });

            services.AddHttpClient();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BusTicketProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var path = Directory.GetCurrentDirectory();
            //loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusTicketProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
              .WithOrigins("https://localhost:44336")
            .AllowAnyOrigin()     // api req kodlarý güvenlik için (vs code)
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseAuthentication();


            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
