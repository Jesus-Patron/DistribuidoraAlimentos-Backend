using DistribuidoraAlimentos.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DistribuidoraAlimentos.DAL.Repositorios.Contratos;
using DistribuidoraAlimentos.DAL.Repositorios;
using DistribuidoraAlimentos.Utility;
using DistribuidoraAlimentos.BLL.Servicios.Contratos;
using DistribuidoraAlimentos.BLL.Servicios;

namespace Distribuidora_Alimentos.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DistribuidoraAlimentosContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVentaService, VentaService>();
            services.AddScoped<IMarcaService, MarcaService>();
        }
    }
}
