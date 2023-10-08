using LibraryManagement.Models;

namespace LibraryManagement.ViewModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public DateOnly PublicationDate { get; set; }
        public string? Genre { get; set; }
        public string? BranchName { get; set; }

        public string? AutorName { get; set; }

    }
}
