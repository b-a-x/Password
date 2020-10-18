using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Passwords.Server.Data;
using Passwords.Server.Helpers;
using Passwords.Server.Managers;
using Passwords.Server.Middlewaries;
using Passwords.Server.Services;
using Passwords.Server.Settings;

namespace Passwords.Server
{
    public class Startup
    {
        private IConfiguration configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Heroku
            var connectionString = new DbConfigHelper(Environment.GetEnvironmentVariable("DATABASE_URL")).ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(x =>
            {
                if (true)
                {
                    x.UseNpgsql(connectionString);
                }
                /*else{x.UseInMemoryDatabase("TestDb");}*/
            });

            services.AddCors();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            var appSettingsSection = configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordInfoService, PasswordInfoService>();

            services.AddSingleton<IJwtManager, JwtManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            app.UseMiddleware<LogErrorMiddleware>();

            app.UseRouting();

            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(x => x.MapControllers());

            //DbInitializeHelper.EnsureCreated(context);
            //DbInitializeHelper.CreateUser(context);
            DbInitializeHelper.Migrate(context);
        }
    }
}
