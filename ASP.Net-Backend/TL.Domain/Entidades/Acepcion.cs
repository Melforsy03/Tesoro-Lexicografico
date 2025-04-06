using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL.Domain.Relaciones;

namespace TL.Domain.Entidades
{
    public class Acepcion
    {
        public int IdAc {  get; set; }
        public int IdEnt {  get; set; }
        public DiccionarioTermino Entrada { get; set; }
        public int NumDef {  get; set; }
        public string ClasePal {  get; set; }
        public string Pais {  get; set; }
        public string Etim {  get; set; }
        public string ClaseSem { get; set; }
        public string Def { get; set; }
    }
}
