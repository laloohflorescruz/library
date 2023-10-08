using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModel
{
    public class LibraryBranchViewModel
    {
        public int LibraryBranchId { get; set; }
        public string? BranchName { get; set; }

        public string? ZipCode { get; set; }
        public string? Address { get; set; }

        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }

        [Display(Name = "Opening Hours")]
        public string? OpeningHours { get; set; }

    }
}
