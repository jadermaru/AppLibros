using BackendLibreria.DTOs;

public interface INotaService
{
    Task<List<NotaDTO>> GetNotasPorLibroAsync(int bookId);
    Task<NotaDTO?> GetNotaPorIdAsync(int id);
    Task<bool> CrearNotaAsync(CreateNotaDTO createNotaDto);  // Cambiado a Task<bool>
}
