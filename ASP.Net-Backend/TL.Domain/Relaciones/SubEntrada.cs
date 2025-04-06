using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL.Domain.Relaciones
{
    public class SubEntrada
    {
        public int IdSubEnt { get; set; }
        public int IdEntPadre {  get; set; }
        public int IdEntHijo { get; set; }
        public DiccionarioTermino EntradaPadre { get; set; }
        public DiccionarioTermino EntradaHijo { get; set; }
    }
}
