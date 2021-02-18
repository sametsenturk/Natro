using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Natro_Backend.BLL.Operation.RdapOperations;
using Natro_Backend.BLL.Operation.UserOperations;
using Natro_Backend.Core.Abstract;
using Natro_Backend.Core.Concrate;
using Natro_Backend.DAL.Abstract;
using Natro_Backend.DAL.Concrate;
using Natro_Backend.Entity.Context;
using Natro_Backend.Entity.Entities;
using Natro_Backend.RDAP;
using Natro_Backend.RDAP.Abstract;
using Natro_Backend.Security.Abstract;
using Natro_Backend.Security.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natro_Backend.API
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
            services.AddCors();

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JWTSecret").Value);
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
                    ValidateAudience = false
                };
            });

            services.AddDbContext<MssqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));


            #region Repository
            services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();
            services.AddScoped<IRepository<UserFavoriteEntity>, Repository<UserFavoriteEntity>>();            
            #endregion

            #region Repository Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserFavoriteService, UserFavoriteService>();
            #endregion

            #region BLL Operations
            services.AddScoped<RdapOperations, RdapOperations>();
            services.AddScoped<UserOperations, UserOperations>();
            #endregion

            #region Integration

            #region RDAP

            services.AddScoped<IDomainHelper, DomainHelper>();

            #endregion

            #endregion

            #region Security

            services.AddScoped<IHash, SHA512Hash>();

            #endregion

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

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
