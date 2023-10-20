
using ETrade.Business;
using ETrade.Core.Abstract.DataAccess;
using ETrade.DataAccess.EntityFrameworkCore;
using ETrade.Entities.Concrete;
using ETrade.Entities.Validators;
using Microsoft.AspNetCore.Hosting;
using System.Data.Entity;
using ETrade.Core.Mapping.AutoMapper;
using ETrade.Business.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using Microsoft.AspNetCore.Http.Features;

namespace ETrade.WebApi
{
    public class Program
    {

       

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpContextAccessor();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue;

            });
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.MaxRequestBodySize = long.MaxValue;
                
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            //builder.Services.AddScoped<AddressManager,AddressManager>();
            builder.Services.AddScoped<DbContext,DatabaseContext>();
            builder.Services.AddScoped<IEntityDal<AddressEntity>, EfEntityGenericRepository<AddressEntity>>();
            builder.Services.AddScoped<BaseEntityValidator<AddressEntity>,AddressValidator>();
            builder.Services.AddScoped<IAccountService, AccountManager>();

            builder.Services.AddAutoMapper(typeof( AutoMapperProfile));

            
           

            var app = builder.Build();

            //var supportedCultures = new[] {  "tr-TR" , "en-US"};
            //var localizationOptions =
            //    new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
            //    .AddSupportedCultures(supportedCultures)
            //    .AddSupportedUICultures(supportedCultures);

            //app.UseRequestLocalization(localizationOptions);
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAnyOrigin");
            app.UseAuthorization();
            app.UseAuthentication();

            

            app.MapControllers();

            app.Run();
        }


        
    }
}