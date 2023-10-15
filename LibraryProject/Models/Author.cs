namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
public class Author : Audit
{
    [Key]
    public int AuthorId { get; set; }

    [Required(ErrorMessage = "Please insert the First Name")]
    [Display(Name = "Last name")]
    [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Please insert the Last Name")]
    [Display(Name = "First name")]
    [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    public string? FirstName { get; set; }

    [Display(Name = "Birth Place")]
    public string? BirthPlace { get; set; }

    [Display(Name = "Has this author won any Nobel Prize")]
    public bool NobelPrize { get; set; }

}
