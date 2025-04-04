using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL.Domain.Relaciones
{
    public class SubEntrada
    {
        public int SubEntId { get; set; }
        public int EntPadreId {  get; set; }
        public int EntHijoId { get; set; }
        public DiccionarioTermino EntradaPadre { get; set; }
        public DiccionarioTermino EntradaHijo { get; set; }
    }
}
