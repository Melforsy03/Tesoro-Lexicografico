using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL.Domain.Entidades;

namespace TL.Domain.Relaciones
{
    public class DiccionarioTermino
    {
        public int IdDicTer { get; set; }
        public int IdDic { get; set;}
        public int IdTer { get; set; }
        public string NomEntrada {  get; set; }
        public bool EsSuperEntrada { get; set; }
        public bool EsSubEntrada { get; set; }
        public Diccionario Diccionario { get; set; }
        public Termino Termino { get; set; }
    }
}
