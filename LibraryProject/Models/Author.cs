namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
public class Author
{
     [Key]
    public int AuthorId { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? BirthPlace { get; set; }
    public bool? NobelPrize { get; set; }
    
}
