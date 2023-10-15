namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
public class Customer : Audit
{
    [Key]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Please inset a valid last name")]
    [Display(Name = "Last Name")]
    [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Please inset a valid name")]
    [Display(Name = "First Name")]
    [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Please inset a valid birthday")]
    [DataType(DataType.Date)]
    public DateOnly Brithday { get; set; }

    [Display(Name = "Is a student?")]
    public bool Student { get; set; }

    [Required(ErrorMessage = "Please inset an email")]
    [Display(Name = "eMail")]
    [DataType(DataType.EmailAddress)]
    [StringLength(35, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please inset phone")]
    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    [StringLength(9, ErrorMessage = "Name length can't be more than 9.")]
    public string? Phone { get; set; }


    [Required(ErrorMessage = "Please inset an address")]
    [Display(Name = "Address")]
    [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    public string? Address { get; set; }

    [Display(Name = "Membership Since")]
    [Required(ErrorMessage = "Please inset a valid date")]
    [DataType(DataType.Date)]
    public DateOnly MembershipSince { get; set; }

}
