namespace BackendLibreria.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
    }
}
