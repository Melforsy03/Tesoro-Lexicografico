using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL.Domain.Entidades
{
    public class Metadatos
    {
        public int IdMet {  get; set; }
        public int IdDic {  get; set; }
        public Diccionario Diccionario { get; set; }
        public string Titulo { get; set; }
        public string TituloCompleto {  get; set; }
        public string Autor {  get; set; }
        public string FechaOriginal { get; set; }
        public string Siglo { get; set; }
        public string LugarDePublicacion { get; set; }
        public string Publicador { get; set; }
        public string FechaDePublicacion { get; set; }
        public string Edicion { get; set; }
        public string NombreDeFuente {  get; set; }
        public string FuenteURL {  get; set; }
        public string Pais {  get; set; }
        public string CodigoDePais {  get; set; }
        public string Remarks {  get; set; }
        public string NombreDeProyecto {  get; set; }
        public string Transcriptor {  get; set; }
        public string FechaDeTranscripcion { get; set; }
        public string Revisor {  get; set; }
        public string FechaDeRevision {  get; set; }
        public string NombreDePrologo { get; set; }
        public string PrologoURL { get; set; }
    }
}
