using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CarWash_DAL.Interface;
using CarWash_DAL.Repository;
using CarWash_DAL.Models;
using CarWash_BAL;
using Microsoft.EntityFrameworkCore;
using CarWash_BAL.Services;
using CarWash_DAL.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CarWash_DAL.JWT;
namespace CarWashWebApiService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("OnDemandCarWash", (builder) =>
                {
                    builder.WithOrigins("https://localhost:4200").AllowAnyOrigin()
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithExposedHeaders("*");
                });
            });
            var jwtSettings = Configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
            services.AddDbContext<CarWashDBContext>
                (options => options.UseLazyLoadingProxies().
                UseSqlServer(Configuration.GetConnectionString("conString")));
            services.AddTransient<IUserRepository<CwuserProfile>, UserRepository>();
            services.AddTransient<ILoginRepository<CwuserProfile>, LoginRepository>();
            services.AddTransient<ICarRepository<CwcarRecord>, CarRepository>();
            services.AddTransient<IWashRepository<CwwashNow>, WashRepository>();
            services.AddTransient<IWashRequest<WashRequest>, WashRequestRepository>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<CarService, CarService>();
            services.AddTransient<WashNowService, WashNowService>();
            services.AddTransient<LoginService, LoginService>();
            services.AddTransient<WashRequestService, WashRequestService>();
            services.AddScoped<JwtHandler>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarWashWebApiService", Version = "v1" });
            });
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarWashWebApiService v1"));
            }
            app.UseHttpsRedirection();
            app.UseCors("OnDemandCarWash");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
