namespace CodebaseProject.Models
{
    public class AddBookViewModel
    {
        public string BookName { get; set; } = string.Empty;

		public Guid Edition { get; set; }
        public string Author { get; set; } = string.Empty;
	}
}
