﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DAL.Repositorios;

using SistemaVenta.Utility;


namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbventaContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
            });

            // Devuelve una referencia de las instancias mencionadas en los typeof ( <> significa de cualquier modelo)
                        //instancia en cada resolución (transient)
                        //instancia en cada solicitud (scoped)
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));   
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

        }
        

    }
}
