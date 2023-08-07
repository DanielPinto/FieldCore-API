using FieldCoreAPI.Auth;
using FieldCoreAPI.Datas;
using FieldCoreAPI.Repositories;
using FieldCoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using WebApi.Application.Swagger;

namespace FieldCoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler
                .IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //builder.Services.AddEntityFrameworkSqlServer().AddDbContext<FieldCoreAPIDBContext>(
            //  options => options.UseSqlServer(
            //    builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddDbContext<FieldCoreAPIDBContext>(
                options => options.UseMySql(
                    builder.Configuration.GetConnectionString("DataBase"),
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql")
                    ));

            builder.Services.AddScoped <IUserRepository,UserRepository>();
            builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            builder.Services.AddScoped<IRegionalRepository, RegionalRepository>();

            var key = Encoding.ASCII.GetBytes(Key.Secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}