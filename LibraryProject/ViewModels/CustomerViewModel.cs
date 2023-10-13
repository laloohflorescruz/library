using System.ComponentModel.DataAnnotations;
using LibraryManagement.Models;

namespace LibraryManagement.ViewModel
{
    public class CustomerViewModel  : Audit
    {
        public int CustomerId { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        public DateOnly Brithday { get; set; }

        [Display(Name = "Is a student?")]
        public bool Student { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        [Display(Name = "Membership Since")]
        public DateOnly MembershipSince { get; set; }
        
 
    }
}
