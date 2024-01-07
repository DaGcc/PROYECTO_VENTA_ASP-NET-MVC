using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sistema.DAL.DBContext;

namespace Sistema.IOC
{
    public static class Dependencia
    {


        //* Este metodo tendra todas las inyecciones de dependencia,
        //* e iran en el proyecto principal, en el porgram.cs del app web(MVC), pro ejejmplo,
        //* builder.Services.InyectarDependencia(builder.Configuration);
        //! el namespace de esta clase se tiene que hace un using manualmente.
        public static void InyectarDependencia(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContext<DbventaContext>(opt =>
            {
                opt.LogTo(Console.WriteLine, new []{DbLoggerCategory.Database.Command.Name }, LogLevel.Information ).EnableSensitiveDataLogging();
                opt.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });
            
        }

    }
}
