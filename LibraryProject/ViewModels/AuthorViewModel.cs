using LibraryManagement.Models;

namespace LibraryManagement.ViewModel
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? BirthPlace { get; set; }
        public bool? NobelPrize { get; set; }

        public List<Author>? AuthorList {get; set; }
    }
}
