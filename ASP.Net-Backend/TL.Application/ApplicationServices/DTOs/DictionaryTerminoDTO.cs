namespace TL.Application.ApplicationServices.DTOs
{
    public class DiccionarioTerminoDTO
    {
        public int IdDicTer { get; set; }
        public int IdDic { get; set; }
        public int IdTer { get; set; }
        public string NomEntrada { get; set; }
        public bool EsSuperEntrada { get; set; }
        public bool EsSubEntrada { get; set; }
    }
}
