namespace BackendLibreria.DTOs
{
    public class NotaDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Calificacion { get; set; } // 1 a 5
        public string Comentario { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }

        // Propiedades adicionales para simplificar la respuesta (opcional)
        public string UsuarioNombre { get; set; } = string.Empty;
        public string LibroTitulo { get; set; } = string.Empty;
    }
}
