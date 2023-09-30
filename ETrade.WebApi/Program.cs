using ETrade.Business;
using ETrade.Business.Mapping.AutoMapper;
using ETrade.Core.Abstract.DataAccess;
using ETrade.DataAccess.EntityFrameworkCore;
using ETrade.Entities.Concrete;
using ETrade.Entities.Validators;
using System.Data.Entity;

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
            
            //builder.Services.AddScoped<AddressManager,AddressManager>();
            builder.Services.AddScoped<DbContext,DatabaseContext>();
            builder.Services.AddScoped<IEntityDal<AddressEntity>, EfEntityGenericRepository<AddressEntity>>();
            builder.Services.AddScoped<BaseEntityValidator<AddressEntity>,AddressValidator>();

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
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }


        
    }
}