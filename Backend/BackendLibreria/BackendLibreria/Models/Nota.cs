using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendLibreria.Models
{
    public class Nota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Calificacion { get; set; } // 1 a 5
        public string Comentario { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relaciones (opcional)
        public User? Usuario { get; set; }
        public Book? Libro { get; set; }
    }
}
