using BackendLibreria.Data;
using BackendLibreria.DTOs;
using BackendLibreria.Models;
using Microsoft.EntityFrameworkCore;

public class NotaService : INotaService
{
    private readonly ApplicationDBContext _context;

    public NotaService(ApplicationDBContext context)
    {
        _context = context;
    }

    // Obtener las notas de un libro
    public async Task<List<NotaDTO>> GetNotasPorLibroAsync(int bookId)
    {
        var notas = await _context.Notas
            .Include(n => n.Usuario)
            .Include(n => n.Libro)
            .Where(n => n.BookId == bookId)
            .OrderByDescending(n => n.Fecha) // Ordenar por fecha (más recientes primero)
            .ToListAsync();

        return notas.Select(n => new NotaDTO
        {
            Id = n.Id,
            UserId = n.UserId,
            BookId = n.BookId,
            Calificacion = n.Calificacion,
            Comentario = n.Comentario,
            Fecha = n.Fecha,
            UsuarioNombre = n.Usuario?.Name ?? "Desconocido",
            LibroTitulo = n.Libro?.Title ?? "Desconocido"
        }).ToList();
    }

    // Obtener una nota por su ID
    public async Task<NotaDTO?> GetNotaPorIdAsync(int id)
    {
        var nota = await _context.Notas
            .Include(n => n.Usuario)
            .Include(n => n.Libro)
            .FirstOrDefaultAsync(n => n.Id == id);

        if (nota == null) return null;

        return new NotaDTO
        {
            Id = nota.Id,
            UserId = nota.UserId,
            BookId = nota.BookId,
            Calificacion = nota.Calificacion,
            Comentario = nota.Comentario,
            Fecha = nota.Fecha,
            UsuarioNombre = nota.Usuario?.Name ?? "Desconocido",
            LibroTitulo = nota.Libro?.Title ?? "Desconocido"
        };
    }

    // Crear una nueva nota
    public async Task<bool> CrearNotaAsync(CreateNotaDTO createNotaDto)
    {
        try
        {
            var nota = new Nota
            {
                UserId = createNotaDto.UserId,
                BookId = createNotaDto.BookId,
                Calificacion = createNotaDto.Calificacion,
                Comentario = createNotaDto.Comentario,
                Fecha = DateTime.Now // Aquí se agrega la fecha actual
            };

            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();

            return true; // Si la nota se guardó exitosamente
        }
        catch
        {
            return false; // Si hubo algún error al guardar
        }
    }

}
