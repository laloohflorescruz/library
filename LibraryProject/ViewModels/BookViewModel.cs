using System.ComponentModel.DataAnnotations;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.ViewModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please insert the title")]
        [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        [Display(Name = "Title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Please insert the ISBN")]
        [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        [Display(Name = "ISBN")]
        public required string ISBN { get; set; }

        [Required(ErrorMessage = "Please insert the Publication date")]
        [Display(Name = "Publication")]
        [DataType(DataType.Date)]
        public DateOnly PublicationDate { get; set; }

        public required string Genre { get; set; }

        public int AuthorId { get; set; }

        [Display(Name = "Library")]
        public int LibraryBranchId { get; set; }

        // public required List<SelectListItem> Author { get; set; }
        public required IEnumerable<SelectListItem> Author { get; set; }

    }
}
