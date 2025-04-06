using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL.Infrastructure.DataAccess.IRepository;
using TL.Infrastructure.DataAccess.Repository;

namespace TL.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAcepcionRepository, AcepcionRepository>();
            services.AddScoped<IDiccionarioRepository, DiccionarioRepository>();
            services.AddScoped<IDiccionarioTerminoRepository, DiccionarioTerminoRepository>();
            services.AddScoped<IEditorRepository, EditorRepository>();
            services.AddScoped<IMetadatosRepository, MetadatosRepository>();
            services.AddScoped<ISubEntradaRepository, SubEntradaRepository>();
            services.AddScoped<ITerminoRepository, TerminoRepository>();
        }
    }
}
