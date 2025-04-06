using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL.Domain.Entidades;
using TL.Infrastructure.Common.Implementation;
using TL.Infrastructure.DataAccess.IRepository;

namespace TL.Infrastructure.DataAccess.Repository
{
    public class DiccionarioRepository : GenericRepository<Diccionario>, IDiccionarioRepository
    {
        public DiccionarioRepository(Context context) : base(context) { }
    }
}
