namespace BackendLibreria.DTOs
{
    public class CreateNotaDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Calificacion { get; set; } // Calificación entre 1 y 5
        public string Comentario { get; set; } = string.Empty;

    }
}
