using TL.Application.ApplicationServices.DTOs;

namespace TL.Application.ApplicationServices.Interfaces
{
    public interface IEditorService
    {
        Task<IEnumerable<EditorDTO>> ObtenerTodosAsync();
        Task<EditorDTO> ObtenerPorIdAsync(int Id);
        Task<EditorDTO> CrearAsync(EditorDTO dto);
        Task<EditorDTO> BorrarAsync(int Id);
    }
}
