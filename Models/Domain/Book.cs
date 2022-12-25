namespace CodebaseProject.Models.Domain
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }

        public Guid Edition { get; set; }
        public string Author { get; set; }
    }
}
