namespace BackendLibreria.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Navigation property (optional)
        public ICollection<Book> Books { get; set; }
    }
}
