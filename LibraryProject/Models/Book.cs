namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [Key]
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public DateOnly PublicationDate { get; set; }
    public string? Genre { get; set; }

    [ForeignKey("Author")]//Key for AuthorId
    public int AuthorId { get; set; }

    [ForeignKey("Library")] //Foreing Key for LibraryBranch
    public int LibraryBranchId { get; set; }

    public required LibraryBranch Library { get; set; } //Relation btw Library - Book
    public required Author author { get; set; } //Relation btw Autor - Book
}
