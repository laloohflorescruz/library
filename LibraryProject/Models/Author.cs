namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
public class Author
{
    [Key]

    public int AuthorId { get; set; }

    [Required(ErrorMessage = "Please insert the First Name")]
    [Display(Name = "Last name")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Please insert the Last Name")]
    [Display(Name = "First name")]
    public string? FirstName { get; set; }

    [Display(Name = "Birth Place")]

    public string? BirthPlace { get; set; }

    [Display(Name = "Has this author won any Nobel Prize")]
    public bool NobelPrize { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
