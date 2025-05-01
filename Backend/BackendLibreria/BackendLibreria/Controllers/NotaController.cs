using BackendLibreria.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class NotaController : ControllerBase
{
    private readonly INotaService _notaService;

    public NotaController(INotaService notaService)
    {
        _notaService = notaService;
    }

    [Authorize]
    // Obtener una nota por su ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotaPorIdAsync(int id)
    {
        var notaDto = await _notaService.GetNotaPorIdAsync(id);
        if (notaDto == null)
        {
            return NotFound();
        }
        return Ok(notaDto);
    }

    [Authorize]
    [HttpGet("libro/{bookId}")]
    public async Task<IActionResult> GetNotasPorLibroAsync(int bookId)
    {
        var notas = await _notaService.GetNotasPorLibroAsync(bookId);
        if (notas == null || !notas.Any())
        {
            return NotFound(); // Si no se encuentran notas para el libro
        }
        return Ok(notas);
    }

    [Authorize]
    // Crear una nueva nota
    [HttpPost]
    public async Task<IActionResult> CrearNotaAsync([FromBody] CreateNotaDTO createNotaDto)
    {
        bool result = await _notaService.CrearNotaAsync(createNotaDto);

        if (result)
        {
            return Ok(true); // Retorna true si la operación fue exitosa
        }
        else
        {
            return BadRequest(false); // Retorna false si hubo un error
        }
    }


}
