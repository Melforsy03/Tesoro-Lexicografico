using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TL.Application.ApplicationServices.Interfaces;
using TL.Application.ApplicationServices.Servicio;

namespace TL.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IAcepcionService, AcepcionService>();
            services.AddScoped<IDiccionarioTerminoService, DiccionarioTerminoService>();
            services.AddScoped<IDiccionarioService, DiccionarioService>();
            services.AddScoped<IEditorService, EditorService>();
            services.AddScoped<IMetadatosService, MetadatosService>();
            services.AddScoped<ISubEntradaService, SubEntradaService>();
            services.AddScoped<ITerminoService, TerminoService>();
        }
    }
}
