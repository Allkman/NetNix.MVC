using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNix.MVC.AutoMapper
{
    public static class AutoMapperServicesExtention
    {
        public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {

            services.AddAutoMapper(
                typeof(MovieMapperProfile));
            return services;
        }
    }
}
