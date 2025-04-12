using TL.Application.DTOs;

namespace TL.Application.Interfaces
{
    public interface IEditorService
    {
        Task<IEnumerable<EditorDTO>> ObtenerTodosAsync();
        Task<EditorDTO> ObtenerPorIdAsync(int id);
        Task<EditorDTO> CrearAsync(EditorDTO dto);
    }
}
