namespace CodebaseProject.Models
{
	public class UpdateBookViewModel
	{
		public Guid BookId { get; set; }
		public string BookName { get; set; } = string.Empty;

		public Guid Edition { get; set; }
		public string Author { get; set; } = string.Empty;
	}
}
