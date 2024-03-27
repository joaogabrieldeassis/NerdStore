using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Application.AutoMapper;
using NerdStore.Catalogo.Data.Context;
using System.Reflection;

namespace NerdSotore.WebApp.MVC.Configurations
{
    public static class ConfigurationProgram
    {
        public static void ConfigurationServices(ref WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
            builder.Services.AddMediatR(a => a.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

        public static void ConfigurationDb(ref WebApplicationBuilder builder)
        {
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<CatalogoContext>(c =>
            {
                c.UseSqlServer(connection);
            });
        }
    }
}
