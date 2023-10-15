namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book : Audit
{
    [Key]
    public int BookId { get; set; }
    
    [Required(ErrorMessage = "Please insert the  title")]
    [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
    [Display(Name = "Title")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Please insert the  ISBN")]
    [StringLength(75, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
    [Display(Name = "ISBN")]
    public string? ISBN { get; set; }
    
    [Required(ErrorMessage = "Please insert the Publication date")]
    [Display(Name = "Publication")]
    [DataType(DataType.Date)]
    public DateOnly PublicationDate { get; set; }
    public string? Genre { get; set; }

    [ForeignKey("Author")]//Key for AuthorId
    public int AuthorId { get; set; }

    [ForeignKey("Library")] //Foreing Key for LibraryBranch
    public int LibraryBranchId { get; set; }

    public bool AvailableToBeTaken{ get; set; }

    //public required LibraryBranch Library { get; set; } //Relation btw Library - Book
    // public required Author author { get; set; } //Relation btw Autor - Book
}
